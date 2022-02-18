using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D playerBody;
    public float maxVelocity;
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //basic axis based movement 
        float inputDirectionHorizontal = Input.GetAxis("Horizontal");
        float inputDirectionVertical = Input.GetAxis("Vertical");

        inputDirectionHorizontal = Mathf.Clamp(inputDirectionHorizontal, -maxVelocity, maxVelocity);
        inputDirectionVertical = Mathf.Clamp(inputDirectionVertical, -maxVelocity, maxVelocity);

        Vector2 moveDirection = new Vector2(inputDirectionHorizontal, inputDirectionVertical);

        playerBody.velocity = moveDirection;


    }
}
