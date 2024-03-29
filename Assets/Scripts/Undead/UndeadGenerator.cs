using System.Collections;
using UnityEngine;

public class UndeadGenerator : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField]
    private GameObject _undeadPrefab;

    [Header("Spawner Stats")]
    [SerializeField]
    private float _spawnDelay;

    [Header("Difficulty Stats (per spawn)")]
    [SerializeField]
    private float _spawnDelayIncrement;

    // Local use
    private Undead _undead;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(SpawnCycle());
    }

    /// <summary>
    /// Permanantly spawns Undead
    /// </summary>
    /// <returns></returns>
    private IEnumerator SpawnCycle()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnDelay);

            SpawnUndead();
            IncreaseDifficulty();
        }
    }

    /// <summary>
    /// Spawns an Undead from the ObjectPool
    /// </summary>
    private void SpawnUndead()
    {
        _undead = ObjectPool.Instance.Get(_undeadPrefab).GetComponent<Undead>();

        Debug.Log($"I spawn {_undead.name}");

        _undead.Use(transform.position, transform.rotation);
    }

    /// <summary>
    /// Gradually decreases the spawn rate, increasing the difficulty
    /// </summary>
    private void IncreaseDifficulty()
    {
        if (_spawnDelay > 1)
        {
            _spawnDelay -= _spawnDelayIncrement;
        }
    }
}
