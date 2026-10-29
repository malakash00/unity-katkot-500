
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement variables
    public float moveSpeed;
    public float jumpHeight;

    // Keyboard controls
    public KeyCode Spacebar;
    public KeyCode L;
    public KeyCode R;

    // Ground detection variables
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    void Start()
    {

    }

    void Update()
    {
        // Jump only when the player is grounded
        if (Input.GetKeyDown(Spacebar) && grounded)
        {
            Jump();
        }

        // Move left
        if (Input.GetKey(L))
        {
            GetComponent<Rigidbody2D>().velocity =
                new Vector2(
                    -moveSpeed,
                    GetComponent<Rigidbody2D>().velocity.y
                );

            // Flip sprite to face left
            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }

        // Move right
        if (Input.GetKey(R))
        {
            GetComponent<Rigidbody2D>().velocity =
                new Vector2(
                    moveSpeed,
                    GetComponent<Rigidbody2D>().velocity.y
                );

            // Flip sprite to face right
            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity =
            new Vector2(
                GetComponent<Rigidbody2D>().velocity.x,
                jumpHeight
            );
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            whatIsGround
        );
    }
}
