using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialText : MonoBehaviour
{
    public GameObject platform;
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        if (platform.activeInHierarchy)
        {
            text.SetActive(true);
            yield return new WaitForSecondsRealtime(4f);

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
