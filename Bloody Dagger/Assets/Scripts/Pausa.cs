using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    public GameObject menuPausa;

    public bool estaPausado;

    void Start()
    {
        menuPausa.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (estaPausado)
            {
                RenaudarJuego();
            }
            else
            {
                PausarJuego();
            }
        }
    }

    public void PausarJuego()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0f;
        estaPausado = true;
    }

    public void RenaudarJuego()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1f;
        estaPausado = false;
    }
}
