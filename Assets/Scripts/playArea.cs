using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playArea : MonoBehaviour
{
    Vector2 randomPositionOnScreen;
    private float time = 0.0f;
    public float interpolationPeriod = 10f;
    Vector2 line;
    Vector2 nextPos;



    // Start is called before the first frame update
    void Start()
    {
        //Start circle at a random point.
        randomPositionOnScreen = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));   
        transform.position = randomPositionOnScreen;
    }

    // Update is called once per frame

    void Update()
    {
        //draw a line to the next position.
        line = Vector2.Lerp(transform.position, nextPos, Time.deltaTime);
        transform.position = line;

        time += Time.deltaTime;

        //runs every interpolationPeriod seconds
        if (time >= interpolationPeriod)
        {
            //reset timer
            time -= interpolationPeriod;

            nextPos = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));    //generate a new next position
        }

        
    }
}