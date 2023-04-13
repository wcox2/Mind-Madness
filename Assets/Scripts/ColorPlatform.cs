using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPlatform : MonoBehaviour {
    public float fadeSpeed = 0.05f;
    public Light light;

    void Start() {
        Color c = this.GetComponent<Renderer>().material.color;
        c.a = 0f;
        this.GetComponent<Renderer>().material.color = c;
        // light = this.transform.GetChild(0).GetComponent<Light>();
        // light.intensity = 0;
    }


    void Update() {

    }

    void OnEnable() {
        light = this.transform.GetChild(0).GetComponent<Light>();
        light.intensity = 0;
        StartCoroutine(FadeInObject());
    }

    public IEnumerator FadeInObject() {
        for (float f = 0; f <= 1.001; f += fadeSpeed) {
            Color color = this.GetComponent<Renderer>().material.color;
            color.a = f;
            light.intensity = f;
            this.GetComponent<Renderer>().material.color = color;
            yield return new WaitForSecondsRealtime(fadeSpeed);
        }
    }
}
