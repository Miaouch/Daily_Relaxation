using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatsBehavior : MonoBehaviour
{
    [HideInInspector]
    public LevelManager manager;

    public int id = -1;
    
    public int value = 1;
    
    
    // Start is called before the first frame update
    void Start()
    {
        float seconds = Random.Range(3f, 5f);
        //Destroy(gameObject, seconds);        
    }

    private void OnDestroy() {
        //manager.RemoveCube(gameObject);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("BlueChat") || other.CompareTag("GreyChat"))
    //    {
    //        ChatsBehavior chat = other.gameObject.GetComponent<ChatsBehavior>();

    //        manager.ChangeSpeed(chat.id);
    //    }

    //}

}
