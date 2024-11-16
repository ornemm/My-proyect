using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
   
    public static Game obj;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spr;

    public bool isGrounded = false;
    public bool isMoving = false;

    //Ground detection variables
    public LayerMask groundLayer;
    public float radius = 0.4f;
    public float groundRayDist = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();

        if (rb == null || anim == null || spr == null)
        {
            Debug.LogError("Uno o más componentes faltantes en el jugador");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        isMoving = Mathf.Abs(moveInput) > 0.1f; //Detect if the player is moving

        isGrounded = Physics2D.CircleCast(transform.position, radius, Vector2.down, groundRayDist, groundLayer); //Detect if the player is on the ground

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) //Jump if the player is on the ground
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetTrigger("Jump"); //Activate jump animation
        }

        //Update animations
        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isGrounded", isGrounded);

        //Flip the sprite in the direction of movement
        if (moveInput > 0)
            spr.flipX = false;
        else if (moveInput < 0)
            spr.flipX = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlatformMobile")
        {
            transform.parent = collision.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlatformMobile")
        {
            transform.parent = null;
        }
    }
}