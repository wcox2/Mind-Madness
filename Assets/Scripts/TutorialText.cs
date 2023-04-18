using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialText : MonoBehaviour
{
    public GameObject player;
    public GameObject text;
    private Collider playerCollider;
    private Collider colorCollider;


    void Start()
    {
        colorCollider = GetComponent<Collider>();
        playerCollider = player.GetComponent<Collider>();
    }



    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            text.SetActive(true);
            Destroy(gameObject);
        }
    }
}
