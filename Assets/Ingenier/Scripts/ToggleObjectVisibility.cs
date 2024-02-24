using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ToggleObjectVisibility : MonoBehaviour
{
     public GameObject Object;

    private bool isToggleOn = true;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame void Update() {}

    public void OnToggleChange(bool tickOn)
    {
        if(tickOn)
        {
            Object.SetActive(true);
        }
        else
        {
            Object.SetActive(false);
        }
        isToggleOn = tickOn; //Pass boolean to another variable if needed
    }
}
