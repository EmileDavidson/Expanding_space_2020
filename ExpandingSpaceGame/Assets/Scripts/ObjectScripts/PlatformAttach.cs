using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlatformAttach : MonoBehaviour
{
    public GameObject player;
    private bool isMoving;
    private Vector3 velocity;
    private void OnCollisionEnter (Collision col)
    {
        if(col.gameObject == player)
        {
            isMoving = true;
            col.collider.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit(Collision col)
    {
        if(col.gameObject == player)
        {
            col.collider.transform.SetParent(null);
        }
    }
    private void FixedUpdate()
    {
        if(isMoving)
        {
            transform.position += (velocity * Time.deltaTime);
        }
    }
}
