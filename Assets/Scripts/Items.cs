using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Items : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI modifierUI;

    private HealthSystem health;
    public int rand;
    public float life = 0;    

    void Start() {
        rand = Random.Range(0, 4);
        if(rand == 0) {
            Health();
        }
        if(rand == 1) {
            Machinegun();
        }
        if(rand == 2) {
            Speed();
        }
        if(rand == 3) {
            Sniper();
        }
    }


    public void Health() 
    {
        health = GameObject.FindGameObjectWithTag("PlayerObj").GetComponent<HealthSystem>();
        health.maxPlayerHealth ++;
        health.currentPlayerHealth ++;
        modifierUI.text = "Modifier: \nTank";
    }

    public void Machinegun() 
    {
        GameObject.FindGameObjectWithTag("Gun").GetComponent<Gun>().gunCD = 0;
        modifierUI.text = "Modifier: \nMachine Gun";
    }

 public void Speed() 
    {
        GameObject.FindGameObjectWithTag("PlayerObj").GetComponent<PlayerMovement>().moveSpeed = 14;
        modifierUI.text = "Modifier: \nSpeedy";
    }

 public void Sniper() 
    {
        GameObject.FindGameObjectWithTag("Gun").GetComponent<Gun>().bulletSpeed = 40;
        life = 100;
        modifierUI.text = "Modifier: \nSniper";
    }

}