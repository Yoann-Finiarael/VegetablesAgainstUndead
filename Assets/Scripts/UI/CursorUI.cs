using UnityEngine;

/// <summary>
/// Hides and Locks the cursor at the start of the game
/// </summary>
public class CursorUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
