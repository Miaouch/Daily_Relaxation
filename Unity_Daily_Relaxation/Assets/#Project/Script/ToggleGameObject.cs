using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGameObject : MonoBehaviour
{
    public bool activeState;
    public GameObject targetObject;


    void Start()
    {
        targetObject.SetActive(activeState);
    }

    public void Toggle() //remplacer
    {
        // if(!activeState) //
        // {
        //     activeState = false;
        // }
        // else
        // {
        //     activeState = true;
        // }
        activeState = !activeState;
        targetObject.SetActive(activeState);
    }

    
}
