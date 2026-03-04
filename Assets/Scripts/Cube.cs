using UnityEngine;

public class BoxFollower : MonoBehaviour
{
    public Transform cameraTransform;
    public Transform roomTransform;

    public Vector3 localPositionInCamera = new Vector3(0f, 0f, 2f);

    void Start()
    {
        localPositionInCamera = transform.position - cameraTransform.position;
    }

    void LateUpdate()
    {

        transform.position = cameraTransform.position + cameraTransform.rotation * localPositionInCamera;

        transform.rotation = roomTransform.rotation;
    }
}
