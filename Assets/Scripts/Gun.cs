using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    private float cooldown;

    void Update()
    {
        if(cooldown < 0)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {           
                var bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bulletSpawn.forward * bulletSpeed;
                cooldown = 0.5f;
            }  
        }
        else
        {
            cooldown -= Time.deltaTime;
        }
    }
}
