using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float cooldownTime;
    public float currentTime;

    public bool canShoot = true;
    public float demage;

    public void timer()
    {
        if (canShoot == false)
        {
            if (currentTime < cooldownTime)
            {
                currentTime += Time.deltaTime;
            }
            else
            {
                canShoot = true;
                currentTime = 0;
            }
        }
    }

    public virtual void triggerDown()
    {
        if (canShoot) shoot();
    }

    public virtual void triggerHold()
    {
        if (canShoot) shoot();
    }

    public virtual void shoot()
    {
    }

    public virtual void mouseUp()
    {
    }

    public virtual void rightMouseDown()
    {
    }
}