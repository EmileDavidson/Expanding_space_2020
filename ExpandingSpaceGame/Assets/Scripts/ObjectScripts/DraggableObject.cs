using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    public bool follow = false;
    public GameObject goToObject;
    public GameObject[] ammoList;

    [Range(0, 100)]
    public float smooth = 5;

    //LateUpdate want de andere updates moeten eerst worden gedaan
    private void LateUpdate()
    {
        if (follow)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, goToObject.transform.position, smooth * Time.deltaTime);
        }
        // zet hem weer false nadat hij een stuk dichterbij is gekomen mocht hij nog steeds worden ogezogen word hij weer aangezet
        follow = false;
    }
}