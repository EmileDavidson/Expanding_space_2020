using System.Collections.Generic;
using UnityEngine;

public class zucc2000 : Weapon
{
    public GameObject weaponCollider;
    public GameObject smallerWeaponCollider;
    public List<GameObject> ammoObjecten;
    public int offset = 3;

    public void Start()
    {
        cooldownTime = 3;
    }

    public override void shoot()
    {
        if (ammoObjecten.Count <= 0) return;
        canShoot = false;

        //schoot logic

        //pak een random nummer voor het object dat je gaat schieten
        int random = Random.Range(0, ammoObjecten.Count);

        ammoObjecten[random].SetActive(true);
        ammoObjecten[random].transform.position = this.transform.position + this.transform.forward * offset;
        ammoObjecten[random].GetComponent<Rigidbody>().AddForce(this.transform.forward * 5000);

        ammoObjecten.Remove(ammoObjecten[random]);
    }

    public override void rightMouseDown()
    {
        //kijk of er objecten in de buurt zitten en zuig die op
        for (int i = 0; i < weaponCollider.GetComponent<WeaponCollider>().list.Count; i++)
        {
            print(weaponCollider.GetComponent<WeaponCollider>().list[i]);
            if (weaponCollider.GetComponent<WeaponCollider>().list[i].gameObject.tag.Equals("DraggableObject"))
            {
                //het object is op te pakken
                weaponCollider.GetComponent<WeaponCollider>().list[i].gameObject.GetComponent<DraggableObject>().follow = true;
            }
        }
        for (int i = 0; i < smallerWeaponCollider.GetComponent<WeaponCollider>().list.Count; i++)
        {
            if (smallerWeaponCollider.GetComponent<WeaponCollider>().list[i].gameObject.tag.Equals("DraggableObject"))
            {
                //error fix
                if (weaponCollider.GetComponent<WeaponCollider>().list.Contains(smallerWeaponCollider.GetComponent<WeaponCollider>().list[i]))
                {
                    weaponCollider.GetComponent<WeaponCollider>().list.Remove(smallerWeaponCollider.GetComponent<WeaponCollider>().list[i]);
                }

                //hij is dicht bij genoeg om te weg te halen
                ammoObjecten.Add(smallerWeaponCollider.GetComponent<WeaponCollider>().list[i]);
                smallerWeaponCollider.GetComponent<WeaponCollider>().list[i].SetActive(false);
                smallerWeaponCollider.GetComponent<WeaponCollider>().list.Remove(smallerWeaponCollider.GetComponent<WeaponCollider>().list[i]);
            }
        }
    }
}