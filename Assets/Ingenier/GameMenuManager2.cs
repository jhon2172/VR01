using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenuManager : MonoBehaviour
{
    public GameObject menu;
    public InputActionProperty showButton;

    string boton;

    string botonX="OculusTouchControllerOpenXRprimarybutton";
    string botonY="OculusTouchControllerOpenXRsecondarybutton";
    string botonA="OculusTouchControllerOpenXR1primarybutton";
    string botonB="OculusTouchControllerOpenXR1secondarybutton";
    string ganchoL="OculusTouchControllerOpenXRtriggerpressed";
    string ganchoR="OculusTouchControllerOpenXR1triggerpressed";
    string gancho2L="OculusTouchControllerOpenXRgrippressed";
    string gancho2R="OculusTouchControllerOpenXR1grippressed";
    string Menu="OculusTouchControllerOpenXRmenu";
    

    // Start is called before the first frame update
    void Start()
    {
        showButton.action.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(showButton.action.WasPressedThisFrame()){
            menu.SetActive(!menu.activeSelf);
            Debug.Log("GG");
        }
        */

     
        // Verificar qué botón se está presionando actualmente
        foreach (var control in showButton.action.controls)
        {
            if (control.IsPressed())
            {
                boton= control.device.name + control.name;
                Debug.Log(boton);
                if (boton == botonX)
                    {
                        Debug.Log("Boton X : " + boton);
                    }
                if (boton == botonY)
                    {
                        Debug.Log("Boton Y : " + boton);
                    }
                if (boton == botonA)
                    {
                        Debug.Log("Boton A : " + boton);
                    }
                if (boton == botonB)
                    {
                        Debug.Log("Boton B : " + boton);
                    }
                if (boton == ganchoL)
                    {
                        Debug.Log("Gancho Izquierdo : " + boton);
                    }
                if (boton == ganchoR)
                    {
                        Debug.Log("Gancho Derecho : " + boton);
                    }
                if (boton == gancho2L)
                    {
                        Debug.Log("Gancho Secundario Izquierdo : " + boton);
                    }
                if (boton == gancho2R)
                    {
                        Debug.Log("Gancho Secundario Derecho : " + boton);
                    }
                if (boton == Menu)
                    {
                        menu.SetActive(!menu.activeSelf);
                        Debug.Log("Boton Mennu: " + boton);
                    }
            }
        }

 /*   foreach (var control in showButton.action.controls)
{
    if (control.IsPressed())
    {
        string buttonName = control.name;

        // Comprueba si el botón presionado es el que conoces
        if (buttonName == "OculusTouchControllerOpenXRprimarybutton")
        {
            Debug.Log("El botón específico se ha presionado: " + buttonName);
        }
    }
}*/
    }
}
