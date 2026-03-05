using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class GravityController : MonoBehaviour
{
    [Header("Input Option")]
    //private KeyCode Up;
    //private KeyCode Down;
    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Reverse;
    public KeyCode Reset;

    [Space(10)]
    [Header("Gravity Constant")]
    public float gravityConstant;

    private Vector3 originalAngle; 
    private Quaternion originalRotation;

    public bool isShifting;

    public float rotateSpeed = 1f;

    private bool isGravityOrigin = false; 

    public PlayerController controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        originalAngle = transform.eulerAngles;
        originalRotation = transform.rotation;
        isShifting = false;

    }

    private IEnumerator shiftingToQuaternion(Quaternion finalRotation)
    {
        float t = 0f;
        isShifting = true;
        Quaternion initialRotation = transform.rotation;

        while (t < 1f)
        {
            t += Time.deltaTime * rotateSpeed;
            transform.rotation = Quaternion.Lerp(initialRotation, finalRotation, t);
            yield return null;
        }

        isShifting = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        changeGravity();

    }

    private Vector3 angle; 

    private IEnumerator shifting(Vector3 targetDirection, Vector3 gravityDirection)
    {

        float t = 0;
        isShifting = true;
        isGravityOrigin = false; 
        Quaternion initialRotation = transform.rotation;
       
        while (t < 1f)
        {

            t += Time.deltaTime * rotateSpeed;
            transform.rotation = Quaternion.Lerp(initialRotation, initialRotation*Quaternion.Euler(targetDirection), t);
            yield return null;

        }

        t = 0;
        initialRotation = transform.rotation;
        Quaternion finalDirection = Quaternion.Euler(Mathf.Round(transform.eulerAngles.x / 90f) * 90f, Mathf.Round(transform.eulerAngles.y / 90f) * 90f, Mathf.Round(transform.eulerAngles.z / 90f) * 90f);

        while (t < 1f)
        {
            t += Time.deltaTime * 10f; 
            transform.rotation = Quaternion.Lerp(initialRotation, finalDirection, t);
            yield return null;
        }

        Physics.gravity = -transform.up * gravityConstant; 
        isShifting = false; 

    }

    public void changeGravity()
    {

        if (Input.GetKeyDown(Reset))
        {
            if (isGravityOrigin) return;

            isGravityOrigin = true;
            Physics.gravity = Vector3.down * gravityConstant;
            StopAllCoroutines();
            isShifting = false;
            StartCoroutine(shiftingToQuaternion(Quaternion.Euler(originalAngle)));
            return;
        }

        if (isShifting) return;
        if (!controller.grounded) return;

        if (Input.mouseScrollDelta.y > 0)
        {
            angle = new Vector3(-90, 0, 0);
            //Physics.gravity = transform.forward * gravityConstant;
            //transform.Rotate(angle);
            StartCoroutine(shifting(angle, transform.forward));

        }
        else if (Input.mouseScrollDelta.y < 0)
        {

            angle = new Vector3(90, 0, 0);
            //Physics.gravity = -transform.forward * gravityConstant;
            //transform.Rotate(angle);
            StartCoroutine(shifting(angle, -transform.forward));

        }
        else if (Input.GetKeyDown(Left))
        {

            angle = new Vector3(0, 0, -90);
            //Physics.gravity = -transform.right * gravityConstant;
            //transform.Rotate(angle);
            StartCoroutine(shifting(angle, -transform.right));

        }
        else if ( Input.GetKeyDown(Right))
        {

            angle = new Vector3(0, 0, 90);
            //Physics.gravity = transform.right * gravityConstant;
            //transform.Rotate(angle);
            StartCoroutine(shifting(angle, transform.right));
        }
        else if (Input.GetKeyDown(Reverse))
        {

            angle = new Vector3(180, 0, 0);
            //Physics.gravity = transform.up * gravityConstant;
            //transform.Rotate(angle);
            StartCoroutine(shifting(angle, transform.up));
        }

    }


}
