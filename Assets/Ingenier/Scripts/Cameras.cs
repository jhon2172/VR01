using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Cameras : MonoBehaviour
{
    public GameObject objetoAMover; // Objeto que se moverá hacia atrás
    public float distanciaPrudenteY = 1f; // Distancia hacia abajo (ajustado para un movimiento suave en Y)
    private Vector3 posicionOriginal; // Posición original del objeto
    private bool moviendoHaciaAtras = false; // Bandera para verificar si se está moviendo hacia atrás
    private bool verificadorVelocidad = false; // Bandera para verificar si se está moviendo hacia atrás

    public CarController carControllerScript;
    public int currentSpeedKMH;
    public InputActionProperty showButton;
    public Transform objectToTrack; // Objeto cuya posición vamos a rastrear
    //public GameObject Guie;
    Vector3 objectPosition ;


    void Start()
    {
        showButton.action.Enable();


        if (objetoAMover == null)
        {
            Debug.LogError("El objeto a mover no está asignado.");
            enabled = false;
            return;
        }

        posicionOriginal = objetoAMover.transform.position; // Guardar la posición original
    }

    void Update()
    {
        /* if (Guie != null)
        {
            Vector3 posicion = Guie.transform.position;
            Debug.Log("La posición de Guie es: " + posicion);
        }*/
        // Verifica si el objeto a rastrear está asignado
        if (objectToTrack != null)
        {
            // Obtén la posición del objeto y muéstrala en la consola
            objectPosition  = objectToTrack.position;
            posicionOriginal = objectPosition;
           // Debug.Log("Posición del objeto: " + objectPosition );
        }
        if(carControllerScript != null)
        {
            // Accede a la variable velocidad
             currentSpeedKMH = carControllerScript.currentSpeedKMH;
            
            
        }
        // Si se presiona la tecla 'x'
                if(showButton.action.WasPressedThisFrame() && currentSpeedKMH == 0){
        //if (Input.GetKeyDown(KeyCode.X)&& currentSpeedKMH == 0)
        //{
        
            // Si ya se está moviendo hacia atrás, regresar a la posición original
            if (moviendoHaciaAtras)
            {
                objetoAMover.transform.position = posicionOriginal;
                moviendoHaciaAtras = false;
            }
            else
            {
                // Calcular la nueva posición hacia atrás
                Vector3 nuevaPosicion = objetoAMover.transform.position;
                nuevaPosicion.y -= distanciaPrudenteY; // Cambiar -= para mover la cámara hacia abajo
                objetoAMover.transform.position = nuevaPosicion;
                moviendoHaciaAtras = true;
            }    
        }
        if(moviendoHaciaAtras == true){
            if(currentSpeedKMH > 20){
                Debug.Log("Sobrepasa 20 Km");
                verificadorVelocidad = true;
                

                if(verificadorVelocidad == true){
                    
                    
                   objetoAMover.transform.position = posicionOriginal;
                    moviendoHaciaAtras = false;

                }
        
            }else{
                verificadorVelocidad = false;
            }
        }
        

    
    }
}
