using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static int dimensionZone = 14;
    public Vector3 randomZone = Vector3.one * dimensionZone;
    public GameObject greyPrefab;
    public GameObject bluePrefab;
    public int nBlueChat=0;
    
    public GameObject greyChat;
    public GameObject blueChat;
    public UnityEvent whenBlueChatTransformInGrey;

    public List<ChatsBehavior> listChats = new List<ChatsBehavior>();
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

    public Vector3 randomSpeedDirection = Vector3.zero;
    public bool isClicked = false;
    public int howManyClick = 0;
    public int howManyCorrect = 0;
    public GameObject limitPrefab;

    GameObject[] chatsGameObjects;
    public ChatsHighLight chatsHighLight;
    public bool isHighlight = false;
    public float timeToRestart = 5f;

    private float waitPauseTime = 10f;
    private float pauseDuration = 5f;
    private bool pauseMode = false;
    private bool waitMode = false;

    public bool miaoCanBeClicked = false;

    private Renderer miaoRenderer;

    public int index;

    public zoneBehavior limit;

    private void Awake()
    {
        miaoCanBeClicked = false;
        GameObject limitZone = Instantiate(limitPrefab, randomZone, Quaternion.identity);
        PopChats();
        addSpeed();       
    }
 
    private void Start() 
    {

        //Debug.Log(randomZone);
    }
    

    private void Update() {

        timerRealChat -= Time.deltaTime;
        
        for (int j = 0; j < listChats.Count ; j++)
        {
            if (!pauseMode)
            {
                deplacement = speeds[j] * Time.deltaTime;
                listChats[j].transform.position += deplacement;
                greyChat.transform.position += deplacement;
                blueChat.transform.position += deplacement;
            }           
        }
        for (int c = 0; c < listChats.Count; c++)
        {
            if (Vector3.Distance(listChats[c].transform.position,randomZone) > (dimensionZone*Mathf.Sqrt(3)/2))
            {
                speeds[c] = -speeds[c];
                // float x = Random.Range(randomZone.x - (dimensionZone / 2), randomZone.x + (dimensionZone / 2));
                // float y = Random.Range(randomZone.y - (dimensionZone / 2), randomZone.y + (dimensionZone / 2)); ;
                // float z = Random.Range(randomZone.z - (dimensionZone / 2), randomZone.z + (dimensionZone / 2)); ;

                // Vector3 newPosition = new Vector3(x, y, z);

                // listChats[c].transform.position = newPosition;
                // or Destroy(); ...
                // or sens inverse
            }
        }

        if (timerRealChat <= 0 && !miaoCanBeClicked)
        {
                       
            for(int n=0; n<=listChats.Count-1; n++)
            {
                var miaoRenderer = listChats[n].GetComponentInChildren<Renderer>();
                if(miaoRenderer == null)
                {
                    //Debug.Log("miao Renderer null");
                }
                else{
                    if(listChats[n].name == "BlueChat")
                    {
                        //Debug.Log("Blue Sphere");
                        miaoRenderer.material = materialsChats[1];
                        Debug.Log("material Chats grey"+ materialsChats[1]);
                        miaoCanBeClicked = true;
                        
                        if (!pauseMode && !waitMode)
                        {
                            StartCoroutine(WaitPauseMode());
                        }

                        //Debug.Log("material Chats grey"+ materialsChats[1]);
                    }
                }
            }
        }
        //DetectionDesChats();
        //CeckVictory();
    }

    private void PopChats() {
        index = 0;
        for (int k=0; k<listCount; k++)
        {
            float x = Random.Range(randomZone.x-(dimensionZone/2), randomZone.x + (dimensionZone/2));
            float y = Random.Range(randomZone.y - (dimensionZone / 2), randomZone.y + (dimensionZone / 2)); ;
            float z = Random.Range(randomZone.z - (dimensionZone / 2), randomZone.z + (dimensionZone / 2)); ;

            Vector3 position = new Vector3(x, y, z);
            
            if (nBlueChat<3)
            {
                GameObject blueChat = Instantiate(bluePrefab, position, Quaternion.identity);
                listChats.Add(blueChat.GetComponent<ChatsBehavior>());
                nBlueChat++;
                blueChat.name = "BlueChat";  // create 3 cats
            }

            GameObject greyChat = Instantiate(greyPrefab, position, Quaternion.identity);
            listChats.Add(greyChat.GetComponent<ChatsBehavior>());      // create 15cats               
        }

        for(int i=0; i< listChats.Count; i++)
        {
            listChats[i].id = index;   // attribue un num d'id
            listChats[i].manager = this;
            index++;
        }

    }
    void addSpeed()
    {
        for (int s = 0; s < listChats.Count; s++)
        {
            speed = Random.onUnitSphere * speedFactor;
            speeds.Add(speed);                   
        }
    }

    public void DetectionDesChats()
    {
        howManyCorrect = 0; //??

        for(int l = 0; l <listChats.Count; l++)
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
    public void CheckVictory()
    {
        if(howManyClick == 3)
        {
            if(howManyCorrect == 3)
            {
                Debug.Log("how many correct (win)" + howManyCorrect);
                Debug.Log("WIIIIIIN");
                StartCoroutine(StartRestart());
            }
            else
            {
                Debug.Log("how many correct (loose) " + howManyCorrect);
                Debug.Log("LOOOSE");
               
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

    public void ChangeSpeed(int id)
    {
        speeds[id] = -speeds[id];
    }
    public void CheckingHigh()
    {
        DetectionDesChats();
        CheckVictory(); 
    }

    IEnumerator WaitPauseMode()
    {
        waitMode = true;
        yield return new WaitForSeconds(waitPauseTime);
        StartCoroutine(StartPauseMode());
        waitMode = false;       
    }

    IEnumerator StartPauseMode()
    {
        pauseMode = true;
        miaoCanBeClicked = true;
        //for (int l=0; l< listChats.Count;l++)
        //{
        //    if (listChats[l].name == "BlueChat")
        //    {
        //        miaoRenderer = listChats[l].GetComponent<Renderer>();
        //        miaoRenderer.material = materialsChats[0];
        //    }
        //}
        yield return new WaitForSeconds(pauseDuration);
        
        StartCoroutine(StartRestart());
        pauseMode = false;
    }

}
