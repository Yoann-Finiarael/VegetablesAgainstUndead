using TMPro;
using UnityEngine;

/// <summary>
/// Manages the UI of the player's Health
/// </summary>
public class HealthUI : MonoBehaviour
{
    [Header("Player Health")]

    [SerializeField]
    private PlayerHealth _health;

    [Header("Health Elements")]

    [SerializeField]
    private GameObject _panelHealth;
    [SerializeField]
    private TextMeshProUGUI _textHealth;

    // Start is called before the first frame update
    void Start()
    {
        _health.HealthUpdate += UpdateHealth;
    }

    /// <summary>
    /// Updates the display of the player's health
    /// </summary>
    /// <param name="amount"></param>
    public void UpdateHealth(int amount)
    {
        _textHealth.text = $"Health : {amount}";
    }
}
