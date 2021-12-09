using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoneBehavior : MonoBehaviour
{
    public LevelManager manager;
    public bool inverseSpeed = false;
    public int index;

    private void Start()
    {
        manager = FindObjectOfType<LevelManager>();
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BlueChat") || other.CompareTag("GreyChat"))
        {
            ChatsBehavior chat = other.gameObject.GetComponent<ChatsBehavior>();

            manager.ChangeSpeed(chat.id);
        }
        
    }
}
