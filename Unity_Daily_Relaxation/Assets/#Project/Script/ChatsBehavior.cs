using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatsBehavior : MonoBehaviour
{
    [HideInInspector]
    public LevelManager manager;


    

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


}
