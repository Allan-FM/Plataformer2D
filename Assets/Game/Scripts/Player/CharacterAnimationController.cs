using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character;

public static class CharacterAnimationKeys
{
    public const string IsCrouching = "IsCrouching";
    public const string HorizontalSpeed = "HorizontalSpeed";
    public const string VerticalSpeed = "VerticalSpeed";
    public const string IsGrounded = "IsGrounded";
}
public class CharacterAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterMovement2D playerMovement;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<CharacterMovement2D>();
    }

    private void Update()
    {
        animator.SetBool(CharacterAnimationKeys.IsCrouching, playerMovement.IsCrouching);
        animator.SetFloat(CharacterAnimationKeys.HorizontalSpeed, playerMovement.CurrentVelocity.x / playerMovement.MaxGroundSpeed);
        animator.SetFloat(CharacterAnimationKeys.VerticalSpeed, playerMovement.CurrentVelocity.y / playerMovement.JumpSpeed);
        animator.SetBool(CharacterAnimationKeys.IsGrounded, playerMovement.IsGrounded);
    }
}
