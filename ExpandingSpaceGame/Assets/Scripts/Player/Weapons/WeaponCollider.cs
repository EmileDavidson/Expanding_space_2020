using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollider : MonoBehaviour
{
    public List<GameObject> list;

    private void OnTriggerEnter(Collider other)
    {
        list.Add(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        list.Add(collision.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        list.Remove(other.gameObject);
    }

    private void OnCollisionExit(Collision collision)
    {
        list.Remove(collision.gameObject);
    }
}