using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollider : MonoBehaviour
{
    public List<GameObject> list;

    private void OnTriggerEnter(Collider other)
    {
        print("1");
        list.Add(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("2");
        list.Add(collision.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        print("3");
        list.Remove(other.gameObject);
    }

    private void OnCollisionExit(Collision collision)
    {
        print("4");
        list.Remove(collision.gameObject);
    }
}