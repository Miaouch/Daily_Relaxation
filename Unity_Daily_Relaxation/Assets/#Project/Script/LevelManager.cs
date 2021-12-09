using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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
    public int howManyCorrect = 0;

    GameObject[] chatsGameObjects;
    public ChatsHighLight chatsHighLight;
    public bool isHighlight = false;
    public float timeToRestart = 5f;
    

    private void Start() 
    {

        if (nChats <= 15)
        {
            PopChats();
        }

        addSpeed();
        // chatsGameObjects = UnityEngine.GameObject.FindeGameObjectsWithTag("Chat");
        // //chatsHighLight = UnityEngine.GameObject.FindObjectsWithTag("Chat").getComponent<ChatsHighLight>();

        // if(chatsGameObjects.Length == 0)
        // {
        //     Debug.Log("Ohhh noooo!");
        // }
        // if(chatsHighLight==null)
        // {
        //     Debug.Log("Ohhh noooo!");
        // }

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
        CeckVictory();
    }

    private void PopChats() {

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
        howManyCorrect = 0;

        for(int l = 0; l <= listChats.Count-1; l++)
        {
            var miaoBool = listChats[l].GetComponent<ChatsHighLight>();

            if(miaoBool.chatSelected)
            {
                Debug.Log("the cat is highlight");
                if(listChats[l].name == "BlueChat")
                {
                    Debug.Log("yuppi blueChat");
                    howManyCorrect +=1;

                }
                else
                {
                    Debug.Log("noooo greyChat");
                }
            }  
        }
    }
    void CeckVictory()
    {
        if(howManyClick == 3)
        {
            if(howManyCorrect == 3)
            {
                Debug.Log("how many correct " + howManyCorrect);
                Debug.Log("WIIIIIIN");
                StartCoroutine(StartRestart());
            }
            else
            {
                Debug.Log("how many correct " + howManyCorrect);
                Debug.Log("LOOOSE");
                StartCoroutine(StartRestart());
            }
        }
    }

    IEnumerator StartRestart()
    {
        Debug.Log("start the coroutine");
        yield return new WaitForSeconds(timeToRestart);
        Restart();
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    
}
