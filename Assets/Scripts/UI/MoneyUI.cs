using TMPro;
using UnityEngine;

/// <summary>
/// Manages the UI of the player's money
/// </summary>
public class MoneyUI : MonoBehaviour
{
    [Header("Player Money")]

    [SerializeField]
    private PlayerMoney _money;

    [Header("Money Elements")]

    [SerializeField]
    private GameObject _panelMoney;
    [SerializeField]
    private TextMeshProUGUI _textMoney;

    // Start is called before the first frame update
    void Start()
    {
        _money.MoneyUpdate += UpdateMoney;
    }

    /// <summary>
    /// Updates the display of the player's coins
    /// </summary>
    /// <param name="amount"></param>
    public void UpdateMoney(int amount)
    {
        _textMoney.text = $"Coins : {amount}";
    }
}
