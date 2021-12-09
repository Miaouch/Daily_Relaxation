using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatsHighLight : MonoBehaviour
{
    [HideInInspector]
    public bool clicked = false;
    private MeshRenderer miaoRenderer;
    private Material originalMaterial;
    public Material highLightMaterial;
    
    public LevelManager levelManager;
    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();

        if(levelManager == null)
        {
            Debug.Log("level manager null");
        }
        else
        {
            Debug.Log("level manager ok");
        }
        
        
        
        miaoRenderer = levelManager.listChats[n].GetComponent<MeshRenderer>();
    }

    
    void Update()
    {
        
    }

    private void OnMouseDown() {
        levelManager.isClicked = true;
        //Destroy(gameObject);
        // for(int n=0; n<=levelManager.listChats.Count-1; n++)
        // {
        //     Highlight();
        // }
        
    }
    public void Highlight()
    {
        
        Debug.Log("Highlight???");
        miaoRenderer.material = highLightMaterial;
    }
}
