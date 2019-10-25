using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class FoodBehaviour : MonoBehaviour
{
    public float nutritionStat;
    public float bonusFactor;

 
    
    void Start()
    {
        nutritionStat = 100;
        bonusFactor = UnityEngine.Random.Range(1f,5.1f);
    }

    
    void Update()
    {
        //nutritionStat -= 0.1f;


        this.transform.localScale = new Vector3((nutritionStat / 200), (nutritionStat / 200), (nutritionStat / 200)) / 0.5f;
        
    }
}
