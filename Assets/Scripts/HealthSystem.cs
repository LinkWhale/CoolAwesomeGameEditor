using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HealthSystem : MonoBehaviour
{
    public float maxPlayerHealth;
    public float currentPlayerHealth;
    public float cooldown;
    private bool isOnCooldown = false;

    [SerializeField]
    private TextMeshProUGUI healthUI;

    void Start()
    {
        Invoke("UI", 0.5f);
    }

    void UI()
    {
        healthUI.text = $"Health: {currentPlayerHealth}/{maxPlayerHealth}";
    }

    public void Damage()
    {
        if(isOnCooldown == false)
        {
        currentPlayerHealth -= 1;
        healthUI.text = $"Health: {currentPlayerHealth}/{maxPlayerHealth}";
        StartCoroutine(ExampleCoroutine());
        }
    }

    IEnumerator ExampleCoroutine()
    {
        isOnCooldown = true;

        yield return new WaitForSeconds(cooldown);

        isOnCooldown = false;

    }

    void Update() {
        if(currentPlayerHealth == 0) {
            SceneManager.LoadScene("DeathScreen");
        }
    }

}
