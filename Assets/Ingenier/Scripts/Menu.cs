using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour
{
    public InputActionProperty showButton;
    public GameObject menu;
    // Start is called before the first frame update
    
    void Start()
    {
        showButton.action.Enable();
    }
    // Update is called once per frame
    void Update()
    {
        
        if(showButton.action.WasPressedThisFrame()){
            menu.SetActive(!menu.activeSelf);
            Debug.Log("Menu");
        }
    }
}
