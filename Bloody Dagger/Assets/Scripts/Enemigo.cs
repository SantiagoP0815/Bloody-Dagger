using System;
using System.Collections;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private Transform jugador; // Referencia al jugador

    private Animator animator;
    private bool vivo = true; // Para saber si est� vivo
    private bool mirandoDerecha = true; // Asume que el enemigo inicialmente mira a la derecha

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (vivo)
        {
            MirarAlJugador();
        }
    }

    public void TomarDa�o(float da�o)
    {
        if (vida > da�o) // Si el da�o no mata al enemigo
        {
            animator.SetTrigger("Hurt");
        }

        vida -= da�o;

        if (vida <= 0)
        {
            Muerte();
        
        }
    }

    private void Muerte()
    {
        animator.SetTrigger("Death");
        vivo = false; // Cambiar el estado a muerto
    }

    private IEnumerator Revivir()
    {
        yield return new WaitForSeconds(2.0f);
        animator.SetTrigger("Recover");
        vida = 100;
        vivo = true; // Cambiar el estado a vivo
    }

    // M�todo para que el enemigo mire al jugador
    private void MirarAlJugador()
    {
        Vector3 direccion = jugador.position - transform.position; // Direcci�n hacia el jugador

        if (direccion.x > 0 && !mirandoDerecha) // Jugador a la derecha, pero mirando a la izquierda
        {
            Voltear(); // Voltear para mirar a la derecha
        }
        else if (direccion.x < 0 && mirandoDerecha) // Jugador a la izquierda, pero mirando a la derecha
        {
            Voltear(); // Voltear para mirar a la izquierda
        }
    }

    // M�todo para invertir la escala en el eje X
    private void Voltear()
    {
        mirandoDerecha = !mirandoDerecha; // Cambiar el estado de direcci�n

        // Invertir la escala X para voltear el sprite
        Vector3 nuevaEscala = transform.localScale;
        nuevaEscala.x *= -1; // Invertir el eje X
        transform.localScale = nuevaEscala;
    }
}
