using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 moveDirection;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");  
        float vertical = Input.GetAxisRaw("Vertical");    

        moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveDirection * speed;
    }
}
