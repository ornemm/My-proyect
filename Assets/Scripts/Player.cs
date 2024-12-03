using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float xInicial, yInicial;

    public float speed = 5f;
    public float jumpForce = 10f;

    public static Game obj;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spr;

    public bool isGrounded = false;
    public bool isMoving = false;
    public bool isExcavation = false;
    public bool PlatformTemporary = false; // Nuevo estado para plataformas destructibles


    // Ground detection variables
    public LayerMask groundLayer;
    public float radius = 0.4f;
    public float groundRayDist = 0.5f;

    private int jumpCount; // Contador de saltos
    public int maxJumps = 2; // Número máximo de saltos permitidos

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();

        if (rb == null || anim == null || spr == null)
        {
            Debug.LogError("Uno o más componentes faltantes en el jugador");
        }

        xInicial = transform.position.x;
        yInicial = transform.position.y;

        jumpCount = maxJumps; // Inicializar el contador de saltos
    }

    void Update()
    {
        // Movimiento horizontal
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        isMoving = Mathf.Abs(moveInput) > 0.1f; // Detectar si el jugador se mueve
        isGrounded = Physics2D.CircleCast(transform.position, radius, Vector2.down, groundRayDist, groundLayer);

        // Saltar si hay saltos disponibles
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Aplicar fuerza de salto
            anim.SetTrigger("Jump"); // Activar animación de salto
            jumpCount--; // Reducir el contador de saltos
        }

        // Resetear saltos al estar en el suelo
        if (isGrounded && jumpCount != maxJumps)
        {
            jumpCount = maxJumps; // Resetear el contador
        }

        // Excavación solo en plataforma destructible
        if (Input.GetKey(KeyCode.S) && PlatformTemporary)
        {
            isExcavation = true;
        }
        else
        {
            isExcavation = false;
        }

        // Actualizar animaciones
        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isExcavation", isExcavation);

        // Voltear el sprite en la dirección del movimiento
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

    public void Reposition()
    {
        transform.position = new Vector3(xInicial, yInicial, 0);
    }
}
