using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCollectScript : MonoBehaviour {
    public GameObject player;
    public GameObject platform;
    private Collider playerCollider;
    private Collider colorCollider;
    public Light playerLight;
    public GameObject sprite;
    private SpriteRenderer spriteRenderer;
    

    void Start() {
        // playerLight = player.transform.GetChild(2).gameObject;
        spriteRenderer = sprite.GetComponent<SpriteRenderer>();
        colorCollider = GetComponent<Collider>();
        playerCollider = player.GetComponent<Collider>();
    }

    void Update() {
        
    }

    void OnTriggerEnter(Collider col) {
        playerLight.color = Color.red;
        // Color newColor = new Color(1.0f, 0.5f, 0.0f, 1.0f);
        spriteRenderer.color = new Color(1f, 0.45f, 0.45f, 1f);
        if (col.tag == "Player") {
            platform.SetActive(true);
            Destroy(gameObject);
        }
    }
}
