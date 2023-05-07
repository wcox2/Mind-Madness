using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPlatform : MonoBehaviour {
    public float fadeSpeed = 0.05f;
    public Light light;
    private GameObject thisObject;

    void Start() {
        Color c = this.GetComponent<Renderer>().material.color;
        c.a = 0f;
        this.GetComponent<Renderer>().material.color = c;
        thisObject = this.gameObject;
        // light = this.transform.GetChild(0).GetComponent<Light>();
        // light.intensity = 0;
    }


    void Update() {

    }

    void OnEnable() {
        if (this.transform.childCount > 0) {
            light = this.transform.GetChild(0).GetComponent<Light>();
            light.intensity = 0;
        }
        StartCoroutine(FadeInObject());
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
            // this.GetComponent<Renderer>().material.color = color;
            yield return new WaitForSecondsRealtime(fadeSpeed);
        }
    }

    public IEnumerator FadeOutObject() {
        for (float f = 0; f <= 0.5501; f += fadeSpeed) {
            Color colorCollect = this.GetComponent<Renderer>().material.color;
            // Color colorPlatform = platformDisappear.GetComponent<Renderer>().material.color;
            if (this.transform.childCount > 0) {
                light.intensity = 0.55f-f;
            }
            colorCollect.a = 0.55f-f;
            // colorPlatform.a = 0.55f-f;
            this.GetComponent<Renderer>().material.color = colorCollect;
            yield return new WaitForSecondsRealtime(fadeSpeed);
        }
        thisObject.SetActive(false);
    }
}
