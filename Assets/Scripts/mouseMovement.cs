using UnityEngine;
using System.Collections;

public class mouseMovement : MonoBehaviour
{

    private Vector3 mousePosition;
    private Rigidbody2D playerBody;
    public float moveSpeed = 1.25f;

    // Use this for initialization
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector2 line = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);

            transform.position = line;
        }

    }
}