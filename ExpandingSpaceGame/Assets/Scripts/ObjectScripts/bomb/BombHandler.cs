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
            print("ja!");
            //drop de bomb
            currentBomb.GetComponent<Rigidbody>().useGravity = true;
            currentBomb.GetComponent<SphereCollider>().isTrigger = false;
            RigidbodyConstraints newConstraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            currentBomb.GetComponent<Rigidbody>().constraints = newConstraints;
            currentBomb.transform.SetParent(bombObjecten.transform);
            currentBomb.GetComponent<Bomb>().isDropped = true;
            currentBomb = null;
        }
    }
}