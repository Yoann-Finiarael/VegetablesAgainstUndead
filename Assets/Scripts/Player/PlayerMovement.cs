using UnityEngine;

/// <summary>
/// Manages the movement of the Player
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField]
    private float _playerSpeed;

    // Main
    private PlayerMain _main;

    // Private
    private Rigidbody _rb;

    private Vector2 _direction;
    private Vector3 _move;

    // Start is called before the first frame update
    private void Start()
    {
        _main = GetComponent<PlayerMain>();
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _move = (transform.forward * _direction.y + transform.right * _direction.x) * _playerSpeed;
        _rb.velocity = _move;
    }

    /// <summary>
    /// Changes the direction the player is heading
    /// </summary>
    /// <param name="direction"></param>
    public void ChangeDirection(Vector2 direction)
    {
        _direction = direction;
    }
}
