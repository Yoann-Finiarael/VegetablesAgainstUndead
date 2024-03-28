using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField]
    private float _playerSpeed;

    // Main
    private PlayerMain _main;

    // Movement
    private Rigidbody _rb;

    private Vector2 _direction;
    private Vector3 _move;

    // Start is called before the first frame update
    private void Start()
    {
        _main = GetComponent<PlayerMain>();
        _rb = GetComponent<Rigidbody>();

        _rb.drag = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        _move = (transform.forward * _direction.y + transform.right * _direction.x) * _playerSpeed;
        _rb.velocity = _move;
    }

    /// <summary>
    /// Called when the player changes direction. Will update the direction the player follows
    /// </summary>
    /// <param name="movement"></param>
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed || context.canceled)
        {
            _direction = context.ReadValue<Vector2>().normalized;
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
            Debug.Log((int)context.ReadValue<Vector2>().normalized.y);

            // value is either 1 or -1;
            _main.Inventory.SwitchCurrentSlot((int)context.ReadValue<Vector2>().normalized.y);
        }
    }
}
