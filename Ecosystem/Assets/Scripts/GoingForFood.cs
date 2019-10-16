using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoingForFood : MonoBehaviour
{
    public FirstParticle detector;

    // Start is called before the first frame update
    void Start()
    {
        detector = GetComponent<FirstParticle>();
    }

    // Update is called once per frame
    void Update()
    {
        if(detector.foodFound)
        {
            transform.Translate(detector.food.transform.position);
        }
    }
}
