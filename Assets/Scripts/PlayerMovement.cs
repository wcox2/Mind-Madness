using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    private float pi = Mathf.PI;
    public GameObject sprite;
    public float movementSpeed = 5f;
    public float jumpVelocity = 5f;
    public float dashSpeed = 5f;
    public float dashTime = 0.5f;
    public float dashCooldown = 0.5f;
    private bool canDash = true;
    private bool isDashing = false;
    public float slamForce = 20f;
    public float slamFreezeTime = 1f;
    public bool isSlamming = false;
    private bool isFrozen = false;
    private float hInput;
    public int maxJumps = 2;
    public int currentJumps = 2;
    private Rigidbody _rb;
    enum playerAction {jump};
    public bool isGrounded = true;
    private bool isFacingRight = true;
    public GameObject mySpawnPoint;
    public AnimationScript animationScript;
    private int orbsCollected = 0;
    public GameController GameController;
    public int numDeaths;
    public bool isPaused = false;

    // Start is called before the first frame update
    void Start() {
        sprite = this.transform.GetChild(0).gameObject;
        _rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -25f, 0);
        numDeaths = 0;
    }

    // Update is called once per frame
    void Update() {
        if (SceneManager.GetActiveScene().name != "LevelSelectorOccipital" && SceneManager.GetActiveScene().name != "LevelSelector" && SceneManager.GetActiveScene().name != "HomeScreen") {
            if (!GameController.isPaused) {
                // Jump
                if(Input.GetKeyDown(KeyCode.W) && (isFrozen == false) && (isDashing == false) && (currentJumps > 0)) {
                    _rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
                    _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
                    currentJumps--;
                    animationScript.UpdateIsJumping(true);
                    if(currentJumps == 0)
                    {
                        animationScript.UpdateIsDoubleJump(true);
                    }
                }

                // Dash
                if(Input.GetKeyDown(KeyCode.Space) && (isFrozen == false) && (canDash)) { 
                    StartCoroutine(dash());
                }

                // Downslam
                if(Input.GetKeyDown(KeyCode.S) && (isFrozen == false) && (isGrounded == false)) {
                    StartCoroutine(freezePlayerTimer(slamFreezeTime));
                    animationScript.UpdateIsSlamming(true);
                    animationScript.UpdateIsJumping(false);
                }

                // Player Orientation Change
                if (Input.GetKeyDown(KeyCode.D) && (isFacingRight == false)) {
                    isFacingRight = true;
                    sprite.transform.Rotate(0, 180, 0);
                }
                if (Input.GetKeyDown(KeyCode.A) && (isFacingRight)) {
                    isFacingRight = false;
                    sprite.transform.Rotate(0, 180, 0);
                }

                hInput = Input.GetAxis("Horizontal") * movementSpeed;
                
                animationScript.UpdateSpeed(hInput);
            }
        }
    }

    void FixedUpdate() {
        if ((isFrozen == false) && (isDashing == false)) {
            _rb.MovePosition(this.transform.position + this.transform.right * hInput * Time.fixedDeltaTime);
        }
    }

    void OnCollisionEnter(Collision collision) {
        Vector3 collisionNormal = collision.contacts[0].normal;
        if (isSlamming) {
            _rb.velocity = new Vector3(0f, -25f, 0f);
        }
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("BreakableGround")) {
            collisionNormal = collision.contacts[0].normal;
            // Check if the collision normal is pointing up (i.e. the bottom of the player is touching the ground)
            if (collisionNormal.y > 0.5f) {
                currentJumps = maxJumps;
                isGrounded = true;
                animationScript.UpdateIsJumping(false);
                animationScript.UpdateIsDoubleJump(false);
                animationScript.UpdateIsSlamming(false);
            }
        }
        if (!collision.gameObject.CompareTag("BreakableGround")) {
            collisionNormal = collision.contacts[0].normal;
            if (collisionNormal.y > 0.5f) {
                isSlamming = false;
                unfreezePlayer();
            }
        }

        if(collision.gameObject.tag == "FloorLimit"){
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            gameObject.transform.position = mySpawnPoint.transform.position;
            numDeaths++;
        }

      
        
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "ColorOrb"){
            mySpawnPoint.transform.position = sprite.transform.position;
        }
        if(other.gameObject.tag == "Spikes"){
            gameObject.transform.position = mySpawnPoint.transform.position;
            numDeaths++;
        }
    }


    void OnCollisionExit(Collision collision) {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("BreakableGround")) {
            isGrounded = false;
        }
    }
    
    private IEnumerator freezePlayerTimer(float time) {
        isSlamming = true;
        freezePlayer();
        _rb.isKinematic = true;
        yield return new WaitForSecondsRealtime(time);
        _rb.isKinematic = false;
        _rb.velocity = new Vector3(0, 0, 0);
        // _rb.AddForce(Vector3.down * slamForce, ForceMode.Impulse);
        _rb.velocity = new Vector3(0f, -25f, 0f);
    }

    private IEnumerator waitForSlam() {
        yield return new WaitForEndOfFrame();
        isSlamming = false;
    }

    private IEnumerator dash() {
        canDash = false;
        isDashing = true;
        _rb.useGravity = false;
        if (isFacingRight) {
            _rb.velocity = new Vector3(dashSpeed * (Mathf.Cos(this.transform.eulerAngles.y / 180 * pi)), 0f,
                                        -dashSpeed * Mathf.Sin(this.transform.eulerAngles.y / 180 * pi));
        }
        else {
            _rb.velocity = new Vector3(-dashSpeed * (Mathf.Cos(this.transform.eulerAngles.y / 180 * pi)), 0f,
                                        dashSpeed * Mathf.Sin(this.transform.eulerAngles.y / 180 * pi));
        }
        yield return new WaitForSecondsRealtime(dashTime/3);
        _rb.drag = 5;
        yield return new WaitForSecondsRealtime(dashTime/3);
        _rb.drag = 2;
        _rb.drag = 15;
        yield return new WaitForSecondsRealtime(0.0001f);
        _rb.drag = 0;
        _rb.useGravity = true;
        yield return new WaitForSecondsRealtime(dashTime/6);
        _rb.velocity = new Vector3(0f, 0f, 0f);
        isDashing = false;
        yield return new WaitForSecondsRealtime(dashCooldown);
        canDash = true;
    }

    void freezePlayer() {
        isFrozen = true;
        _rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
    }
    void unfreezePlayer() {
        isFrozen = false;
        _rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
}
