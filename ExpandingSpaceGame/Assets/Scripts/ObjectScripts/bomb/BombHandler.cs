using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombHandler : MonoBehaviour
{
    public GameObject currentBomb;
    public GameObject bombObjecten;

    private void Update()
    {
        if (currentBomb == null) return;
        if (Input.GetKey(KeyCode.Q))
        {
            drop();
        }
    }

    public void drop()
    {
        if (currentBomb == null) return;
        currentBomb.GetComponent<Rigidbody>().useGravity = true;
        currentBomb.GetComponent<SphereCollider>().isTrigger = false;
        RigidbodyConstraints newConstraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        currentBomb.GetComponent<Rigidbody>().constraints = newConstraints;
        currentBomb.transform.SetParent(bombObjecten.transform);
        currentBomb.GetComponent<Bomb>().isDropped = true;
        if (currentBomb.GetComponent<Bomb>().time > 5) currentBomb.GetComponent<Bomb>().time = 5;
        currentBomb = null;
    }
}