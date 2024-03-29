using TMPro;
using UnityEngine;

/// <summary>
/// Manages the UI of the player's interaction
/// </summary>
public class InteractUI : MonoBehaviour
{
    [Header("Player Interact")]

    [SerializeField]
    private PlayerInteract _interact;

    [Header("Interact Elements")]

    [SerializeField]
    private GameObject _panelInteract;
    [SerializeField]
    private TextMeshProUGUI _textInteract;

    // Start is called before the first frame update
    void Start()
    {
        _panelInteract.SetActive(false);

        _interact.BeginInteract += ShowInteract;
        _interact.EndInteract += HideInteract;
    }

    /// <summary>
    /// Shows and updates the Interact Text
    /// </summary>
    /// <param name="textInteract">The text displayed in the interact text</param>
    public void ShowInteract(string textInteract)
    {
        _panelInteract.SetActive(true);
        _textInteract.text = textInteract;
    }

    /// <summary>
    /// Hides the InteractText
    /// </summary>
    public void HideInteract()
    {
        _panelInteract.SetActive(false);
    }
}
