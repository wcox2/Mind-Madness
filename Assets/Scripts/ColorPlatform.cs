using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPlatform : MonoBehaviour {
    public float fadeSpeed = 0.05f;

    void Start() {
        Color c = this.GetComponent<Renderer>().material.color;
        c.a = 0f;
        this.GetComponent<Renderer>().material.color = c;
    }


    void Update() {

    }

    void OnEnable() {
        StartCoroutine(FadeInObject());
    }

    public IEnumerator FadeInObject() {
        for (float f = fadeSpeed; f <= 1.001; f += fadeSpeed) {
            Color c = this.GetComponent<Renderer>().material.color;
            c.a = f;
            this.GetComponent<Renderer>().material.color = c;
            yield return new WaitForSecondsRealtime(fadeSpeed);
        }
    }
}
