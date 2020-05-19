using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryCombination : MonoBehaviour
{
    public GameObject MainObject;
    public List<string> checklist = new List<string>();

    private void OnTriggerEnter(Collider other)
    {
        //bugg fix
        if (MainObject.GetComponent<CombinationDoor>().lijst == null) return;
        for (int i = 0; i < MainObject.GetComponent<CombinationDoor>().lijst.Count; i++)
        {
            //bugg fixes
            if (i > checklist.Count) return;
            if (checklist == null) return;
            if (checklist[i] != MainObject.GetComponent<CombinationDoor>().lijst[i])
            {
                MainObject.GetComponent<CombinationDoor>().lijst.Clear();
                return;
            }
        }
        MainObject.GetComponent<CombinationDoor>().setDoor(false);
    }
}