using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody rb;
    private float movementSpeed = 2f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
     Debug.Log("Hello from PlayerScript!");   
    }

    void Update()
    {
        HandleMovement();
        isGrounded();
    }

    void HandleMovement()
    {
        Vector3 movement = Vector3.zero;

        if (Keyboard.current.wKey.isPressed)
        {
            movement.z += 1;
        }

        if (Keyboard.current.sKey.isPressed)
        {
            movement.z -= 1;
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded())
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 5, rb.linearVelocity.y);
        }

        if (Keyboard.current.dKey.isPressed)
        {
            movement.x += 1;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            movement.x -= 1;
        }

        rb.linearVelocity = new Vector3 (
            movement.x * movementSpeed,
            rb.linearVelocity.y,
            movement.z * movementSpeed
            );
    }

    public bool isGrounded()
    {
             return Physics.Raycast(groundCheck.position, Vector3.down, 0.1f);
    }
}
