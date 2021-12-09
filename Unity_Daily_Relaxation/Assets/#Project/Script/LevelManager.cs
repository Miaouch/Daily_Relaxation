using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class LevelManager : MonoBehaviour
{

    public ChatsBehavior[] chats;
    public Material[] materialsChats;
    public List<int> blueChats = new List<int>();
    public static int dimensionZone = 20;
    public Vector3 randomZone = Vector3.one * dimensionZone;
    public GameObject greyPrefab;
    public GameObject bluePrefab;

    private int chatNbr = 1;
    private int nChats = 0;
    public GameObject greyChat;
    public GameObject blueChat;



    public UnityEvent whenPlayerWins;
    public UnityEvent whenPlayerLose;


    private float popChatTimer = 5f;

    

    private void Start() {

    }

    private void Update() {

        popChatTimer -= Time.deltaTime;



        if(nChats<=15)
        {
            PopChats();
        }
        // if (popTimer <= 0f) {
        //     PopCubes();
        //     popTimer = 1f;
        // }
        // if (popRateTimer <= 0f) {
        //     chatNbr++;
        //     popRateTimer = 5f;
        // }

    }


    // private void PopChats() {
    //     for (int n = 0; n < chatNbr; n++) {
    //         PopChat();
    //     }
    // }

    private void PopChats() {

        //if (nCubes >= 10) return;

        float x = Random.Range(0, randomZone.x);
        float y = Random.Range(0, randomZone.y);
        float z = Random.Range(0, randomZone.z);

        Vector3 position = new Vector3(x, y, z);



        if (Random.Range(0, 5) == 0) {
            blueChat = Instantiate(
                bluePrefab, position, Quaternion.identity);
        }
        else {
            greyChat = Instantiate(
                greyPrefab, position, Quaternion.identity);
        }

        blueChat.GetComponent<ChatsBehavior>().manager = this;
        greyChat.GetComponent<ChatsBehavior>().manager = this;
        nChats++;
    }

    public void SelectionChat(GameObject chat) {
        ChatsHighLight chatHighLight = chat.GetComponent<ChatsHighLight>();
        if(chatHighLight.clicked)
        {
            // change de couleur apres un certain temps
        }

        // ChatsBehavior chatsBehavior = chat.GetComponent<ChatsBehavior>();
        // if (chatsBehavior.clicked) {
        //     // score += chatsBehavior.value;
        //     // if (score >= scoreMax) whenPlayerWins?.Invoke();
            
        // }
        // else {
        //     // score -= chatsBehavior.value;
        //     // if (score < 0) whenPlayerLose?.Invoke();
        // }
        nChats--;
    }
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;


// public class ChangePrefab : MonoBehaviour
// {
//     private Material originalMaterial;
//     public Material greyMaterial;
//     public Renderer chatRenderer;
//     [HideInInspector]
//     public bool isAllTheSame = false;

//     private void Start()
//     {
//         chatRenderer = GetComponent<Renderer>();
//         originalMaterial = chatRenderer.material;
//     }

//     public void AllTheSame()
//     {
//         Debug.Log("change color material");
//         chatRenderer.material = greyMaterial;
//         isAllTheSame = true;
//     }
// }

