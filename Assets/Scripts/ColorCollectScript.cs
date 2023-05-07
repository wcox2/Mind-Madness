using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCollectScript : MonoBehaviour {
    public GameObject platformAppear;
    public GameObject platformDisappear;
    private Collider playerCollider;
    private Collider colorCollider;
    public Light playerLight;
    public GameObject sprite;
    private SpriteRenderer spriteRenderer;
    public GameObject player;
    public int colorSelect = 0;
    private GameObject thisObject;
    public float fadeSpeed = 0.01f;
    public Light lightAppear;
    public GameObject allColorCollects;

    [SerializeField] private AudioSource collectSound;


    void Start() {
        player = GameObject.FindWithTag("Player");
        // sprite = player.transform.GetChild(0).gameObject;
        spriteRenderer = sprite.GetComponent<SpriteRenderer>();
        colorCollider = GetComponent<Collider>();
        playerCollider = sprite.GetComponent<Collider>();
        // playerLight = player.transform.GetChild(2).GetComponent<Light>();
        thisObject = this.gameObject;
        // lightAppear = this.transform.GetChild(0).GetComponent<Light>();
    }

    void Update() {
        
    }

    void OnTriggerEnter(Collider col) {
        if (colorSelect == 1) {
            playerLight.color = Color.red;
            spriteRenderer.color = new Color(1f, 0.45f, 0.45f, 1f);
        }
        else if (colorSelect == 2) {
            playerLight.color = Color.green;
            spriteRenderer.color = new Color(0.45f, 1f, 0.45f, 1f);
        }
        else if (colorSelect == 3) {
            playerLight.color = Color.blue;
            spriteRenderer.color = new Color(0.45f, 0.45f, 1f, 1f);;
        }
        if (col.tag == "Player") {
            StartCoroutine(FadeOutObject());
            for (int i = 0; i < allColorCollects.transform.childCount; i++) {
                GameObject child = allColorCollects.transform.GetChild(i).gameObject;
                if (child.activeSelf == false) {
                    child.SetActive(true);
                }
            }
            platformAppear.SetActive(true);
            collectSound.Play();
        }
    }

    void OnEnable() {
        StartCoroutine(FadeInObject());
    }

    public IEnumerator FadeOutObject() {
    Color colorCollect = this.GetComponent<Renderer>().material.color;


    for (float f = 0; f <= 0.451; f += fadeSpeed) {
        lightAppear.intensity = 0.45f-f;
        colorCollect.a = 0.45f-f;
        
        foreach (Renderer childRenderer in platformDisappear.GetComponentsInChildren<Renderer>()) {
            Material[] materials = childRenderer.GetComponent<Renderer>().materials;
            Color color;
            foreach (Material material in materials) {
                color = material.color;
                color.a = 0.45f - f;
                material.color = color;
            }
        }
        this.GetComponent<Renderer>().material.color = colorCollect;
        yield return new WaitForSecondsRealtime(fadeSpeed);
    }

    platformDisappear.SetActive(false);
    thisObject.SetActive(false);
    }

    public IEnumerator FadeInObject() {
        Material[] materials = this.GetComponent<Renderer>().materials;
        for (float f = 0; f <= 1.001; f += fadeSpeed) {
            Color color;
            foreach (Material material in materials) {
                color = material.color;
                color.a = f;
                material.color = color;
            }
            if (this.transform.childCount > 0) {
                this.transform.GetChild(0).GetComponent<Light>().intensity = f;
            }
            yield return new WaitForSecondsRealtime(fadeSpeed);
        }
    }
}
