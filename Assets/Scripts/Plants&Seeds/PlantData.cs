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

    [field: Header("Plant Attack Stats")]
    [field: SerializeField]
    public int AttackDamage { get; private set; }

    [field: SerializeField]
    public float AttackRate { get; private set; }

    [field: SerializeField]
    public float AttackRange { get; private set; }
}
