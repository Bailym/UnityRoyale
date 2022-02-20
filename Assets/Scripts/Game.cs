using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    
    public float health;
    public TextMeshProUGUI healthText;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        //start with 100 health
        changeHealth(100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeHealth(float amount)
    {
        //update health and UI
        health = (int)amount;
        healthText.text = "Health: " + health.ToString();

        if(health == 0)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        Destroy(Player);
    }
}
