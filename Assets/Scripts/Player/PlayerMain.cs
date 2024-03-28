using UnityEngine;

/// <summary>
/// The Player's Main. Contains a reference to all of the Player's scripts.
/// </summary>
public class PlayerMain : MonoBehaviour
{
    // All Player Components
    public PlayerControl Control { get; private set; }

    public PlayerCamera Camera { get; private set; }

    public PlayerInteract Interact { get; private set; }

    public PlayerUI UI { get; private set; }

    public PlayerInventory Inventory { get; private set; }

    public PlayerMoney Money { get; private set; }

    // Start is called before the first frame update
    private void Awake()
    {
        Control = GetComponent<PlayerControl>();
        Camera = GetComponent<PlayerCamera>();
        Interact = GetComponent<PlayerInteract>();
        UI = GetComponent<PlayerUI>();
        Inventory = GetComponent<PlayerInventory>();
        Money = GetComponent<PlayerMoney>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
