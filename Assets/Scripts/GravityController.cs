using UnityEngine;
using UnityEngine.InputSystem;

public class GravityController : MonoBehaviour
{

    public float gravityConstant; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        changeGravity();

    }

    public void changeGravity()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {

            Physics.gravity = Vector3.left * gravityConstant;
            transform.rotation = Quaternion.Euler(0, 0, -90);
            print(Physics.gravity); 

        }
        else if (Input.GetKeyDown(KeyCode.V))
        {

            Physics.gravity = Vector3.right * gravityConstant;
            transform.rotation = Quaternion.Euler(0, 0, 90);
            print(Physics.gravity);

        }
        else if (Input.GetKeyDown(KeyCode.B))
        {

            Physics.gravity = Vector3.up * gravityConstant;
            transform.rotation = Quaternion.Euler(180, 0, 0);
            print(Physics.gravity);

        }
        else if ( Input.GetKeyDown(KeyCode.N))
        {

            Physics.gravity = Vector3.down * gravityConstant;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            print(Physics.gravity);

        }

    }


}
