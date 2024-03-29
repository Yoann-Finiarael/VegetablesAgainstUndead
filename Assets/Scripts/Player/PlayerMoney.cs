using System;
using UnityEngine;

/// <summary>
/// Manages the Money of the Player
/// </summary>
public class PlayerMoney : MonoBehaviour
{
    [SerializeField]
    private int _baseMoney = 10;

    /// <summary>
    /// The player's current money
    /// </summary>
    public int Wallet { get; private set; }

    // Event
    public event Action<int> MoneyUpdate;

    // Main
    private PlayerMain _main;

    // Start is called before the first frame update
    private void Start()
    {
        _main = GetComponent<PlayerMain>();

        Wallet = 0;
        GainMoney(_baseMoney);
    }

    /// <summary>
    /// Increases the player's money by a given amount
    /// </summary>
    /// <param name="amount"></param>
    public void GainMoney(int amount)
    {
        if (amount > 0)
        {
            Wallet += amount;

            MoneyUpdate?.Invoke(Wallet);
        }
    }

    /// <summary>
    /// Decreases the player's money by a given amount. Doesn't decrease if the amount is higher than the money
    /// </summary>
    /// <param name="amount"></param>
    public void LoseMoney(int amount)
    {
        if (Wallet >= amount && amount > 0)
        {
            Wallet -= amount;

            MoneyUpdate?.Invoke(Wallet);
        }
    }
}
