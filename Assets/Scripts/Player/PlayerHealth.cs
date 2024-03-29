using System;
using UnityEngine;

/// <summary>
/// Manages the Health of the Player
/// </summary>
public class PlayerHealth : MonoBehaviour
{
    // Event
    public event Action<int> HealthUpdate;

    // Main
    private PlayerMain _main;

    [SerializeField]
    private int _health = 10;

    [SerializeField]
    private EndZone _endZone;

    // Start is called before the first frame update
    void Start()
    {
        _main = GetComponent<PlayerMain>();
        HealthUpdate?.Invoke(_health);

        _endZone.UndeadReachEnd += LoseHealth;
    }

    /// <summary>
    /// Makes the player lose a life
    /// </summary>
    public void LoseHealth()
    {
        _health -= 1;
        HealthUpdate?.Invoke(_health);
    }
}
