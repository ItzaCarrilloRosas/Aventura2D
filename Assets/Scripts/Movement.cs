using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float speed = 5f; // Velocidad del personaje
    private Rigidbody2D rb;
    private Animator anim; // Para controlar las animaciones

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); // Conecta el Animator del personaje
    }

    void Update()
    {
        float moveInput = 0f;

        // Leer teclado directamente con el nuevo Input System
        var keyboard = Keyboard.current;
        if (keyboard != null)
        {
            if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed)
                moveInput = -1f;
            else if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed)
                moveInput = 1f;
        }

        // Aplicar movimiento horizontal
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Actualizar parámetro "Speed" del Animator
        if (anim != null)
            anim.SetFloat("Speed", Mathf.Abs(moveInput));
    }
}

