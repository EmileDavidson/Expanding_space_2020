using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDuster : MonoBehaviour
{
    public void OnCollisionStay(Collision collision)
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (collision.gameObject.tag == "ScrapPiece")
            {
                Debug.Log("ScrapPeaceGevonden!");
                collision.gameObject.GetComponent<ScrapPiece>().pickup();
            }
        }
    }
}