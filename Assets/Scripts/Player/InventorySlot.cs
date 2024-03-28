/// <summary>
/// A slot of the Player's Inventory. Has a Seed and the Amount of seed the Player has
/// </summary>
public class InventorySlot
{
    public InventorySlot(SeedData seed, int amount)
    {
        Seed = seed;
        Amount = amount;
    }

    public SeedData Seed { get; private set; }

    public int Amount { get; private set; }

    /// <summary>
    /// Increase the Amount of the slot
    /// </summary>
    public void IncreaseAmount()
    {
        Amount += 1;
    }

    /// <summary>
    /// Decreases the Amount of the slot
    /// </summary>
    public void DecreaseAmount()
    {
        Amount -= 1;
    }
}
