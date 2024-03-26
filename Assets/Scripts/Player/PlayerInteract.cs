using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    private float _interactRange = 50f;

    //Main 
    private PlayerMain _main;

    //For Raycast
    private Camera _camera;

    private RaycastHit _hit;
    private LayerMask _layerInteractable;

    //Private
    private Interactable _currentInteract;
    private Interactable _hitInteractable;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        _main = GetComponent<PlayerMain>();

        _layerInteractable = LayerMask.GetMask("Interactable");
    }

    /// <summary>
    /// Detects what's in front of the player. If the element is interactable, register it.
    /// </summary>
    public void InteractUpdate()
    {
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out _hit, _interactRange, _layerInteractable))   //If an Interactable has been hit
        {
            _hitInteractable = _hit.transform.GetComponent<Interactable>();

            if (_currentInteract != _hitInteractable)
            {
                InteractEnd();

                _currentInteract = _hitInteractable;

                InteractBegin();
            }
        }
        else    //If no Interactables have been hit
        {
            InteractEnd();

            _currentInteract = null;
        }
    }

    /// <summary>
    /// Interacts with the current interactable. Does nothing if the current interactable is null
    /// </summary>
    public void Interact()
    {
        if (_currentInteract != null)
        {
            Debug.Log("I interact with " + _currentInteract.name);
        }
    }

    /// <summary>
    /// Prepares the player's interaction with the current interactable 
    /// </summary>
    private void InteractBegin()
    {
        _main.UI.ShowInteract(_currentInteract.InteractText);
    }

    /// <summary>
    /// Cleans up the player's interaction with the current interactable to prepare for the next interactable
    /// </summary>
    private void InteractEnd()
    {
        _main.UI.HideInteract();
    }
}
