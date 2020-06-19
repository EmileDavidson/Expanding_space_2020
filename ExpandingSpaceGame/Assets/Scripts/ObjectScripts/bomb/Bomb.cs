using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float time;
    public ParticleSystem explosionParticle;
    public bool isDropped = false;
    public List<GameObject> list = new List<GameObject>();

    private void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
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

                //last
                Destroy(this.gameObject);
            }
            else
            {
                //dont do explode damage;

                //last
                Destroy(this.gameObject);
            }
        }
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