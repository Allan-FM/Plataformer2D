using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : CharacterAnimationController
{
    protected override void Update()
    {
        base.Update();
      
        animator.SetBool(CharacterAnimationKeys.IsCrouching, characterMovement.IsCrouching);
        animator.SetFloat(CharacterAnimationKeys.VerticalSpeed, characterMovement.CurrentVelocity.y / characterMovement.JumpSpeed);
        animator.SetBool(CharacterAnimationKeys.IsGrounded, characterMovement.IsGrounded);
    }
}
