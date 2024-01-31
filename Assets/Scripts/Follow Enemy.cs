using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    public float speed;
    public float minimumDistance;
    public float maximumDistance;
    public int health = 5;
    public Transform target;

    void Start() {
        target = GameObject.FindGameObjectWithTag("PlayerObj").GetComponent<Transform>();
    }


    private void Update()
    {
        if(Vector3.Distance(transform.position, target.position) > minimumDistance && Vector3.Distance(transform.position, target.position) < maximumDistance) 
        {
        transform.position = Vector3.MoveTowards(transform.position, target.position  + new Vector3(0, 1.0f, 0), speed * Time.deltaTime);
        }
        if(Vector3.Distance(transform.position, target.position) < minimumDistance) {
            GameObject.FindGameObjectWithTag("PlayerObj").GetComponent<HealthSystem>().Damage();
        }

        transform.LookAt(target);
    }


    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.tag == "Bullet")
        {
            if(health > 1)
            {
                health --;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
