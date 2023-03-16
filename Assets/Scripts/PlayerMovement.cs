using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private float pi = Mathf.PI;
    public float movementSpeed = 5f;
    public float jumpVelocity = 5f;
    public float dashSpeed = 5f;
    public float dashTime = 0.5f;
    public float dashCooldown = 0.5f;
    private bool canDash = true;
    private bool isDashing = false;
    public float slamForce = 20f;
    public float slamFreezeTime = 1f;
    private bool isSlamming = false;
    private bool isFrozen = false;
    private float hInput;
    public float speed;
    private Rigidbody _rb;
    enum playerAction {jump};


    // Start is called before the first frame update
    void Start() {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {


        // Jump
        if(Input.GetKeyDown(KeyCode.W) && (isFrozen == false) && (isDashing == false)) {
                _rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
                _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
            }

        // Dash
        if(Input.GetKeyDown(KeyCode.Space) && (isFrozen == false) && (canDash)) { 
            StartCoroutine(dash());
        }

        // Downslam
        if(Input.GetKeyDown(KeyCode.S) && (isFrozen == false)) {
            StartCoroutine(freezePlayerTimer(slamFreezeTime));
        }

        // Left Rotate
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            Quaternion startRotation = Camera.main.transform.rotation;
            Quaternion endRotation = startRotation *= Quaternion.Euler(0,90,0);
            float rotateSpeed = 5.0f;
            Quaternion slowRotateLeft = Quaternion.Lerp(startRotation, endRotation, rotateSpeed);
            //transform.rotation = slowRotateLeft;
            transform.Rotate(0, -speed * Time.deltaTime, 0);
        }

        // Right Rotate
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            Quaternion startRotation = Camera.main.transform.rotation;
            Quaternion endRotation = startRotation *= Quaternion.Euler(0,-90,0);
            float rotateSpeed = 5.0f;
            Quaternion slowRotateLeft = Quaternion.Lerp(startRotation, endRotation, rotateSpeed);
            //transform.rotation = slowRotateLeft;
            transform.Rotate(0, -speed * Time.deltaTime, 0);
        }


        hInput = Input.GetAxis("Horizontal") * movementSpeed;
    }


    void FixedUpdate() {
        if ((isFrozen == false) && (isDashing == false)) {
            _rb.MovePosition(this.transform.position + this.transform.right * hInput * Time.fixedDeltaTime);
        }
    }
    
    private IEnumerator freezePlayerTimer(float time) {
        freezePlayer();
        yield return new WaitForSecondsRealtime(time);
        _rb.isKinematic = false;
        _rb.velocity = new Vector3(0, 0, 0);
        _rb.AddForce(Vector3.down * slamForce, ForceMode.Impulse);
        isFrozen = false;
    }

    private IEnumerator dash() {
        canDash = false;
        isDashing = true;
        _rb.drag = 4;
        _rb.useGravity = false;
        _rb.velocity = new Vector3(dashSpeed, 0f, 0f);
        yield return new WaitForSecondsRealtime(dashTime);
        _rb.drag = 1;
        isDashing = false;
        _rb.useGravity = true;
        yield return new WaitForSecondsRealtime(dashCooldown);
        canDash = true;
    }

    void freezePlayer(){
        isFrozen = true;
        _rb.isKinematic = true;
    }
}
