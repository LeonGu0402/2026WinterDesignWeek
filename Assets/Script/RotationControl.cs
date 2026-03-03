using UnityEngine;

public class RotationControl : MonoBehaviour
{
    public GameObject map;
    public float rotationStep;

    private float reverseRotationStep;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        reverseRotationStep = 0 - rotationStep;
    }

    // Update is called once per frame
    void Update()
    {
        RotationLogic();
    }

    private void FixedUpdate()
    {
        
    }


    public void RotationLogic()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            ObjectRotationZaxis(rotationStep);
        }

        if (Input.GetKey(KeyCode.E))
        {

            ObjectRotationZaxis(reverseRotationStep);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            ObjectRotationXaxis(rotationStep);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            ObjectRotationXaxis(reverseRotationStep);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            ObjectRotationYaxis(reverseRotationStep);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            ObjectRotationYaxis(rotationStep);
        }

    }



    public void ObjectRotationXaxis(float step)
    {
        Vector3 rotation = map.transform.localEulerAngles;
        rotation.x += step * Time.deltaTime;
        map.transform.localEulerAngles = rotation;
    }

    public void ObjectRotationYaxis(float step)
    {
        Vector3 rotation = map.transform.localEulerAngles;
        rotation.y += step * Time.deltaTime;
        map.transform.localEulerAngles = rotation;
    }

    public void ObjectRotationZaxis(float step)
    {
        Vector3 rotation = map.transform.localEulerAngles;
        rotation.z += step * Time.deltaTime;
        map.transform.localEulerAngles = rotation;
    }
}
