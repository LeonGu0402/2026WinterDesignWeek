using System;
using UnityEngine;

public class BoxFollower : MonoBehaviour
{
    public Transform cameraTransform;
    public Transform roomTransform;


    private Vector3 localPositionInCamera;

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
