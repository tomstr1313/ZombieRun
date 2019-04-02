﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFire : MonoBehaviour
{
    public GameObject projectile;
    public float fireDelta = 0.5F;

    private float nextFire = 0.5F;
    private GameObject newProjectile;
    private float myTime = 0.0F;
    public float damage = 100f;

    void FixedUpdate()
    {
        myTime = myTime + Time.deltaTime;

        if (Input.GetButton("Fire1") && myTime > nextFire)
        {
            nextFire = myTime + fireDelta;
            newProjectile = Instantiate(projectile, transform.position, transform.rotation) as GameObject;

            // create code here that animates the newProjectile

            nextFire = nextFire - myTime;
            myTime = 0.0F;

            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.right);
            if(Physics.Raycast(ray,out hit, 100f)) {
                hit.transform.GetComponent<HealthScript>().RemoveHealth(damage);
            }



            


        }
    }
}

