using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;
    PlayerMovement movement;
    Rigidbody2D rb;

    int groundID;
    int hangingID;
    int crouchID;
    int speedId;
    int fallID;
    void Start()
    {
        anim = GetComponent<Animator>();
        movement = GetComponentInParent<PlayerMovement>();
        rb = GetComponentInParent<Rigidbody2D>();

        groundID = Animator.StringToHash("isOnGround");
        hangingID = Animator.StringToHash("isHanging");
        crouchID = Animator.StringToHash("isCrouching");
        speedId = Animator.StringToHash("speed");
        fallID = Animator.StringToHash("verticalVelocity");
    }

    
    void Update()
    {
        anim.SetFloat(speedId,Mathf.Abs(movement.xVelocity));
        //anim.SetBool("isOnGround", movement.isOnGround);
        anim.SetBool(groundID, movement.isOnGround);
        anim.SetBool(crouchID, movement.isCrouch);
        anim.SetBool(hangingID, movement.isHanging);
        anim.SetFloat(fallID, rb.velocity.y);
    }

    public void StepAudio() {
        AudioManager.PlayFootstepAudio();
    }
    public void CrouchStepAudio() {
        AudioManager.PlayCrouchFootstepAudio();
    }


}
