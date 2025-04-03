using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    // [Header("Movement Settings")]
    public float moveSpeed=8f;
    public float jumpForce=10f;
    public int maxJumps=2;

    private Rigidbody rb;
    private int jumpsLeft;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpsLeft = maxJumps;
    }

    void Update()
    {
        // Handle movement
        float moveX=Input.GetAxis("Horizontal");
        float moveZ=Input.GetAxis("Vertical");
        rb.velocity=new Vector3(moveX * moveSpeed, rb.velocity.y, moveZ * moveSpeed);

        // Double jump logic
        if (Input.GetButtonDown("Jump") && jumpsLeft > 0)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpsLeft--;
        }
    }

    // Reset jumps when touching ground
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            jumpsLeft = maxJumps;
    }
}

