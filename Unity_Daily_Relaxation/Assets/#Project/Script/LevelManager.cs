using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class LevelManager : MonoBehaviour
{
    public Vector3 randomZone = Vector3.one * 5;
    public GameObject greyPrefab;
    public GameObject bluePrefab;
    public GameObject cube;

    private int cubeNbr = 1;
    private int nCubes = 0;



    public UnityEvent whenPlayerWins;
    public UnityEvent whenPlayerLose;

    private float popTimer = 1f;
    private float popRateTimer = 5f;

    public Vector3 speed = Vector3.zero;
    public Vector3 deplacement;

    private void Start() 
    {
        speed = new Vector3(0, 0, -10);
    }

    private void Update() {
        popTimer -= Time.deltaTime;
        popRateTimer -= Time.deltaTime;

        if (popTimer <= 0f) {
            //PopCubes();
            PopCube();
            popTimer = 1f;
        }
        if (popRateTimer <= 0f) {
            cubeNbr++;
            popRateTimer = 5f;
        }
        deplacement = speed * Time.deltaTime;
        cube.transform.position += deplacement;
    }


    //private void PopCubes() {
    //    for (int n = 0; n < cubeNbr; n++) {
    //        PopCube();
    //    }
    //}

    private void PopCube() {

        if (nCubes >= 10) return;

        float x = Random.Range(0, randomZone.x);
        float y = Random.Range(0, randomZone.y);
        float z = Random.Range(0, randomZone.z);

        Vector3 position = new Vector3(x, y, z);

        

        if (Random.Range(0, 5) == 0) {
            cube = Instantiate(
                bluePrefab, position, Quaternion.identity);
        }
        else {
            cube = Instantiate(
                greyPrefab, position, Quaternion.identity);
        }
        cube.GetComponent<SphereBehavior>().manager = this;
        nCubes++;
    }

    public void RemoveCube(GameObject cube) {
        SphereBehavior sphereBehavior = cube.GetComponent<SphereBehavior>();
        if (sphereBehavior.clicked) {
            // score += sphereBehavior.value;
            // if (score >= scoreMax) whenPlayerWins?.Invoke();
        }
        else {
            // score -= sphereBehavior.value;
            // if (score < 0) whenPlayerLose?.Invoke();
        }
        nCubes--;
    }

}
