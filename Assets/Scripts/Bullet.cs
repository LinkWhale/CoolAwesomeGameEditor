using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life;
    
    void Awake()
    {
        Invoke("Fall", 0.1f);
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
