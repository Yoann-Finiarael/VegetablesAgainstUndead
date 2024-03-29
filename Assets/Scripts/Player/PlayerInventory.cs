using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the inventory of the Player
/// </summary>
public class PlayerInventory : MonoBehaviour
{
    public List<InventorySlot> Inventory { get; private set; }

    // Event
    public event Action<InventorySlot> InventoryUpdate;

    // Main
    private PlayerMain _main;

    // Private
    private int _currentIndex = 0;

    // Local Use
    private int _searchIndex;

    // Start is called before the first frame update
    private void Start()
    {
        _main = GetComponent<PlayerMain>();

        Inventory = new List<InventorySlot>();
    }

    /// <summary>
    /// Returns the currently selected seed in the Inventory. Returns null if the Player doesn't have a seed
    /// </summary>
    /// <returns></returns>
    public InventorySlot GetCurrentSlot()
    {
        if (Inventory.Count > 0)
        {
            return Inventory[_currentIndex];
        }

        return null;
    }

    /// <summary>
    /// Updates the current slot index based on the given parameter. The index will loop around the inventory if its end is reached
    /// </summary>
    /// <param name="switchValue">The value added to the idex</param>
    public void SwitchCurrentSlot(int switchValue)
    {
        // No need to change slot if there are no or only 1 slot
        if (Inventory.Count > 1)
        {
            _currentIndex += switchValue;

            // If negative, go to the top
            if (_currentIndex < 0)
            {
                _currentIndex += Inventory.Count;
            }

            // If positive, modulate to fit in the length
            else
            {
                _currentIndex = _currentIndex % Inventory.Count;
            }
        }

        CallUpdateInventory();
    }

    /// <summary>
    /// The Player gets a seed. Increase the seed count if he already got the seed, or creates a new slot if he didn't
    /// </summary>
    /// <param name="seed">The given seed</param>
    public void GainSeed(SeedData seed)
    {
        _searchIndex = GetIndexFromSeed(seed);

        // If the seed is registered
        if (_searchIndex > -1)
        {
            Inventory[_searchIndex].IncreaseAmount();
        }
        else
        {
            Inventory.Add(new InventorySlot(seed, 1));
        }

        CallUpdateInventory();
    }

    /// <summary>
    /// Returns if the player has ta least 1 seed in its inventory
    /// </summary>
    /// <param name="seed">The given seed</param>
    /// <returns></returns>
    public bool HasEnoughSeed(SeedData seed)
    {
        _searchIndex = GetIndexFromSeed(seed);

        // If the seed is registered
        if (_searchIndex > -1)
        {
            // Return true if there is at least 1 seed, false otherwise
            return Inventory[_searchIndex].Amount > 0;
        }

        // If the seed is not registered
        else
        {
            return false;
        }
    }

    /// <summary>
    /// The Player's seed count decrease by 1
    /// </summary>
    /// <param name="seed">The given seed</param>
    public void LooseSeed(SeedData seed)
    {
        _searchIndex = GetIndexFromSeed(seed);

        // If the seed is registered
        if (_searchIndex > -1)
        {
            // if there's at least 1 seed
            if (Inventory[_searchIndex].Amount > 0)
            {
                Inventory[_searchIndex].DecreaseAmount();
            }
        }

        CallUpdateInventory();
    }

    /// <summary>
    /// Returns the index of Inventory containing the seed. Returns -1 if the seed has not been found
    /// </summary>
    /// <param name="seed">The seed to search</param>
    /// <returns></returns>
    private int GetIndexFromSeed(SeedData seed)
    {
        for (int i = 0; i < Inventory.Count; i++)
        {
            if (Inventory[i].Seed == seed)
            {
                return i;
            }
        }

        return -1;
    }

    /// <summary>
    /// Invokes the event UpdateInventory
    /// </summary>
    private void CallUpdateInventory()
    {
        InventoryUpdate?.Invoke(GetCurrentSlot());
    }
}
