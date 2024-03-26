using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    //All Player Components
    public PlayerControl Control { get; private set; }
    public PlayerCamera Camera { get; private set; }
    public PlayerInteract Interact { get; private set; }
    public PlayerUI UI { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Control = GetComponent<PlayerControl>();    
        Camera = GetComponent<PlayerCamera>();
        Interact = GetComponent<PlayerInteract>();
        UI = GetComponent<PlayerUI>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
