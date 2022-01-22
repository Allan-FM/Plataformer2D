using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character;

[RequireComponent(typeof(CharacterMovement2D))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(CharacterFacing2D))]
public class PlayerController : MonoBehaviour
{
    CharacterMovement2D playerMovement;
    CharacterFacing2D playerFacing;
    PlayerInput playerInput;

    [Header("Camera")]
    [SerializeField] private Transform cameraTarget;
    [Range(0.0f, 5.0f)]
    [SerializeField] private float cameraTargetOffSetX = 2.0f;
    [Range(0.5f, 50.0f)]
    [SerializeField] private float cameraTargetFlipSpeed = 2.0f;
    [Range(0.0f, 5.0f)]
    [SerializeField] private float characterSpeedInfluence = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<CharacterMovement2D>();
        playerFacing = GetComponent<CharacterFacing2D>();
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        Vector2 movementInput = playerInput.GetMovementInput();
        playerMovement.ProcessMovementInput(movementInput);
        playerFacing.UpdateFacing(movementInput);

       
        //Jump
        if(playerInput.IsJumpButtonDown())
        {
            playerMovement.Jump();
        }
        if(playerInput.IsJumpButtonHeld() == false)
        {
            playerMovement.UpdateJumpAbort();
        }
        //Crouch
        if (playerInput.IsCrouchButtonDown())
        {
            playerMovement.Crouch();
        }
        else if(playerInput.IsCrouchButtonUp())
        {
            playerMovement.UnCrouch();
        }
    }
    private void FixedUpdate()
    {

        bool isFacingRigth = playerFacing.IsFacingRigth();
        float targetOffSetX = isFacingRigth ? cameraTargetOffSetX : -cameraTargetOffSetX;

        float currentOffSetX = Mathf.Lerp(cameraTarget.localPosition.x, targetOffSetX, Time.deltaTime * cameraTargetFlipSpeed);

        currentOffSetX += playerMovement.CurrentVelocity.x * Time.fixedDeltaTime * characterSpeedInfluence;

        cameraTarget.localPosition = new Vector3(currentOffSetX, cameraTarget.localPosition.y, cameraTarget.localPosition.z);

    }
    
}
