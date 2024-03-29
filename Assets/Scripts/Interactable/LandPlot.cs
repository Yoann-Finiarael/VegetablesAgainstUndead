using UnityEngine;

/// <summary>
/// A plot of land where seed can be placed
/// </summary>
public class LandPlot : MonoBehaviour, Interactable
{
    //Interactable
    public string InteractText { get; private set; }

    public bool IsInteractable { get; private set; }

    private Plant _plant;

    // Local use
    private SeedData _seedInHand;

    // Start
    private void Start()
    {
        InteractText = "Plant a seed";
        IsInteractable = true;
    }

    /// <summary>
    /// If the player has enough seeds in hand, plant the seed to make a plant
    /// </summary>
    /// <param name="main"></param>
    public void OnInteract(PlayerMain main)
    {
        if (main.Inventory.GetCurrentSlot() != null)
        {
            _seedInHand = main.Inventory.GetCurrentSlot().Seed;
        }

        // If the player has at least 1 seed
        if (main.Inventory.HasEnoughSeed(_seedInHand))
        {
            IsInteractable = false;
            main.Inventory.LooseSeed(main.Inventory.GetCurrentSlot().Seed);

            PlantSeed(main.Inventory.GetCurrentSlot().Seed);
        }
    }

    /// <summary>
    /// Instantiate the plant from the given seed on itself
    /// </summary>
    /// <param name="seed"></param>
    private void PlantSeed(SeedData seed)
    {
        _plant = ObjectPool.Instance.Get(seed.Plant).GetComponent<Plant>();

        _plant.SetPlot(this);

        // Give the position of the top of the land plot
        _plant.Use(transform.GetChild(0).position, transform.GetChild(0).rotation);
    }

    /// <summary>
    /// Make the LandPlot reusable again for a new plant
    /// </summary>
    public void FreePlot()
    {
        IsInteractable = true;
        _plant = null;
    }
}
