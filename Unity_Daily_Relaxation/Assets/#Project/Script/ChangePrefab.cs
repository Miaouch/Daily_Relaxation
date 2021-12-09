using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangePrefab : MonoBehaviour
{
    private Material originalMaterial;
    public Material greyMaterial;
    public Renderer chatRenderer;
    [HideInInspector]
    public bool isAllTheSame = false;

    private void Start()
    {
        chatRenderer = GetComponent<Renderer>();
        originalMaterial = chatRenderer.material;
    }

    public void AllTheSame()
    {
        Debug.Log("change color material");
        chatRenderer.material = greyMaterial;
        isAllTheSame = true;
    }


    // private bool _allTheSame = true;
    

    // public bool allTheSame {
    //     get { return _allTheSame; }
    //     set {
    //         if (value) {
    //             GetComponent<Renderer>().material.SetColor(
    //                 "_Color", Color.green);
    //         }
    //         else {
    //             GetComponent<Renderer>().material.SetColor(
    //                 "_Color", Color.red);
    //         }
    //         _allTheSame = value;
    //     }
    // }
    // // Start is called before the first frame update
    // void Start() {
        
    // }

    // // Update is called once per frame
    // void Update() {
        
    // }
    // public void AllTheSame()
    // {
    //     allTheSame = !allTheSame;

    // }

    

    
    


    // private MeshRenderer meshRenderer;
    // private Material originalMaterial;
    // public Material greyMaterial;
    
    // void Start()
    // {
    //     meshRenderer = GetComponent<MeshRenderer>();
    //     if(meshRenderer == null)
    //     {
    //         Debug.Log("nulllll");
    //     }
    //     originalMaterial = meshRenderer.material;
    // }

    
    // void Update()
    // {
        
    // }

    
    // public void AllTheSame()
    // {
    //     meshRenderer.material = greyMaterial;
    // }
}
