using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateCaC : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float dañoGolpe;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(AtacarConRetraso(0.5f));
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
        yield return new WaitForSeconds(delay); // Espera el tiempo indicado
        Golpe(); // Ejecuta el ataque después de la espera
    }
}
