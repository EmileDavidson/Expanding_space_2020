using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public List<Weapon> weapons = new List<Weapon>();
    public Weapon activeWeapon;

    private void Start()
    {
        if (weapons.Count >= 1)
        {
            activeWeapon = weapons[0];
        }
    }

    private void Update()
    {
        //als er geen active weapon is (wat niet kan zet zucc2000 naar actief.
        if (activeWeapon == null)
        {
            if (weapons.Count <= 0) return;
            activeWeapon = weapons[0];
        }
        //zorg dat er een timer loopt betrefd hoevaak je kan schieten per .. time
        activeWeapon.timer();
        //input van schieten
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //zorg dat je schiet of je weapon gebruikt met hoe het moet
            if (activeWeapon == null) return;
            activeWeapon.triggerHold();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //zorg dat je schiet of je weapon gebruikt met hoe het moet
            if (activeWeapon == null) return;
            activeWeapon.triggerDown();
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            activeWeapon.mouseUp();
        }

        //switch weapon
        if (Input.GetKey(KeyCode.Mouse1))
        {
            //right click
            activeWeapon.rightMouseDown();
        }
    }
}