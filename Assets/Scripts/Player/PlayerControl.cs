using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField]
    private float _playerSpeed;

    //Main
    private PlayerMain _main;

    //Movement
    private Rigidbody _rb;

    private Vector2 _direction;
    private Vector3 _move;

    // Start is called before the first frame update
    void Start()
    {
        _main = GetComponent<PlayerMain>();
        _rb = GetComponent<Rigidbody>();

        _rb.drag = 5;
    }

    // Update is called once per frame
    void Update()
    {
        _move = (transform.forward * _direction.y + transform.right * _direction.x) * _playerSpeed;
        _rb.velocity = _move;
    }


    /// <summary>
    /// Called when the player changes direction. Will update the direction the player follows
    /// </summary>
    /// <param name="movement"></param>
    public void OnMove(InputValue movement)
    {
        _direction = movement.Get<Vector2>().normalized;
    }

    /// <summary>
    /// Called when the player moves its mouse. Will update the player's camera and interact
    /// </summary>
    /// <param name="movement"></param>
    public void OnLook(InputValue movement)
    {
        _main.Camera.CameraUpdate(movement.Get<Vector2>());
        _main.Interact.InteractUpdate();
    }

    public void OnLeftClick()
    {
        _main.Interact.Interact();
    }
}
