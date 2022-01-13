using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerInput : MonoBehaviour
{
    private struct PlayerInputConstants
    {
        public const string Horizontal = "Horizontal";
        public const string Vertical = "Vertical";
        public const string Jump = "Jump";
    }
    public Vector2 GetMovementInput()
    {
        //Tecaldo
        float horizontalInput = Input.GetAxisRaw(PlayerInputConstants.Horizontal);

        if(Mathf.Approximately(horizontalInput, 0.0f))
        {
            horizontalInput = CrossPlatformInputManager.GetAxisRaw(PlayerInputConstants.Horizontal);
        }
        return new Vector2(horizontalInput, 0);
    }
    public bool IsJumpButtonDown()
    {
        bool IsKeyBoardButtonDown = Input.GetKeyDown(KeyCode.Space);
        bool IsMobileButtonDown = CrossPlatformInputManager.GetButtonDown(PlayerInputConstants.Jump);

        return IsKeyBoardButtonDown || IsMobileButtonDown;
        
    }
    public bool IsJumpButtonHeld()
    {
        bool IsKeyBoardButtonHeld = Input.GetKey(KeyCode.Space);
        bool IsMobileButtonHeld = CrossPlatformInputManager.GetButton(PlayerInputConstants.Jump);

        return IsKeyBoardButtonHeld || IsMobileButtonHeld;
    }
    public bool IsCrouchButtonDown()
    {
        bool IsKeyBoardButtonDown = Input.GetKeyDown(KeyCode.S);
        bool IsMobileButtonDown = CrossPlatformInputManager.GetAxisRaw(PlayerInputConstants.Vertical) < 0;
        return IsKeyBoardButtonDown || IsMobileButtonDown;
    }
    public bool IsCrouchButtonUp()
    {
        bool IsKeyBoardUp = Input.GetKey(KeyCode.S) == false;
        bool IsMobileButtonUp = CrossPlatformInputManager.GetAxisRaw(PlayerInputConstants.Vertical) >= 0;
        return IsKeyBoardUp && IsMobileButtonUp;
    }
}
