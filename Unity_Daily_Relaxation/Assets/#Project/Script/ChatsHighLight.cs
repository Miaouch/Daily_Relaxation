using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatsHighLight : MonoBehaviour
{
    [HideInInspector]
    
    private MeshRenderer miaoRenderer;
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
            Debug.Log("how many click " + levelManager.howManyClick);
            levelManager.howManyClick +=1;
            Highlight();
            // levelManager.DetectionDesChats();
            // levelManager.CeckVictory();
        } 
        
        
    }
    
    public void Highlight()
    {
        miaoRenderer.material = highLightMaterial;
        levelManager.isHighlight = true; //no
        chatSelected = true;
    }
}
