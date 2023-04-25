using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    //public Animator animator;
    public AnimationScript animationScript;
    private int orbsCollected = 0;

    // Start is called before the first frame update
    void Start() {
        sprite = this.transform.GetChild(0).gameObject;
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {


        // Jump
        if(Input.GetKeyDown(KeyCode.W) && (isFrozen == false) && (isDashing == false) && (currentJumps > 0)) {
            _rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
            currentJumps--;
        }

        // Dash
        if(Input.GetKeyDown(KeyCode.Space) && (isFrozen == false) && (canDash)) { 
            StartCoroutine(dash());
        }

        // Downslam
        if(Input.GetKeyDown(KeyCode.S) && (isFrozen == false) && (isGrounded == false)) {
            StartCoroutine(freezePlayerTimer(slamFreezeTime));
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
        //animationScript.UpdateSpeed(hInput);
    }


    void FixedUpdate() {
        if ((isFrozen == false) && (isDashing == false)) {
            _rb.MovePosition(this.transform.position + this.transform.right * hInput * Time.fixedDeltaTime);
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (isSlamming) {
            StartCoroutine(waitForSlam());
        }
        if (collision.gameObject.CompareTag("Ground")) {  
            Vector3 collisionNormal = collision.contacts[0].normal;
            // Check if the collision normal is pointing up (i.e. the bottom of the player is touching the ground)
            if (collisionNormal.y > 0.5f) {
                currentJumps = maxJumps;
                isGrounded = true;
            }
        }

        if(collision.gameObject.tag == "FloorLimit"){
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            gameObject.transform.position = mySpawnPoint.transform.position;
        }

      
        
    }

    void OnTriggerEnter(Collider other){
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag == "ColorOrb"){
            Debug.Log("here");
            mySpawnPoint.transform.position = sprite.transform.position;
        }
    }


    void OnCollisionExit(Collision collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            Debug.Log("left Ground");
            isGrounded = false;
        }
    }
    
    private IEnumerator freezePlayerTimer(float time) {
        isSlamming = true;
        freezePlayer();
        yield return new WaitForSecondsRealtime(time);
        _rb.isKinematic = false;
        _rb.velocity = new Vector3(0, 0, 0);
        _rb.AddForce(Vector3.down * slamForce, ForceMode.Impulse);
        isFrozen = false;
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
        _rb.isKinematic = true;
    }
}
