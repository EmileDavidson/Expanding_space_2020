using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCombination : MonoBehaviour
{
    public GameObject MainObject;

    private void OnTriggerEnter(Collider other)
    {
        MainObject.GetComponent<CombinationDoor>().lijst.Clear();
    }
}