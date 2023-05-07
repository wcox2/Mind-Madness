using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialText : MonoBehaviour
{
    public GameObject text;
    private Collider playerCollider;
    private Collider colorCollider;
    public GameObject sprite;
    private SpriteRenderer spriteRenderer;
    public GameObject player;


    void Start()
    {
        player = GameObject.FindWithTag("Player");

        //sprite = player.transform.GetChild(0).gameObject;
        spriteRenderer = sprite.GetComponent<SpriteRenderer>();
        colorCollider = GetComponent<Collider>();
        playerCollider = sprite.GetComponent<Collider>();
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            text.SetActive(true);
        }
    }
}
