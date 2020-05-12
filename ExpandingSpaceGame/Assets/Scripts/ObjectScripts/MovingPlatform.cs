using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 5.0f;
    public bool xAs = false;
    public bool yAs = false;
    public bool zAs = false;

    private void Update()
    {
        if (xAs)
        {
            this.transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }

        if (yAs)
        {
            this.transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
        }

        if (zAs)
        {
            this.transform.position += new Vector3(0, 0, speed) * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //wanneer we in aanraking komen met iets dat niet de player is reverse we dit platforms speed
        //zodat hij de andere kant op gaat
        if (!collision.gameObject.tag.Equals("Player"))
        {
            this.speed = -speed;
        }
    }
}