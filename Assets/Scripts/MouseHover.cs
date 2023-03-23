using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Renderer.material.color = Color.white;
    }

    private void OnMouseEnter()
    {
        //Renderer.material.color = Color.grey;
    }

    private void OnMouseExit()
    {
        //Renderer.material.color = Color.white;
    }
}