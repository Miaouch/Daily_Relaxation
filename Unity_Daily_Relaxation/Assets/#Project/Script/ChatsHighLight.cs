using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatsHighLight : MonoBehaviour
{
    [HideInInspector]
    
    public MeshRenderer miaoRenderer;
    //private Material originalMaterial;
    public Material highLightMaterial;
    
    public LevelManager levelManager;
    public bool chatSelected = false;
    
    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        miaoRenderer = GetComponent<MeshRenderer>();
    }

    
    void Update()
    {
        
    }

    private void OnMouseDown() {
        if(levelManager.howManyClick < 3 && levelManager.miaoCanBeClicked)
        {
            levelManager.howManyClick +=1;
            Highlight();
           
        }
        Debug.Log(levelManager.howManyClick);
        Debug.Log("click");
    }
    
    public void Highlight()
    {
        miaoRenderer.material = highLightMaterial;
        levelManager.isHighlight = true; //no
        chatSelected = true;
        
    }
}
