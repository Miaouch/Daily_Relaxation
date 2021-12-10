using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui : MonoBehaviour
{
    

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("je quitte");
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown("escape"))
    //    {
    //        Application.Quit();
    //    }
    //}
}
