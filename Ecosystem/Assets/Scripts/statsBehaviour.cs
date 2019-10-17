using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statsBehaviour : MonoBehaviour
{
    public Transform targetCamera;

    public Image healthBar;
    public Image foodBar;
    public Image drinkBar;
    public Text HealthText;
    public Text FoodText;
    public Text DrinkText;

    float drink;
    public float startDrink;
    float food;
    public float startFood;
    float health;
    public float startHealth;

    // Start is called before the first frame update
    void Start()
    {
        drink = startDrink;
        food = startFood;
        health = startHealth;

        targetCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / startHealth;
        foodBar.fillAmount = food / startFood;
        drinkBar.fillAmount = drink / startDrink;

        HealthText.text = health.ToString("0.0") + " / " + startHealth.ToString("0.0");
        FoodText.text = food.ToString("0.0") + " / " + startFood.ToString("0.0");
        DrinkText.text = drink.ToString("0.0") + " / " + startDrink.ToString("0.0");

        if(health <= 0)
        {
            health = 0;
        }
        else
        {
            if (food <= 0) food = 0;
            else food -= 0.01f;

            if (drink <= 0) drink = 0;
            else drink -= 0.02f;

            if (food <= 0 || drink <= 0)
            {
                health -= 0.02f;
            }
            else if(food >= 50 && drink >= 50)
            {
                if (health >= 100) health = 100;
                else health += 0.01f;
            }
        }

        this.transform.LookAt(targetCamera);
    }
}
