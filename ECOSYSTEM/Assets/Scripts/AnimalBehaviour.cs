using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBehaviour : MonoBehaviour
{
    public statsBehaviour stats;
    public FieldOfView fov;
    void Start()
    {
        stats = GetComponentInChildren<statsBehaviour>();
        fov = this.GetComponent<FieldOfView>();

        StartCoroutine("FindResources", 0.5f);
    }

    IEnumerator FindResources(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);

           // if (stats.drink < stats.startDrink/2)
            //{
              //  FindVisibleResources(1);
            //}
            if (stats.food < stats.startDrink/2)
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
                    Debug.Log("Tengo sed.");
                }
                break;

            case 2:
                for (int i = 0; i < fov.visibleTargets.Count; i++)
                {
                    if(fov.visibleTargets[i].gameObject.tag == "Food")
                    {
                        Debug.Log("A comer!!!");
                    }
                }
                break;


        }
    }

}
