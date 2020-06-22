using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPickup : MonoBehaviour
{
    public GameObject bombHandler;
    public GameObject bombObj;
    public float bombTime = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            //show bomb
            GameObject bombObject = Instantiate(bombObj);
            bombObject.transform.position = bombHandler.transform.position;
            bombObject.gameObject.transform.SetParent(bombHandler.transform);
            bombObject.GetComponent<Bomb>().time = this.bombTime;

            bombHandler.GetComponent<BombHandler>().currentBomb = bombObject;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            //show bomb
            GameObject bombObject = Instantiate(bombObj);
            bombObject.transform.position = bombHandler.transform.position;
            bombObject.gameObject.transform.SetParent(bombHandler.transform);
            bombObject.gameObject.GetComponent<Bomb>().time = this.bombTime;

            bombHandler.GetComponent<BombHandler>().currentBomb = bombObject;
        }
    }
}