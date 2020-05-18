using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public GameObject[] gravityObjecten;
    public bool canMove = true;

    [Range(0.1f, 1f)]
    public float smooth = 1f;

    public bool canRotate = false;
    private Quaternion targetRotation;

    private void Start()
    {
        targetRotation = transform.rotation;
    }

    private void Update()
    {
        /* controlleer of hij mag roteren of niet
         wanneer hij mag roteren vragen we die functie op waarbij hij een actie kan uitvoeren
         het moment dat hij niet mag roteren controlleren we of alles is gedaan en zetten hem daarna
         weer terug naar mag roteren */
        if (canRotate)
        {
            MayRotate();
        }
        else
        {
            if (canMove)
            {
                MayNotRotate();
            }
        }
        //zorg dat hij "smooth" roteert en niet in een instant is
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * smooth * Time.deltaTime);
    }

    public void MayRotate()
    {
        //wanneer je input A of left arrow geeft set ik een quaturnion naar 90 graden zodat het object 90 graden roteert
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //roteren is false omdat je dat net hebt gedaan
            canRotate = false;
            //set rotation naar 90 graden
            targetRotation *= Quaternion.Euler(0, 0, 90);
            //start de timer om weer te mogen roteren
            StartCoroutine(timer(10 * smooth * Time.deltaTime));
        }
        //wanneer je input D of right arrow geeft set ik een quaturnion naar -90 graden zodat het object 90 graden roteert
        //maar dan de andere kant op
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            //roteren is false omdat je het niet hebt gedaan je moet nu wachten tot alles voorbij is
            canRotate = false;
            //set rotation naar -90 zodat hij roteert
            targetRotation *= Quaternion.Euler(0, 0, -90);
            //start de timer om weer te mogen roteren
            StartCoroutine(timer(10 * smooth * Time.deltaTime));
        }
    }

    public void MayNotRotate()
    {
        //controlleer of alle gravityObjecten klaar zijn met vallen
        for (int i = 0; i < gravityObjecten.Length; i++)
        {
            if (gravityObjecten[i].gameObject.GetComponent<GravityObjecten>().done == false)
            {
                return;
            }
        }
        canRotate = true;
        canMove = false;
    }

    public IEnumerator timer(float time)
    {
        yield return new WaitForSeconds(time);
        canMove = true;
    }
}