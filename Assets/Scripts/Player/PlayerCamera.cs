using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [Header("Camera Stats")]
    [SerializeField]
    private Vector2 _cameraSensitivity;

    [SerializeField]
    private GameObject _cameraObject;

    [SerializeField]
    private Transform _cameraRoot;

    //Main
    private PlayerMain _main;

    //Local variable replacement
    private Vector2 rotation;

    private void Start()
    {
        _main = GetComponent<PlayerMain>();
    }


    // Update is called once per frame
    void Update()
    {
        _cameraObject.transform.position = _cameraRoot.transform.position;
    }

    //Inspired from video : https://www.youtube.com/watch?v=f473C43s8nE
    /// <summary>
    /// Updates the rotation of the camera and the player from the delta mouvement of the mouse
    /// </summary>
    /// <param name="movement"></param>
    public void CameraUpdate(Vector2 movement)
    {
        rotation.y += movement.x * Time.deltaTime * _cameraSensitivity.x;
        rotation.x = Mathf.Clamp(rotation.x -= movement.y * Time.deltaTime * _cameraSensitivity.y, -90f, 90f);

        _cameraObject.transform.rotation = Quaternion.Euler(rotation.x, rotation.y, 0);
        transform.rotation = Quaternion.Euler(0, rotation.y, 0);
    }
}
