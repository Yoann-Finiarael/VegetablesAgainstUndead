using UnityEngine;

public class LandPlot : MonoBehaviour, Interactable
{
    [field: Header("Interactable")]
    [field: SerializeField]
    public string InteractText { get; private set; }

    [field: SerializeField]
    public bool IsInteractable { get; private set; }

    private Plant _plant;

    // Local use
    private SeedData _seedInHand;

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
        _plant = Instantiate(seed.Plant, transform.GetChild(0).position, Quaternion.identity).GetComponent<Plant>();
        _plant.SetPlot(this);
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
