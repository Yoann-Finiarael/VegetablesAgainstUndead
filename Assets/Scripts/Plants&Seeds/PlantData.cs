using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Plant", order = 0)]
public class PlantData : ScriptableObject
{
    [field: Header("Plant Stats")]
    [field:SerializeField]
    public string Name { get; private set; }

    [field: SerializeField]
    public float GrowTime { get; private set; }

    [field:SerializeField]
    public int SellValue { get; private set; }

    [field: Header("Prefab")]
    [field: SerializeField]
    public GameObject PlantPrefab { get; private set; }
}
