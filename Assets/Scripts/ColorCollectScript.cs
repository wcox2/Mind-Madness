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
    // public Light lightDisappear;
    

    void Start() {
        player = GameObject.FindWithTag("Player");
        sprite = player.transform.GetChild(0).gameObject;
        spriteRenderer = sprite.GetComponent<SpriteRenderer>();
        colorCollider = GetComponent<Collider>();
        playerCollider = sprite.GetComponent<Collider>();
        playerLight = player.transform.GetChild(2).GetComponent<Light>();
        thisObject = this.gameObject;
        lightAppear = this.transform.GetChild(0).GetComponent<Light>();
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
        }
    }

    void OnEnable() {
        StartCoroutine(FadeInObject());
    }

    // public IEnumerator FadeOutObject() {
    //     Color colorCollect = this.GetComponent<Renderer>().material.color;
    //     Color colorPlatform = platformDisappear.GetComponent<Renderer>().material.color;
    //     for (float f = 0; f <= 0.5501; f += fadeSpeed) {
    //         Debug.Log(colorCollect.a);
    //         lightAppear.intensity = 0.6f-f;
    //         colorCollect.a = 0.6f-f;
    //         lightDisappear.intensity = 0.6f-f;
    //         colorPlatform.a = 0.6f-f;
    //         this.GetComponent<Renderer>().material.color = colorCollect;
    //         platformDisappear.GetComponent<Renderer>().material.color = colorPlatform;
    //         yield return new WaitForSecondsRealtime(fadeSpeed);
    //     }
    //     platformDisappear.SetActive(false);
    //     thisObject.SetActive(false);
    // }

    public IEnumerator FadeOutObject() {
    Color colorCollect = this.GetComponent<Renderer>().material.color;

    for (float f = 0; f <= 0.5501; f += fadeSpeed) {
        lightAppear.intensity = 0.6f-f;
        colorCollect.a = 0.6f-f;
        foreach (Renderer childRenderer in platformDisappear.GetComponentsInChildren<Renderer>()) {
            Color childColor = childRenderer.material.color;
            childColor.a = 0.6f-f;
            childRenderer.material.color = childColor;
            // lightDisappear = childRenderer.transform.GetChild(0).GetComponent<Light>();
            // lightDisappear.intensity = 0.6f-f;
        }
        this.GetComponent<Renderer>().material.color = colorCollect;
        yield return new WaitForSecondsRealtime(fadeSpeed);
    }

    platformDisappear.SetActive(false);
    thisObject.SetActive(false);
    }

    public IEnumerator FadeInObject() {
        Debug.Log("here");
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
