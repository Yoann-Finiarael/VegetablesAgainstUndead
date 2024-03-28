using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    // Main
    private PlayerMain _main;

    [Header("Interact Elements")]

    [SerializeField]
    private GameObject _panelInteract;
    [SerializeField]
    private TextMeshProUGUI _textInteract;

    [Header("Inventory Elements")]

    [SerializeField]
    private GameObject _panelInventory;
    [SerializeField]
    private TextMeshProUGUI _textInventoryName;
    [SerializeField]
    private TextMeshProUGUI _textInventoryCount;

    [Header("Money Elements")]

    [SerializeField]
    private GameObject _panelMoney;
    [SerializeField]
    private TextMeshProUGUI _textMoney;

    // Local Use
    private InventorySlot _slot;

    // Start is called before the first frame update
    private void Start()
    {
        _main = GetComponent<PlayerMain>();

        _panelInteract.SetActive(false);

        _panelInventory.SetActive(false);
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

    /// <summary>
    /// Updates the Players UI based on hit selected InventorySlot
    /// </summary>
    public void UpdateInventory()
    {
        _slot = _main.Inventory.GetCurrentSlot();

        if (_slot != null)
        {
            _textInventoryName.text = _slot.Seed.Name;
            _textInventoryCount.text = _slot.Amount.ToString();
            _panelInventory.SetActive(true);
        }
        else
        {
            _panelInventory.SetActive(false);
        }
    }

    public void UpdateMoney(int amount)
    {
        _textMoney.text = $"Coins : {amount}";
    }
}
