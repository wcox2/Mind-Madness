using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCollectScript : MonoBehaviour {
    public GameObject player;
    public GameObject platform;
    private Collider playerCollider;
    private Collider colorCollider;
    public bool fadeIn = false;
    public float fadeSpeed = 4f;
    


    void Start() {
        colorCollider = GetComponent<Collider>();
        playerCollider = player.GetComponent<Collider>();
    }

    void Update() {
        
    }

    void OnTriggerEnter(Collider col) {
            if (col.tag == "Player") {
                platform.SetActive(true);
                FadeInObject();
                Destroy(gameObject);
            }
        }
    
    public void FadeInObject() {
        fadeIn = true;
    }
}
