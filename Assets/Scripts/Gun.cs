using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public Animator animator;
    public float bulletSpeed = 20;
    public float gunCD = 0.5f;
    private float cooldown;

    void Update()
    {
        if(cooldown < 0)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {        
                var bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bulletSpawn.forward * bulletSpeed;
                cooldown = gunCD;
                animator.SetTrigger("Shoot");
            }  
        }
        else
        {
            cooldown -= Time.deltaTime;
        }
    }
}
