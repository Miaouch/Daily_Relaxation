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
    public bool activeOutline;
    public GameObject outline;
    
    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        miaoRenderer = GetComponentInChildren<MeshRenderer>();
        outline.SetActive(false);
    }

    
    void Update()
    {
        
    }

    public void OnMouseOver(){
        outline.SetActive(true);
    }
    public void OnMouseExit(){
        if(!activeOutline){
            outline.SetActive(false);
        }else if(activeOutline){
            outline.SetActive(true);
        }

    }
    private void OnMouseDown() {
        if(levelManager.howManyClick < 3)// && levelManager.miaoCanBeClicked)
        {
            Debug.Log("how many click " + levelManager.howManyClick);
            levelManager.howManyClick +=1;
            Highlight();
            //levelManager.DetectionDesChats();
            //levelManager.CeckVictory();
            levelManager.CheckingHigh();
        } 
    }
    public void Highlight()
    {
        if(gameObject.name == "BlueChat"){
            outline.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
            // miaoRenderer.material = highLightMaterial;
            levelManager.isHighlight = true; //no
            chatSelected = true;
            activeOutline =true;

        } else {
            outline.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
            // miaoRenderer.material = highLightMaterial;
            levelManager.isHighlight = true; //no
            chatSelected = true;
            activeOutline =true;
        }
    }
}
