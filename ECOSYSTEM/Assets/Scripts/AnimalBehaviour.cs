using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBehaviour : MonoBehaviour
{
    public statsBehaviour stats;
    public FieldOfView fov;
    public Transform nearestFood;
    float distance;
    float prevDistance;

    void Start()
    {
        prevDistance = fov.viewRadius;
        stats = GetComponentInChildren<statsBehaviour>();
        fov = this.GetComponent<FieldOfView>();

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
            }
            else if (stats.food < stats.startFood/2)
            {
                FindVisibleResources(2);
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
                        }
                    }
                }
                break;


        }
    }

}
