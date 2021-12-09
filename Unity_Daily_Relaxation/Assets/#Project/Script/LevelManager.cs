using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class LevelManager : MonoBehaviour
{
    public static int dimensionZone = 5;
    public Vector3 randomZone = Vector3.one * dimensionZone;

    public GameObject limitPrefab;

    public GameObject greyPrefab;
    public GameObject bluePrefab;

    private int nChats = 0;
    private int nBlueChat=0;
    public GameObject greyChat;
    public GameObject blueChat;
    public UnityEvent whenBlueChatTransformInGrey;

    public List<ChatsBehavior> listChats = new List<ChatsBehavior>();
    public List<Vector3> speeds = new List<Vector3>();
    public Material[] materialsChats;
    public int listCount = 15;


    public UnityEvent whenPlayerWins;
    public UnityEvent whenPlayerLose;

    private float timerRealChat=5f;
    // private float popTimer = 1f;
    // private float popRateTimer = 5f;

    public Vector3 speed = Vector3.zero;
    public Vector3 deplacement;
    public float speedFactor= -10;

    public Vector3 randomSpeedDirection = Vector3.zero;

    public int index;

    public zoneBehavior limit;

    private void Start() 
    {

        if (nChats <= 15)
        {
            PopChats();
        }

        addSpeed();

        GameObject limitZone = Instantiate(limitPrefab, randomZone, Quaternion.identity); 
        Debug.Log(randomZone);
    }

    private void Update() {

        timerRealChat -= Time.deltaTime;
        index = 0;
        for (int j = 0; j <= listChats.Count - 1; j++)
        {
            deplacement = speeds[j] * Time.deltaTime;
            listChats[j].transform.position += deplacement;
            listChats[j].id = index;
            listChats[j].manager = this;
            greyChat.transform.position += deplacement;
            blueChat.transform.position += deplacement;
            index++;
        }

        
        
        //for (int j = 0; j <= listChats.Count - 1; j++)
        //{
        //    speed = Random.onUnitSphere * speedFactor;

        //    deplacement = speed * Time.deltaTime;

        //    listChats[j].transform.position += deplacement;
        //    // greyChat.transform.position += deplacement;

        //    // blueChat.transform.position += deplacement;
        //}

        if (timerRealChat <= 0)
        {
            Debug.Log("change color");
            whenBlueChatTransformInGrey?.Invoke();
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
                listChats.Add(blueChat.GetComponent<ChatsBehavior>());
                nBlueChat++;
            }

            GameObject greyChat = Instantiate(greyPrefab, position, Quaternion.identity);
            listChats.Add(greyChat.GetComponent<ChatsBehavior>());           
            nChats++;
        }
    }

    void addSpeed()
    {
        for (int s = 0; s <= listChats.Count; s++)
        {
            speed = Random.onUnitSphere * speedFactor;
            speeds.Add(speed);                   
        }
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

    public void ChangeSpeed(int id)
    {
        speeds[id] = -speeds[id];
    }

}
