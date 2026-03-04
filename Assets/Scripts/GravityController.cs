using UnityEngine;
using UnityEngine.InputSystem;

public class GravityController : MonoBehaviour
{
    [Header("Input Option")]
    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Reverse;
    public KeyCode Reset;

    [Space(10)]
    [Header("Gravity Constant")]
    public float gravityConstant;

    private Vector3 originalAngle; 
    private Quaternion originalRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        originalAngle = transform.eulerAngles;

    }

    // Update is called once per frame
    void Update()
    {
        
        changeGravity();

    }

    private Vector3 angle; 

    public void changeGravity()
    {

        if (Input.GetKeyDown(Up))
        {
            angle = new Vector3(-90, 0, 0);
            Physics.gravity = transform.forward * gravityConstant;
            transform.Rotate(angle);
            transform.rotation = Quaternion.Euler(Mathf.Round(transform.eulerAngles.x / 90f) * 90f, Mathf.Round(transform.eulerAngles.y / 90f) * 90f, Mathf.Round(transform.eulerAngles.z / 90f) * 90f);

        }
        else if (Input.GetKeyDown(Down))
        {

            angle = new Vector3(90, 0, 0);
            Physics.gravity = -transform.forward * gravityConstant;
            transform.Rotate(angle);
            transform.rotation = Quaternion.Euler(Mathf.Round(transform.eulerAngles.x / 90f) * 90f, Mathf.Round(transform.eulerAngles.y / 90f) * 90f, Mathf.Round(transform.eulerAngles.z / 90f) * 90f);

        }
        else if (Input.GetKeyDown(Left))
        {

            angle = new Vector3(0, 0, -90);
            Physics.gravity = -transform.right * gravityConstant;
            transform.Rotate(angle);
            transform.rotation = Quaternion.Euler(Mathf.Round(transform.eulerAngles.x / 90f) * 90f, Mathf.Round(transform.eulerAngles.y / 90f) * 90f, Mathf.Round(transform.eulerAngles.z / 90f) * 90f);

        }
        else if ( Input.GetKeyDown(Right))
        {

            angle = new Vector3(0, 0, 90);
            Physics.gravity = transform.right * gravityConstant;
            transform.Rotate(angle);
            transform.rotation = Quaternion.Euler(Mathf.Round(transform.eulerAngles.x / 90f) * 90f, Mathf.Round(transform.eulerAngles.y / 90f) * 90f, Mathf.Round(transform.eulerAngles.z / 90f) * 90f);

        }
        else if (Input.GetKeyDown(Reverse))
        {

            angle = new Vector3(180, 0, 0);
            Physics.gravity = transform.up * gravityConstant;
            transform.Rotate(angle);
            transform.rotation = Quaternion.Euler(Mathf.Round(transform.eulerAngles.x / 90f) * 90f, Mathf.Round(transform.eulerAngles.y / 90f) * 90f, Mathf.Round(transform.eulerAngles.z / 90f) * 90f);

        }
        else if (Input.GetKeyDown(Reset))
        {

            Physics.gravity = Vector3.down * gravityConstant;
            transform.rotation = originalRotation;
            transform.rotation = Quaternion.Euler(Mathf.Round(transform.eulerAngles.x / 90f) * 90f, Mathf.Round(transform.eulerAngles.y / 90f) * 90f, Mathf.Round(transform.eulerAngles.z / 90f) * 90f);

        }

    }


}
