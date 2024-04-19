using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidad;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float InputMovement = Input.GetAxis("Horizontal");

        // Establecer velocidad horizontal
        if (InputMovement != 0)
        {
            rb.velocity = new Vector2(InputMovement * velocidad, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        // Mantener el jugador vertical
        transform.rotation = Quaternion.Euler(0, 0, 0); // Mantener la rotación vertical
    }
}
