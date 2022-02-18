using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBehaviour : MonoBehaviour
{
    Transform playerTransform;
    SpriteRenderer playerSprite;
    SpriteRenderer otherSprite;
    public float sizeIncreaseRate;
    
    private Game game;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<Transform>();
        playerSprite = GetComponent<SpriteRenderer>();
        game = FindObjectOfType<Game>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if user collects a circle
        if (other.CompareTag("Circle"))
        {
            //increase the size of the player
            Vector3 currentScale = playerTransform.localScale;
            playerTransform.localScale = new Vector3(currentScale.x * sizeIncreaseRate, currentScale.y * sizeIncreaseRate, currentScale.z);

            //increase the players health
            float currentHealth = game.health;
            game.changeHealth(currentHealth *= sizeIncreaseRate);

            //change the players colour
            SpriteRenderer otherSprite = other.GetComponent<SpriteRenderer>();
            playerSprite.color = otherSprite.color;


            Destroy(other.gameObject);
        }
        
    }
}
