using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Seed", order = 1)]
public class SeedData : ScriptableObject
{
    [field: SerializeField]
    public string Name { get; private set; }

    [field: SerializeField]
    public int Cost { get; private set; }

    [field: Header("Prefab")]
    [field: SerializeField]
    public GameObject Plant { get; private set; }
}
