using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCloseOpen : MonoBehaviour
{
    // Start is called before the first frame update
    private bool activado = true;
    public GameObject objetoParaActivarDesactivar;

    // Método que se ejecuta cuando se hace clic en el objeto
    public void OnMouseDown()
    {
        if (objetoParaActivarDesactivar == null)
        {
            Debug.LogError("No se ha asignado ningún GameObject para activar/desactivar.");
            

            bool estadoActual = objetoParaActivarDesactivar.activeSelf;

            // Verificar el estado actual
        if (activado)
        {
            // Si está activado, desactivarlo
                objetoParaActivarDesactivar.SetActive(false);
        }
        else
        {
            // Si está desactivado, activarlo
                objetoParaActivarDesactivar.SetActive(false);
        }
        }
        

        
    }
}
