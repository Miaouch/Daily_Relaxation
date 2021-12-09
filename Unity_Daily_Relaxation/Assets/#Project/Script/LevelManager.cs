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

    public List<Vector3> speeds = new List<Vector3>();
    public Material[] materialsChats;
    public int listCount = 15;

    public UnityEvent whenPlayerWins;
    public UnityEvent whenPlayerLose;
    public UnityEvent whenHighlight;
    public Vector3 speed = Vector3.zero;
    public Vector3 deplacement;
    public float speedFactor= -10;
    public float timerRealChat = 5f;

    public bool goodAnswer=false;

    public Vector3 randomSpeedDirection = Vector3.zero;
    public bool isClicked = false;
    public int howManyClick = 0;
    public ChatsHighLight chatsHighLight;
    public bool isHighlight = false;
    

    private void Start() 
    {

        if (nChats <= 15)
        {
            PopChats();
        }

        addSpeed();

        

        if(chatsHighLight==null)
        {
            Debug.Log("Ohhh noooo!");
        }
    }

    private void Update() {
        timerRealChat -= Time.deltaTime;

        for (int j = 0; j <= listChats.Count - 1; j++)
        {
            deplacement = speeds[j] * Time.deltaTime;
            listChats[j].transform.position += deplacement;
            greyChat.transform.position += deplacement;
            blueChat.transform.position += deplacement;
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
            //whenBlueChatTransformInGrey?.Invoke();
            
            for(int n=0; n<=listChats.Count-1; n++)
            {
                var miaoRenderer = listChats[n].GetComponent<Renderer>();
                if(miaoRenderer == null)
                {
                    Debug.Log("miao Renderer null");
                }
                else{
                    if(listChats[n].name == "BlueChat")
                    {
                        Debug.Log("Blue Sphere");
                        miaoRenderer.material = materialsChats[1];
                        Debug.Log("material Chats grey"+ materialsChats[1]);
                    }
                }
            }
        }
        DetectionDesChats();
        
    }

    private void PopChats() {

        //if (nCubes >= 10) return;
        

        for(int k=0; k<listCount; k++)
        {
            float x = Random.Range(0, randomZone.x);
            float y = Random.Range(0, randomZone.y);
            float z = Random.Range(0, randomZone.z);

            Vector3 position = new Vector3(x, y, z);
            
            if (nBlueChat<3)
            {
                GameObject blueChat = Instantiate(bluePrefab, position, Quaternion.identity);
                listChats.Add(blueChat);
                nBlueChat++;
                blueChat.name = "BlueChat";
            }

            GameObject greyChat = Instantiate(greyPrefab, position, Quaternion.identity);
            listChats.Add(greyChat);

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

    void DetectionDesChats()
    {
        for(int l = 0; l <= listChats.Count-1; l++)
        {
            //var miaoBool = listChats[l].GetComponent<ChatsHighLight>();

            if(isHighlight)
            {
                Debug.Log("the cat is highlight");
            }
            
        }
    }

    
}
