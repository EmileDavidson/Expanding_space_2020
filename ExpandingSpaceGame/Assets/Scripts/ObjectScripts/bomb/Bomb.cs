using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bomb : MonoBehaviour
{
    public float time;
    public ParticleSystem explosionParticle;
    public bool isDropped = false;
    public List<GameObject> list = new List<GameObject>();
    public Camera playerCam;
    public TMP_Text textComponent;

    private void Start()
    {
        playerCam = Camera.main;
    }

    private void Update()
    {
        time -= Time.smoothDeltaTime;
        UI();
        if (time <= 0)
        {
            explode();
            Destroy(gameObject);
        }
    }

    public void explode()
    {
        ParticleSystem particle = Instantiate(explosionParticle);
        particle.transform.position = this.transform.position;
        Destroy(particle, 1);
        //explode
        if (isDropped)
        {
            //do explode damage
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].gameObject.tag.Equals("DestoyableWithBomb"))
                {
                    //destory
                    Destroy(list[i]);
                }
            }
        }
    }

    public void UI()
    {
        textComponent.gameObject.transform.LookAt(2 * transform.position - playerCam.transform.position);
        if (time < 0) { time = 0; }
        textComponent.text = time.ToString("0");
        if (time <= 5) textComponent.color = Color.red;
    }

    private void OnCollisionEnter(Collision collision)
    {
        list.Add(collision.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        list.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (list.Contains(other.gameObject))
        {
            list.Remove(other.gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (list.Contains(collision.gameObject))
        {
            list.Remove(collision.gameObject);
        }
    }
}