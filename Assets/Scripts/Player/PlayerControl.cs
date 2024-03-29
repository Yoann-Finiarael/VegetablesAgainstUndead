using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Manages the Inouts of the Player
/// </summary>
public class PlayerControl : MonoBehaviour
{
    // Main
    private PlayerMain _main;

    private void Start()
    {
        _main = GetComponent<PlayerMain>();
    }

    /// <summary>
    /// Called when the player changes direction. Will update the direction the player follows
    /// </summary>
    /// <param name="movement"></param>
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed || context.canceled)
        {
            _main.Movement.ChangeDirection(context.ReadValue<Vector2>().normalized);
        }
    }

    /// <summary>
    /// Called when the player moves its mouse. Will update the player's camera and interact
    /// </summary>
    /// <param name="movement"></param>
    public void OnLook(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _main.Camera.CameraUpdate(context.ReadValue<Vector2>());
        }
    }

    /// <summary>
    /// Called when the player left clicks. Calls the correct method at the start of the click
    /// </summary>
    /// <param name="context"></param>
    public void OnLeftClick(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _main.Interact.Interact();
        }
    }

    /// <summary>
    /// Called when the player scrolls. Calls the correct method at the start of the scroll
    /// </summary>
    /// <param name="context"></param>
    public void OnScroll(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            // value is either 1 or -1;
            _main.Inventory.SwitchCurrentSlot((int)context.ReadValue<Vector2>().normalized.y);
        }
    }
}
