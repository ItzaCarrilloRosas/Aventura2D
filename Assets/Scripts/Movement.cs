using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 5f; // Velocidad del personaje

    [Header("Salto")]
    public float jumpForce = 7f; // Fuerza del salto
    public Transform groundCheck; // Empty que indica los pies
    public LayerMask groundLayer; // Layer del suelo
    private bool isGrounded;

    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float moveInput = 0f;
        var keyboard = Keyboard.current;

        if (keyboard != null)
        {
            // Movimiento horizontal
            if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed)
                moveInput = -1f;
            else if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed)
                moveInput = 1f;

            // Salto
            if (keyboard.spaceKey.wasPressedThisFrame && isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                if (anim != null)
                    anim.SetTrigger("JumpTrigger");
            }
        }

        // Aplicar movimiento horizontal
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Animación de movimiento
        if (anim != null)
            anim.SetFloat("Speed", Mathf.Abs(moveInput));

        // Detectar si está en el suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }
}
