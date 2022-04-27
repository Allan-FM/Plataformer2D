using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : CharacterAnimationController
{
    private IDamageable damageable;
    protected override void Awake()
    {
        base.Awake();
        damageable = GetComponent<IDamageable>();
        if(damageable != null)
        {
            damageable.DeathEvent += OnDeath;
        }
    }
    private void OnDestroy()
    {
        if(damageable != null)
        {
            damageable.DeathEvent -= OnDeath;
        }
    }
    protected override void Update()
    {
        base.Update();
      
        animator.SetBool(CharacterAnimationKeys.IsCrouching, characterMovement.IsCrouching);
        animator.SetFloat(CharacterAnimationKeys.VerticalSpeed, characterMovement.CurrentVelocity.y / characterMovement.JumpSpeed);
        animator.SetBool(CharacterAnimationKeys.IsGrounded, characterMovement.IsGrounded);
    }
    private void OnDeath()
    {
        animator.SetTrigger(CharacterAnimationKeys.Dead);
    }
}
