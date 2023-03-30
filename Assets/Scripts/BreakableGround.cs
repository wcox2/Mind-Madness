using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableGround : MonoBehaviour {
    private Collider groundCollider;
    private Collider spriteCollider;
    public GameObject sprite;
    public GameObject player;
    private PlayerMovement playerScript;
    public ParticleSystem blockDestroyParticle;



    void Start() {
        groundCollider = GetComponent<Collider>();
        spriteCollider = sprite.GetComponent<Collider>();
        playerScript = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnCollisionEnter(Collision col) {
        if ((col.gameObject.tag == "Player") && (playerScript.isSlamming)) {
            Instantiate(blockDestroyParticle.gameObject, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
