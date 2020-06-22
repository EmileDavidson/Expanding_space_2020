using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateDoor : MonoBehaviour
{
    public GameObject[] pressurePlates;
    public GameObject door;

    private void Update()
    {
        foreach (GameObject obj in pressurePlates)
        {
            if (!obj.GetComponent<PressurePlate>().isPressed)
            {
                door.SetActive(true);
                return;
            }
        }
        door.SetActive(false);
    }
}