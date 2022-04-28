﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character;

public static class CharacterAnimationKeys
{
    public const string IsCrouching = "IsCrouching";
    public const string HorizontalSpeed = "HorizontalSpeed";
    public const string VerticalSpeed = "VerticalSpeed";
    public const string IsGrounded = "IsGrounded";
    public const string Dead = "Dead";
    public const string IsAttacking = "IsAttacking";
}

public static class EnemyAnimationKeys
{
    public const string IsChacing = "IsChacing";
}
public class CharacterAnimationController : MonoBehaviour
{
    private IDamageable damageable;
    protected Animator animator;
    protected CharacterMovement2D characterMovement;


    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        characterMovement = GetComponent<CharacterMovement2D>();
        damageable = GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.DeathEvent += OnDeath;
        }
    }
    private void OnDestroy()
    {
        if (damageable != null)
        {
            damageable.DeathEvent -= OnDeath;
        }
    }

    protected virtual void Update()
    {
        animator.SetFloat(CharacterAnimationKeys.HorizontalSpeed, characterMovement.CurrentVelocity.x / characterMovement.MaxGroundSpeed);
    }
    private void OnDeath()
    {
        animator.SetTrigger(CharacterAnimationKeys.Dead);
    }
}
