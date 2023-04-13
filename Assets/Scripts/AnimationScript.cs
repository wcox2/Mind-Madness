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
    public void UpdateSpeed(float newSpeed)
    {
        animator.SetFloat("Speed", Mathf.Abs(newSpeed));

    }

    public void UpdateIsJumping(bool jumping)
    {
        animator.SetBool("IsJumping", jumping);
    }

    public void UpdateIsGrounded(bool grounded)
    {
        animator.SetBool("IsGrounded", grounded);
    }
}
