using TMPro;
using UnityEngine;

/// <summary>
/// Manages the UI of the player's inventory
/// </summary>
public class InventoryUI : MonoBehaviour
{
    [Header("Player Inventory")]

    [SerializeField]
    private PlayerInventory _inventory;

    [Header("Inventory Elements")]

    [SerializeField]
    private GameObject _panelInventory;
    [SerializeField]
    private TextMeshProUGUI _textInventoryName;
    [SerializeField]
    private TextMeshProUGUI _textInventoryCount;

    // Start is called before the first frame update
    void Start()
    {
        _inventory.InventoryUpdate += UpdateInventory;
    }

    /// <summary>
    /// Updates the Players UI based on hit selected InventorySlot
    /// </summary>
    public void UpdateInventory(InventorySlot slot)
    {
        if (slot != null)
        {
            _textInventoryName.text = slot.Seed.Name;
            _textInventoryCount.text = slot.Amount.ToString();
            _panelInventory.SetActive(true);
        }
        else
        {
            _panelInventory.SetActive(false);
        }
    }
}
