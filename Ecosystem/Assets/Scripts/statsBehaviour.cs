using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statsBehaviour : MonoBehaviour
{
    public AnimalBehaviour animal;
    
    public Transform targetCamera;

    public Image healthBar;
    public Image foodBar;
    public Image drinkBar;
    public Text HealthText;
    public Text FoodText;
    public Text DrinkText;

    public float drink;
    public float startDrink;
    public float food;
    public float startFood;
    float health;
    public float startHealth;
    public bool criticalFood;
    public bool criticalDrink;

    // Start is called before the first frame update
    void Start()
    {
        animal = GetComponentInParent<AnimalBehaviour>();
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
            Debug.Log("Estoy muerto bibo");
        }
        else
        {
            if (!animal.digesting)
            {
                if (food <= 0) food = 0;
                else if (food > startFood) food = startFood;
                else
                {
                    if (!animal.eating)
                    {
                        food -= 0.01f;
                    }
                }
            }

            if (drink <= 0) drink = 0;
            else if (drink > startDrink) drink = startDrink;
            else
            {
                if (!animal.drinking)
                {
                   //drink -= 0.02f;
                }
                
            }

            if (drink <= startDrink/4) criticalDrink = true;
            else if (drink > startDrink/4) criticalDrink = false;

            if (food <= startFood/4) criticalFood = true;
            else if (food > startFood/4) criticalFood = false;

            if (food <= 0 || drink <= 0)
            {
                if (health <= 0) health = 0;
                else health -= 0.02f;
            }
            else if(food >= startFood/2 && drink >= startDrink/2)
            {
                if (health >= startHealth) health = startHealth;
                else health += 0.05f;
            }
        }

        this.transform.LookAt(targetCamera);
    }
}
