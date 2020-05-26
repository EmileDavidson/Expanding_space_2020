using System;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 5.0f;
    public bool xAs = false;
    public bool yAs = false;
    public bool zAs = false;

    public Vector3 newPosition = Vector3.zero;

    public bool playerIsInCollision = false;
    public GameObject player;

    private void Update()
    {
        if (xAs)
        {
            newPosition += new Vector3(speed, 0, 0);
        }

        if (yAs)
        {
            newPosition += new Vector3(0, speed, 0);
        }

        if (zAs)
        {
            newPosition += new Vector3(0, 0, speed);
        }

        this.transform.position += newPosition * Time.deltaTime;

        //reset newPosition zodat hij niet elke keer sneller gaat maar een vaste snelheid behoud.
        newPosition = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //wanneer we in aanraking komen met iets dat niet de player is reverse we dit platforms speed
        //zodat hij de andere kant op gaat
        if (!collision.gameObject.tag.Equals("Player"))
        {
            this.speed = -speed;
        }
        else
        {
            //player is in collision
            playerIsInCollision = true;
        }
    }
}