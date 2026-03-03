using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    public bool grounded; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        checkGrounded();
        Jump();
    }

    private void Move()
    {

        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        transform.Translate(direction * moveSpeed * Time.deltaTime);

        

    }

    private void checkGrounded()
    {

        RaycastHit hit;
        Vector3 direction = Vector3.down;

        if (Physics.Raycast(transform.position, direction, out hit, 2f))
        {

            grounded = true;

        }
        else
        {
            grounded = false;

        }

    }

    private void Jump()
    {

        if (grounded)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {

                Rigidbody rb = GetComponent<Rigidbody>();
                rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);

            }

        }

    }

}
