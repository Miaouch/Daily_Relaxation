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

    private int chatNbr = 1;
    private int nChats = 0;



    public UnityEvent whenPlayerWins;
    public UnityEvent whenPlayerLose;

    private float popTimer = 1f;
    private float popRateTimer = 5f;

    private void Start() {

    }

    private void Update() {
        popTimer -= Time.deltaTime;
        popRateTimer -= Time.deltaTime;
    
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

        GameObject chat;

        if (Random.Range(0, 5) == 0) {
            chat = Instantiate(
                bluePrefab, position, Quaternion.identity);
        }
        else {
            chat = Instantiate(
                greyPrefab, position, Quaternion.identity);
        }
        chat.GetComponent<ChatsBehavior>().manager = this;
        nChats++;
    }

    public void SelectionChat(GameObject chat) {
        ChatsBehavior chatsBehavior = chat.GetComponent<ChatsBehavior>();
        if (chatsBehavior.clicked) {
            // score += chatsBehavior.value;
            // if (score >= scoreMax) whenPlayerWins?.Invoke();
            
        }
        else {
            // score -= chatsBehavior.value;
            // if (score < 0) whenPlayerLose?.Invoke();
        }
        nChats--;
    }
}
