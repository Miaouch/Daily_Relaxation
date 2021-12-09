using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoneBehavior : MonoBehaviour
{
    public LevelManager manager;
    private void OnTriggerExit(Collider other)
    {
        ChatsBehavior chat = other.GetComponent<ChatsBehavior>();

        if (chat != null)
        {
            manager.speed = -manager.speed;
        }
    }

}
