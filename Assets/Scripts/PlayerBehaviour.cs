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
    public string colour;

    private Game game;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<Transform>();
        playerSprite = GetComponent<SpriteRenderer>();
        game = FindObjectOfType<Game>();


        string[] possibleColours = new string[] { "Purple", "Blue", "Yellow" };
        colour = possibleColours[Random.Range(0, possibleColours.Length)];

        //update the sprite colour depending on the random string chosen.
        switch (colour)
        {
            case "Purple":
                playerSprite.color = new Color(1, 0, 0.7467847f, 1);
                break;
            case "Blue":
                playerSprite.color = new Color(0, 0.8572142f, 1, 1);
                break;
            case "Yellow":
                playerSprite.color = new Color(0.9473977f, 1, 0, 1);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
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

            //change the players colour (the actual variable)
            string otherColour = other.GetComponent<circleDetails>().colour;
            colour = otherColour;

            //change the sprite colour (the visible colour);
            SpriteRenderer otherSprite = other.GetComponent<SpriteRenderer>();
            playerSprite.color = otherSprite.color;


            Destroy(other.gameObject);
        }
    }
}

