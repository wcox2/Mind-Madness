using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public Animator animator;

    //Animation for running

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    //Running Animation
    public void UpdateSpeed(float newSpeed)
    {
        animator.SetFloat("Speed", Mathf.Abs(newSpeed));

    }

    //Jummping Animation
    public void UpdateIsJumping(bool jumping)
    {
        animator.SetBool("IsJumping", jumping);
    }

    //Slaming Animation
    public void UpdateIsSlamming(bool slamming)
    {
        animator.SetBool("IsSlamming", slamming);
    }
}
