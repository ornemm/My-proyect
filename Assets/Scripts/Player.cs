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

    // Variables de detección de suelo
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
        // Movimiento horizontal
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Detectar si el jugador se está moviendo
        isMoving = Mathf.Abs(moveInput) > 0.1f;

        // Detectar si el jugador está en el suelo
        isGrounded = Physics2D.CircleCast(transform.position, radius, Vector2.down, groundRayDist, groundLayer);

        // Saltar si el jugador está en el suelo
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetTrigger("Jump"); // Activar animación de salto
        }

        // Actualizar animaciones
        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isGrounded", isGrounded);

        // Voltear el sprite en la dirección de movimiento
        if (moveInput > 0)
            spr.flipX = false;
        else if (moveInput < 0)
            spr.flipX = true;
    }
}