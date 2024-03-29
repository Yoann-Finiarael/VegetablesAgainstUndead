using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Undead", order = 2)]
public class UndeadData : ScriptableObject
{
    [field: Header("Undead Stats")]

    [field: SerializeField]
    public int HP { get; private set; }

    [field: SerializeField]
    public float MovementSpeed { get; private set; }
}
