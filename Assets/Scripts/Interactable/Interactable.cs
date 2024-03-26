using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [field: SerializeField]
    public string InteractText { get; private set; }

    [field: SerializeField]
    public bool IsInteractable { get; private set; }

    public abstract void OnInteract(PlayerMain main);
}
