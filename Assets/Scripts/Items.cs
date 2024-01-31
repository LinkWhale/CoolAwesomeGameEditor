using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{

    private HealthSystem health;


    void Start() {
        health = GameObject.FindGameObjectWithTag("PlayerObj").GetComponent<HealthSystem>();
        health.maxPlayerHealth ++;
        health.currentPlayerHealth ++;
    }
//gagagag

}
