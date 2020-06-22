using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingPlatform : MonoBehaviour
{
    public Scene currentScene;
    public float xSpeed = 5.0f;
    public float ySpeed = 5.0f;
    public float zSpeed = 5.0f;
    public bool xAs = false;
    public bool yAs = false;
    public bool zAs = false;

    public float smooth = 10f;
    public float waitingTime = 1f;
    private float waiting = 0f;

    public Vector3 newPosition = Vector3.zero;

    public bool playerIsInCollision = false;
    public GameObject player;

    private float loadingtime = 10f;

    private void Update()
    {
        //make sure the scene is loaded (there has to be a better way but didnt found one)
        if (loadingtime > 0)
        {
            loadingtime -= Time.deltaTime;
            return;
        }

        if (waiting > 0)
        {
            waiting -= Time.deltaTime;
            return;
        }
        if (xAs) newPosition += new Vector3(xSpeed, 0, 0) * (Time.deltaTime * smooth);
        if (yAs) newPosition += new Vector3(0, ySpeed, 0) * (Time.deltaTime * smooth);
        if (zAs) newPosition += new Vector3(0, 0, zSpeed) * (Time.deltaTime * smooth);

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
            this.xSpeed = -this.xSpeed;
            this.ySpeed = -this.ySpeed;
            this.zSpeed = -this.zSpeed;

            waiting = waitingTime;
        }
    }
}