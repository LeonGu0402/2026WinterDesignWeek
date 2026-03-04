using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    public bool grounded; 
    public float GroundedRadius;
    public float GroundedOffset;    
    public LayerMask GroundLayers;

    public Transform capsuleTrans; 

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
