using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCircles : MonoBehaviour
{
    private Game game;
    public GameObject[] circleList;
    public float spawnRate = 5f;
    public Camera mainCam;
    // Start is called before the first frame update
    void Start()
    {
        game = FindObjectOfType<Game>();
        InvokeRepeating("SpawnCircle", 1f, spawnRate);  //1s delay, repeat every 1s

    }

    // Update is called once per frame
    void Update()
    {
        

        
    }

    //Choose a random circle to spawn from the list and spawn at a random point.
    void SpawnCircle()
    {
        int randomNum = Random.Range(0, circleList.Length);
        GameObject prefab = circleList[randomNum];
        Vector2 randomPositionOnScreen = mainCam.ViewportToWorldPoint(new Vector2(Random.value, Random.value));
        Instantiate(prefab, randomPositionOnScreen, Quaternion.identity);
    }
}
