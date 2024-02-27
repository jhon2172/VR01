using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiadorDeEscena : MonoBehaviour
{
    // Variable para almacenar el número de la escena
    public int numeroDeEscena;

    // Método para cambiar a la escena especificada
    public void CambiarEscena()
    {
        SceneManager.LoadScene(numeroDeEscena);
    }
}