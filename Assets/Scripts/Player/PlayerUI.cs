using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    //Main
    private PlayerMain _main;

    [Header("UI Elements")]

    //InteractElements
    [SerializeField]
    private GameObject _panelInteract;
    [SerializeField]
    private TextMeshProUGUI _textInteract;

    // Start is called before the first frame update
    void Start()
    {
        _main = GetComponent<PlayerMain>();

        _panelInteract.SetActive(false);
    }


    public void ShowInteract(string textInteract)
    {
        _panelInteract.SetActive(true);
        _textInteract.text = textInteract;
    }

    public void HideInteract()
    {
        _panelInteract.SetActive(false);
    }
}
