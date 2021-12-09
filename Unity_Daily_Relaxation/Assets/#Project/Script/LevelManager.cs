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

    private int nChats = 0;
    public GameObject greyChat;
    public GameObject blueChat;
<<<<<<< HEAD

=======
    public UnityEvent whenBlueChatTransformInGrey;
    public List<GameObject> listChats = new List<GameObject>();
    public Material[] materialsChats;
    public int listCount = 15;
>>>>>>> master


    public UnityEvent whenPlayerWins;
    public UnityEvent whenPlayerLose;


<<<<<<< HEAD
    private float popChatTimer = 5f;

    

    private void Start() {

    }

    private void Update() {

        popChatTimer -= Time.deltaTime;



        if(nChats<=15)
=======
    public Vector3 speed = Vector3.zero;
    public Vector3 deplacement;
    public float speedFactor= -10;

    public Vector3 randomSpeedDirection = Vector3.zero;

    private void Start() 
    {
        
        if(nChats<=15)
        {
            PopChats();
        }
    }

    private void Update() {
        timerRealChat -= Time.deltaTime;

        

        for(int j=0; j<=listChats.Count-1; j++)
>>>>>>> master
        {
            speed = Random.onUnitSphere * speedFactor;
            
            deplacement = speed * Time.deltaTime;

            listChats[j].transform.position += deplacement;
            // greyChat.transform.position += deplacement;

            // blueChat.transform.position += deplacement;
        }
<<<<<<< HEAD
        // if (popTimer <= 0f) {
        //     PopCubes();
        //     popTimer = 1f;
        // }
        // if (popRateTimer <= 0f) {
        //     chatNbr++;
        //     popRateTimer = 5f;
        // }

    }

=======
        


        if(timerRealChat <= 0)
        {
            Debug.Log("change color");
            whenBlueChatTransformInGrey?.Invoke();
        }
>>>>>>> master

    }

    private void PopChats() {

        //if (nCubes >= 10) return;
        

        for(int k=0; k<listCount; k++)
        {
            float x = Random.Range(0, randomZone.x);
            float y = Random.Range(0, randomZone.y);
            float z = Random.Range(0, randomZone.z);

            Vector3 position = new Vector3(x, y, z);
            
            if (nBlueChat<=3)
            {
                GameObject blueChat = Instantiate(bluePrefab, position, Quaternion.identity);
                listChats.Add(blueChat);
                nBlueChat++;
            }

            GameObject greyChat = Instantiate(greyPrefab, position, Quaternion.identity);
            listChats.Add(greyChat);
            nChats++;

        }

<<<<<<< HEAD

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
=======
        // if (Random.Range(0, 5) == 0) {
        // if (nBlueChat <=3) {
        //     blueChat = Instantiate(
        //         bluePrefab, position, Quaternion.identity);
        //     blueChat.GetComponent<ChatsBehavior>().manager = this;
        //     nBlueChat++;
            
        //     blueChat.transform.position += deplacement;
        // }
        // else {
        //     greyChat = Instantiate(
        //         greyPrefab, position, Quaternion.identity);
        //     greyChat.GetComponent<ChatsBehavior>().manager = this;
        //     greyChat.transform.position += deplacement;
        // }



        // nChats++;

       
>>>>>>> master
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

