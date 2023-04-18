using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCollectScript : MonoBehaviour {
    public GameObject platform;
    private Collider playerCollider;
    private Collider colorCollider;
    public Light playerLight;
    public GameObject sprite;
    private SpriteRenderer spriteRenderer;
    public GameObject player;
    public int colorSelect = 0;
    public GameObject thisObject;
    public float fadeSpeed = 0.01f;
    public Light light;
    

    void Start() {
        player = GameObject.FindWithTag("Player");
        sprite = player.transform.GetChild(0).gameObject;
        spriteRenderer = sprite.GetComponent<SpriteRenderer>();
        colorCollider = GetComponent<Collider>();
        playerCollider = sprite.GetComponent<Collider>();
        playerLight = player.transform.GetChild(2).GetComponent<Light>();
        thisObject = this.gameObject;
        light = this.transform.GetChild(0).GetComponent<Light>();
    }

    void Update() {
        
    }

    void OnTriggerEnter(Collider col) {
        if (colorSelect == 1) {
            playerLight.color = Color.red;
            spriteRenderer.color = new Color(1f, 0.45f, 0.45f, 1f);
        }
<<<<<<< HEAD
=======
        else if (colorSelect == 2) {
            playerLight.color = Color.green;
            spriteRenderer.color = Color.green;
        }
        else if (colorSelect == 3) {
            playerLight.color = Color.blue;
            spriteRenderer.color = Color.blue;
        }
>>>>>>> main
        if (col.tag == "Player") {
            StartCoroutine(FadeOutObject());
            platform.SetActive(true);
        }
    }

    public IEnumerator FadeOutObject() {
        for (float f = fadeSpeed; f <= 1.001; f += fadeSpeed) {
            Color color = this.GetComponent<Renderer>().material.color;
            light.intensity = 1-f;
            color.a = 1-f;
            Debug.Log(color.a);
            this.GetComponent<Renderer>().material.color = color;
            yield return new WaitForSecondsRealtime(fadeSpeed);
        }
        thisObject.SetActive(false);
    }
}
