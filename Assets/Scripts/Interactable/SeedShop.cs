using UnityEngine;

/// <summary>
/// A shop for a single seed
/// </summary>
public class SeedShop : MonoBehaviour, Interactable
{
    public string InteractText { get; private set; }

    public bool IsInteractable { get; private set; }

    [SerializeField]
    private SeedData _seedInSale;

    // Start is called before the first frame update
    private void Start()
    {
        InteractText = $"Buy {_seedInSale.Name} for {_seedInSale.Cost} coins";

        IsInteractable = true;
    }

    /// <summary>
    /// Give a seed to the player if he has enough coins for it
    /// </summary>
    /// <param name="main"></param>
    public void OnInteract(PlayerMain main)
    {
        if (main.Money.Wallet >= _seedInSale.Cost)
        {
            main.Inventory.GainSeed(_seedInSale);
            main.Money.LoseMoney(_seedInSale.Cost);
        }
    }
}
