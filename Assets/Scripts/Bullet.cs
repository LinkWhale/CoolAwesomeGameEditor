using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life;
    void Awake()
    {
        life = GameObject.FindGameObjectWithTag("items").GetComponent<Items>().life;
        Invoke("Fall", life);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    void Fall()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = true;
    }
}
