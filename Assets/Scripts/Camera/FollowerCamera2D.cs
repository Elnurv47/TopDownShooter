using UnityEngine;

public class FollowerCamera2D : MonoBehaviour
{
    private const int CAMERA_Z_CONSTANT = -10;

    private Camera mainCamera;

    [SerializeField] private Transform target;

    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        mainCamera.transform.position =
            new Vector3(target.position.x, target.position.y, CAMERA_Z_CONSTANT);
    }
}
