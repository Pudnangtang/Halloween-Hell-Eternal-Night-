using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the player moves

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input from keyboard (arrow keys or WASD) or controller (left stick)
        movement.x = Input.GetAxisRaw("Horizontal"); // For keyboard
        movement.y = Input.GetAxisRaw("Vertical");   // For keyboard

        // Controller input (analog stick)
        float moveHorizontal = Input.GetAxis("LeftStickHorizontal");
        float moveVertical = Input.GetAxis("LeftStickVertical");

        // Combine both inputs (keyboard and controller)
        if (movement.x == 0)
            movement.x = moveHorizontal;
        if (movement.y == 0)
            movement.y = moveVertical;
    }

    void FixedUpdate()
    {
        // Move the player
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
