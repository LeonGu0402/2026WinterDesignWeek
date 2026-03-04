using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private float originalMoveSpeed; 

    public bool grounded; 
    public float GroundedRadius;
    public float GroundedOffset;    
    public LayerMask GroundLayers;

    public Transform capsuleTrans; 

    public GravityController gravityController;
    public Rigidbody rb; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        originalMoveSpeed = moveSpeed;
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        checkGrounded();
        Jump();
    }

    private void FixedUpdate()
    {
        
        Move();

    }

    private void Move()
    {

        if (gravityController.isShifting) rb.constraints = RigidbodyConstraints.FreezePosition; 
        else rb.constraints = RigidbodyConstraints.FreezeRotation;

        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        rb.MovePosition(transform.position + transform.TransformDirection(direction) * moveSpeed * Time.fixedDeltaTime);

    }

    private void checkGrounded()
    {

        Vector3 spherePosition = capsuleTrans.position + capsuleTrans.up * GroundedOffset;
        print(spherePosition);
        grounded = Physics.CheckSphere(spherePosition, GroundedRadius, GroundLayers, QueryTriggerInteraction.Ignore);        

    }

    private void OnDrawGizmosSelected()
    {
        if (grounded) {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;
        }
        Vector3 spherePosition = capsuleTrans.position + capsuleTrans.up * GroundedOffset;
        Gizmos.DrawSphere(spherePosition, GroundedRadius);
    }

    private void Jump()
    {

        if (grounded)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {

                Rigidbody rb = GetComponent<Rigidbody>();

                Vector3 forceDirection = transform.TransformDirection(Vector3.up);

                print(forceDirection);

                rb.AddForce(forceDirection * 5f, ForceMode.Impulse);

            }

        }

    }

}
