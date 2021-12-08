using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatsHighLight : MonoBehaviour
{
    [HideInInspector]
    public bool clicked = false;
    private MeshRenderer meshRenderer;
    private Material originalMaterial;
    public Material highLightMaterial;
    
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalMaterial = meshRenderer.material;
    }

    
    void Update()
    {
        
    }

    private void OnMouseDown() {
        clicked = true;
        //Destroy(gameObject);
        Highlight();
        

    }
    public void Highlight()
    {
        meshRenderer.material = highLightMaterial;
    }
}
