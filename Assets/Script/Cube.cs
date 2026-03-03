using UnityEngine;

public class BoxFollower : MonoBehaviour
{
    public Transform cameraTransform;
    public Transform roomTransform;

    public float distanceFromCamera = 2f;

    void LateUpdate()
    {
        
        transform.position = cameraTransform.position + cameraTransform.forward * distanceFromCamera;

        transform.rotation = roomTransform.rotation;
    }
}
