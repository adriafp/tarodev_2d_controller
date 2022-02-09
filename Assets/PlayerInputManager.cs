using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour, InputMaster.IPlayerActions
{
    public bool jumpButtonDown = false;
    public bool jumpButtonUp = false;
    public float X;
    
    private InputMaster _controls;
    public void OnEnable()
    {
        if (_controls == null)
        {
            _controls = new InputMaster();
            // Tell the "gameplay" action map that we want to get told about
            // when actions get triggered.
            _controls.Player.SetCallbacks(this);
        }
        _controls.Player.Enable();
    }

    public void OnDisable()
    {
        _controls.Player.Disable();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log(context.performed);
        Debug.Log(context.canceled);
        Debug.Log(context.started);
        if (context.started)
        {
            jumpButtonDown = true;
            jumpButtonUp = false;
        }

        if (context.canceled)
        {
            jumpButtonDown = false;
            jumpButtonUp = true;
        }
        
        Debug.Log(jumpButtonDown);
        Debug.Log(jumpButtonUp);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // Debug.Log(context.performed);
        // Debug.Log(context.canceled);
        // Debug.Log(context.started);
        // Debug.Log(context.action.ReadValue<Vector2>());
        X = context.action.ReadValue<Vector2>().x;
    }
    
}