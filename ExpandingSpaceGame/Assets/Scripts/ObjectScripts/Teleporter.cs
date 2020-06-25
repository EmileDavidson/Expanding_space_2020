using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject newLocation;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            //teleport
            collision.gameObject.GetComponent<CharacterController>().enabled = false;
            collision.gameObject.transform.position = newLocation.transform.position;
            collision.gameObject.GetComponent<CharacterController>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            //teleport
            other.gameObject.GetComponent<CharacterController>().enabled = false;
            other.gameObject.transform.position = newLocation.transform.position;
            other.gameObject.GetComponent<CharacterController>().enabled = true;
        }
    }
}