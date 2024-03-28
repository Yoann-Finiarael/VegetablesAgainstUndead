/// <summary>
/// Abstract class representing all the elements the Player can interact with
/// </summary>
public interface Interactable
{
    /// <summary>
    /// Text displayed to the player
    /// </summary>
    public string InteractText { get; }

    /// <summary>
    /// If the player can or not interact with the object
    /// </summary>
    public bool IsInteractable { get; }

    /// <summary>
    /// Called when the player interacts with the object
    /// </summary>
    /// <param name="main"></param>
    public abstract void OnInteract(PlayerMain main);
}