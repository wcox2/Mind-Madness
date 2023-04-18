using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundScript : MonoBehaviour {
    private PlayerMovement playerScript;
    private GameObject player;


    void Start() {
        player = this.transform.parent.gameObject;
        playerScript = player.GetComponent<PlayerMovement>();
    }

    void Update() {
        
    }

    void OnCollisionEnter(Collision collision) {
        Debug.Log("hit!");
        if (collision.gameObject.CompareTag("Ground")) {
            Debug.Log("hit!");
            playerScript.currentJumps = playerScript.maxJumps;
            playerScript.isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            playerScript.isGrounded = false;
        }
    }
}
