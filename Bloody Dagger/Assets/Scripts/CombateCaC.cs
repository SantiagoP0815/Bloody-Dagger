using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateCaC : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float dañoGolpe;
    [SerializeField] private float tiempoEntreAtaques = 1.0f; // Cooldown entre ataques

    private bool puedeAtacar = true; // Controla si el personaje puede atacar

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && puedeAtacar)
        {
            StartCoroutine(AtacarConRetraso(0.5f)); // Lanza el ataque solo si puede atacar
        }
    }

    private void Golpe()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);

        foreach (Collider2D c in objetos)
        {
            if (c.CompareTag("Enemigo"))
            {
                c.transform.GetComponent<Enemigo>().TomarDaño(dañoGolpe);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }

    private IEnumerator AtacarConRetraso(float delay)
    {
        puedeAtacar = false; // Evita nuevos ataques durante el retraso

        yield return new WaitForSeconds(delay); // Espera antes de realizar el ataque
        Golpe(); // Ejecuta el golpe

        yield return new WaitForSeconds(tiempoEntreAtaques); // Espera el tiempo de cooldown
        puedeAtacar = true; // Permite atacar de nuevo
    }
}
