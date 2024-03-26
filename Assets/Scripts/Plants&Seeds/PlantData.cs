using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CardData", order = 0)]
public class PlantData : ScriptableObject
{
    [field:SerializeField]
    public string Name { get; private set; }

    [field:SerializeField]
    public int SellValue { get; private set; }
}
