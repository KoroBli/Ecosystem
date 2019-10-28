using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBehaviour : MonoBehaviour
{
    public statsBehaviour stats;
    public FieldOfView fov;
    public Transform nearestFood;
    public FoodBehaviour nutrients;
    float distance;
    float prevDistance;
    public Collider boca;
    public bool hungry;
    public bool eating;
    bool thirsty;
    public bool drinking;
    public bool digesting;

    void Start()
    {
        stats = GetComponentInChildren<statsBehaviour>();
        fov = this.GetComponent<FieldOfView>();
        prevDistance = fov.viewRadius;
        boca = gameObject.GetComponent<BoxCollider>();

        StartCoroutine("FindResources", 0.5f);
    }

    IEnumerator FindResources(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);

            if ((stats.drink < stats.startDrink/2 && !stats.criticalFood) || stats.criticalDrink)
            {
                FindVisibleResources(1);
                thirsty = true;
            }
            else if (stats.food < stats.startFood/2)
            {
                FindVisibleResources(2);
                hungry = true;
            }
        }
    }

    void FindVisibleResources(int need)
    {

        switch(need)
        {
            case 1:
                for(int i = 0; i < fov.visibleTargets.Count; i++)
                {
                    if(fov.visibleTargets[i].gameObject.tag == "Water")
                    {
                        // Para detectar agua hay que usar la grid
                    }
                    Debug.Log("Tengo sed.");
                }
                break;

            case 2:
                for (int i = 0; i < fov.visibleTargets.Count; i++)
                {
                    if(fov.visibleTargets[i].gameObject.tag == "Food")
                    {
                        Debug.Log("A comer!!!");
                        distance = Vector3.Distance(transform.position, fov.visibleTargets[i].gameObject.transform.position);

                        if(distance < prevDistance)
                        {
                            prevDistance = distance;
                            nearestFood = fov.visibleTargets[i].gameObject.transform;
                            nutrients = nearestFood.GetComponent<FoodBehaviour>();
                        }
                    }
                }
                break;


        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (hungry && other.gameObject.tag == "Food")
        {
            Debug.Log("ñam");
            eating = true;
            Eat();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (eating)
        {
            digesting = true;
            Invoke("DigestionTime", 10);
            eating = false;
            hungry = false;
        }
    }

    private void Eat()
    {
        if (eating)
        {
            if (stats.food < stats.startFood)
            {
                stats.food += 0.1f * nutrients.bonusFactor;
                nutrients.nutritionStat -= 0.1f;
            }
            else
            {
                eating = false;
                hungry = false;
                nearestFood = null;
                digesting = true;
                Invoke("DigestionTime", 10);
            }
        }
    }

    private void DigestionTime()
    {
        if (digesting)
        {
            digesting = false;
        }
    }

}
