using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public VariableJoystick variableJoystick;
    public float speed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 direction = new Vector2(variableJoystick.Horizontal, variableJoystick.Vertical).normalized;
        rb.velocity = direction * speed;
    }
}
