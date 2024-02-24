using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject objetoACambiar; // Primer objeto cuyo material se cambiará
    public GameObject objetoACambiarB; // Segundo objeto cuyo material se cambiará
    public GameObject objetoACambiarGR; // Segundo objeto cuyo material se cambiará
    public GameObject objetoBumperR; // Segundo objeto cuyo material se cambiará
    public Material materialNuevo; // El nuevo material que deseas aplicar
    private Material materialOriginal; // El material original del objeto
    private bool clickeado = false; // Variable para controlar el estado de clic del primer objeto
    private bool clickeadoB = false; // Variable para controlar el estado de clic del segundo objeto
    private bool clickeadoGanchoR = false; // Variable para controlar el estado de clic del segundo objeto
    private bool clickeadoBumperR = false; // Variable para controlar el estado de clic del segundo objeto

    private Renderer rend; // Renderer del primer objeto
    private Renderer rendB; // Renderer del segundo objeto
    private Renderer rendGanchoR; // Renderer del segundo objeto
    private Renderer rendBumperR; // Renderer del segundo objeto
    public InputActionProperty showButton;
    [SerializeField] string botonA;
    [SerializeField] string botonB;
    [SerializeField] string ganchoR;
    [SerializeField] string botonBumperR;
    

    void Start()
    {
        // Obtener el material original del primer objeto
        rend = objetoACambiar.GetComponent<Renderer>();
        rendB = objetoACambiarB.GetComponent<Renderer>();
        rendGanchoR = objetoACambiarGR.GetComponent<Renderer>();
        rendBumperR = objetoBumperR.GetComponent<Renderer>();

        if (rend != null && rendB != null && rendGanchoR != null && rendBumperR != null )
        {
            materialOriginal = rend.material;
            materialOriginal = rendB.material;
            materialOriginal = rendGanchoR.material;
            materialOriginal = rendBumperR.material;
        }
        else
        {
            Debug.LogWarning("Uno de los objetos no tiene un componente Renderer para cambiar el material.");
        }

        // Agregar un collider al objeto Empty si no lo tiene
        if (GetComponent<Collider>() == null)
        {
            gameObject.AddComponent<BoxCollider>();
        }
    }
    
    void Update()
    {
        foreach (var control in showButton.action.controls)
        {
            if (control.IsPressed())
            {
                string boton = control.device.name + control.name;
                //Debug.Log(boton);
                // Verificar los botones del mando de Oculus Quest 3
                if (boton == botonA)
                {
                    if (!clickeado)
                    {
                        //Debug.Log("Se ha presionado el botón A.");
                        CambiarAMaterialNuevo(rend);
                        clickeado = true;
                        Invoke("CambiarAMaterialOriginal", 1f); // Llamar al método para volver al material original después de 1 segundo
                    }
                }
                if (boton == botonB)
                {
                    //Debug.Log("Se ha presionado el botón B.");
                    if (!clickeadoB)
                    {
                        CambiarAMaterialNuevo(rendB);
                        clickeadoB = true;
                        Invoke("CambiarAMaterialOriginal", 1f); // Llamar al método para volver al material original después de 1 segundo
                    }
                }

                if (boton == ganchoR)
                {
                   // Debug.Log("Se ha presionado el botón Gancho Derecho.");
                    if (!clickeadoGanchoR)
                    {
                        CambiarAMaterialNuevo(rendGanchoR);
                        clickeadoGanchoR = true;
                        Invoke("CambiarAMaterialOriginal", 1f); // Llamar al método para volver al material original después de 1 segundo
                    }
                }

                if (boton == botonBumperR)
                {
                    if (!clickeado)
                    {
                       // Debug.Log("Se ha presionado el botón BumperR.");
                        CambiarAMaterialNuevo(rendBumperR);
                        clickeadoBumperR = true;
                        Invoke("CambiarAMaterialOriginal", 1f); // Llamar al método para volver al material original después de 1 segundo
                    }
                }

                else if (Input.GetKey(KeyCode.JoystickButton6))
                {
                    //Debug.Log("Se ha presionado el botón de menú.");
                }
            }
        }
    }

    void CambiarAMaterialNuevo(Renderer rnd)
    {
        // Cambiar al material nuevo
        if (objetoACambiar != null)
        {
            if (rnd != null)
            {
                rnd.material = materialNuevo;
            }
            else
            {
                Debug.LogWarning("El objeto no tiene un componente Renderer para cambiar el material.");
            }
        }
    }

    void CambiarAMaterialOriginal()
    {
        // Cambiar al material original
        if (objetoACambiar != null)
        {
            if (rend != null)
            {
                rend.material = materialOriginal;
                clickeado = false; // Restablecer el estado de clic del primer objeto
            }
            else
            {
                Debug.LogWarning("El primer objeto no tiene un componente Renderer para cambiar el material.");
            }
        }

        if (objetoACambiarB != null)
        {
            if (rendB != null)
            {
                rendB.material = materialOriginal;
                clickeadoB = false; // Restablecer el estado de clic del segundo objeto
            }
            else
            {
                Debug.LogWarning("El segundo objeto no tiene un componente Renderer para cambiar el material.");
            }
        }

        if (objetoACambiarGR != null)
        {
            if (rendB != null)
            {
                rendGanchoR.material = materialOriginal;
                clickeadoGanchoR = false; // Restablecer el estado de clic del segundo objeto
            }
            else
            {
                Debug.LogWarning("El segundo objeto no tiene un componente Renderer para cambiar el material.");
            }
        }

        if (objetoBumperR != null)
        {
            if (rendBumperR != null)
            {
                rendBumperR.material = materialOriginal;
                clickeadoBumperR = false; // Restablecer el estado de clic del segundo objeto
            }
            else
            {
                Debug.LogWarning("El segundo objeto no tiene un componente Renderer para cambiar el material.");
            }
        }
    }
}
