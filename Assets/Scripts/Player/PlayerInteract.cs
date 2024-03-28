using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    private float _interactRange = 50f;

    // Main
    private PlayerMain _main;

    // For Raycast
    private Camera _camera;

    private RaycastHit _hit;
    private LayerMask _layerInteractable;

    // Local Use
    private Interactable _currentInteract;
    private Interactable _hitInteractable;

    // Start is called before the first frame update
    private void Start()
    {
        _camera = Camera.main;
        _main = GetComponent<PlayerMain>();

        _layerInteractable = LayerMask.GetMask("Interactable");
    }

    private void Update()
    {
        InteractUpdate();
    }

    /// <summary>
    /// Detects what's in front of the player. If the element is interactable, register it.
    /// </summary>
    public void InteractUpdate()
    {
        // If an Interactable has been hit
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out _hit, _interactRange, _layerInteractable))
        {
            _hitInteractable = _hit.transform.GetComponent<Interactable>();

            // If the Interactable can be interacted with
            if (_hitInteractable.IsInteractable)
            {
                // If the Interactable is a different Interactable -> Update stuff
                if (_currentInteract != _hitInteractable)
                {
                    InteractEnd();

                    _currentInteract = _hitInteractable;

                    InteractBegin();
                }
            }
            else
            {
                InteractEnd();

                _currentInteract = null;
            }
        }

        // If no Interactables have been hit
        else
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
        if (_currentInteract != null && _currentInteract.IsInteractable)
        {
            _currentInteract.OnInteract(_main);
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
