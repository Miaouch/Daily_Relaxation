using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class LevelManager : MonoBehaviour
{
    
    public static int dimensionZone = 20;
    public Vector3 randomZone = Vector3.one * dimensionZone;
    public GameObject greyPrefab;
    public GameObject bluePrefab;
    public int nBlueChat=0;
    private int nChats = 0;
    public GameObject greyChat;
    public GameObject blueChat;
    public UnityEvent whenBlueChatTransformInGrey;
    public List<GameObject> listChats = new List<GameObject>();
    public Material[] materialsChats;
    public int listCount = 15;

    public UnityEvent whenPlayerWins;
    public UnityEvent whenPlayerLose;

    public Vector3 speed = Vector3.zero;
    public Vector3 deplacement;
    public float speedFactor= -10;
    public float timerRealChat = 5f;

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
        {
            speed = Random.onUnitSphere * speedFactor;
            
            deplacement = speed * Time.deltaTime;

            listChats[j].transform.position += deplacement;
            
        }
        


        if(timerRealChat <= 0)
        {
            Debug.Log("change color");
            //whenBlueChatTransformInGrey?.Invoke();
            
            for(int n=0; n<=listChats.Count-1; n++)
            {
                var miaoRenderer = listChats[n].GetComponent<Renderer>();
                if(miaoRenderer == null)
                {
                    Debug.Log("miao Renderer null");
                }
                else{
                    if(listChats[n].name == "BlueSphere")
                    {
                        Debug.Log("Blue Sphere");
                        miaoRenderer.material = materialsChats[1];
                        Debug.Log("material Chats grey"+ materialsChats[1]);
                    }

                }
            }
        }

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
                blueChat.name = "BlueSphere";
            }

            GameObject greyChat = Instantiate(greyPrefab, position, Quaternion.identity);
            listChats.Add(greyChat);
            nChats++;

        }

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
