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
    public GameObject cube;

    private int chatNbr = 1;
    private int nChats = 0;
    private int nBlueChat=0;
    public GameObject greyChat;
    public GameObject blueChat;
    public UnityEvent whenBlueChatTransformInGrey;


    public UnityEvent whenPlayerWins;
    public UnityEvent whenPlayerLose;

    private float timerRealChat=5f;
    // private float popTimer = 1f;
    // private float popRateTimer = 5f;

    public Vector3 speed = Vector3.zero;
    public Vector3 deplacement;

    private void Start() 
    {
        speed = new Vector3(0, 0, -10);        
    }

    private void Update() {

        timerRealChat -= Time.deltaTime;

        // popTimer -= Time.deltaTime;
        // popRateTimer -= Time.deltaTime;
        if(nChats<=15)
        {
            PopChats();
        }

        if(timerRealChat <= 0)
        {
            Debug.Log("change color");
            whenBlueChatTransformInGrey?.Invoke();
        }
        
        // if (popTimer <= 0f) {
        //     PopCubes();
        //     popTimer = 1f;
        // }
        // if (popRateTimer <= 0f) {
        //     chatNbr++;
        //     popRateTimer = 5f;
        // }
        deplacement = speed * Time.deltaTime;
        cube.transform.position += deplacement;
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


        // if (Random.Range(0, 5) == 0) {
        if (nBlueChat <=3) {
            blueChat = Instantiate(
                bluePrefab, position, Quaternion.identity);
            blueChat.GetComponent<ChatsBehavior>().manager = this;
            nBlueChat++;
            
        }
        else {
            greyChat = Instantiate(
                greyPrefab, position, Quaternion.identity);
            greyChat.GetComponent<ChatsBehavior>().manager = this;
        }



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
