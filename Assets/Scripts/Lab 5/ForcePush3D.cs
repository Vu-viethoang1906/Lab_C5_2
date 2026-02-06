using UnityEngine;
using UnityEngine.InputSystem;

public class ForceMovement3D : MonoBehaviour
{
    public float moveForce = 20f;
    public float maxSpeed = 5f;
    public float pushForce = 300f;   // Lực đẩy mạnh (phím J)

    private Rigidbody rb;
    private Vector2 input;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // WASD di chuyển
        input = new Vector2(
            (Keyboard.current.dKey.isPressed ? 1 : 0) - (Keyboard.current.aKey.isPressed ? 1 : 0),
            (Keyboard.current.wKey.isPressed ? 1 : 0) - (Keyboard.current.sKey.isPressed ? 1 : 0)
        );

        // Phím J – AddForce đẩy mạnh
        if (Keyboard.current.jKey.wasPressedThisFrame)
        {
            rb.AddForce(transform.forward * pushForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector3(input.x, 0, input.y) * moveForce);

        // Giới hạn tốc độ
        Vector3 v = rb.linearVelocity;
        Vector3 flatV = new Vector3(v.x, 0, v.z);

        if (flatV.magnitude > maxSpeed)
        {
            Vector3 limit = flatV.normalized * maxSpeed;
            rb.linearVelocity = new Vector3(limit.x, v.y, limit.z);
        }
    }
}
