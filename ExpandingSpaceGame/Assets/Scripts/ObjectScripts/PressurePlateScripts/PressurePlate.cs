using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool isPressed = false;
    public float time = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.tag.Equals("Player") && !other.gameObject.tag.Equals("PushableBlock")) return;
        if (isPressed) return;
        isPressed = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.tag.Equals("Player") && !other.gameObject.tag.Equals("PushableBlock")) return;
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(time);
        isPressed = false;
    }
}