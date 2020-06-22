using System.Collections.Generic;
using UnityEngine;

public class zucc2000 : Weapon
{
    public int offset = 3;
    public float shootingPower = 1;
    public int minPower = 1;
    public int maxPower = 10;
    public float powerMultiplier = 1;
    public GameObject bullet;

    public void Start()
    {
        cooldownTime = 10;
    }

    public override void shoot()
    {
        //shoot logic
        canShoot = false;
        GameObject bulletobj = Instantiate(bullet);
        bulletobj.transform.position = this.transform.position + this.transform.forward * offset;
        bulletobj.transform.rotation = this.transform.rotation;
        bulletobj.GetComponent<Rigidbody>().AddForce(this.transform.forward * 1000 * shootingPower);

        shootingPower = 1;
    }

    public override void rightMouseDown()
    {
        //aim
    }

    public override void triggerHold()
    {
        //verhoog de shooting power.
        shootingPower += (powerMultiplier * Time.deltaTime);
        if (shootingPower > maxPower || shootingPower < minPower)
        {
            powerMultiplier = -powerMultiplier;
        }
    }

    public override void mouseUp()
    {
        //shoot
        if (canShoot == false)
        {
            shootingPower = 1;
            return;
        }
        shoot();
    }
}