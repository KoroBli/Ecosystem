using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstParticle : MonoBehaviour
{
    public float life;
    public int vResolution; // Numero de rayos
    Ray[] vRay; // Rayos
    RaycastHit[] rayHit; // Deteccion de colision
    public int vRange; // Distancia de vision
    float dPRay; // Distancia entre rayos
    public bool foodFound;
    public GameObject food;

    // Start is called before the first frame update
    void Start()
    {
        dPRay = interRayDistance(vResolution);

        vRay = new Ray[vResolution];
        rayHit = new RaycastHit[vResolution];

        vRange = 15;
        life = 10000.0f;
        foodFound = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*for (int i = 0; i < vRay.Length; i++)
        {
            vRay[i].origin = this.transform.position;
            vRay[i].direction = new Vector3(transform.forward.x + (dPRay * i) - 1, transform.forward.y, transform.forward.z);
        }*/

        life -= 0.01f;

        //Debug.Log("Life: " + life);
        Debug.Log("Distance: " + dPRay);
        Debug.Log("Direction: " + transform.forward.x);
        if (life <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < vRay.Length; i++)
        {
            Debug.DrawRay(vRay[i].origin, vRay[i].direction * vRange);

            //if(Physics.SphereCast(vRay[i], )

            /*if (Physics.Raycast(vRay[i], out rayHit[i], vRange))
            {
                if (rayHit[i].collider.gameObject.tag == "Food")
                {
                    Debug.Log("Food!");
                    foodFound = true;
                    food = rayHit[i].collider.gameObject;
                }
            }*/
        }
    }

    float interRayDistance(int rayResolution)
    {
        float distance;

        distance = (2 / ((float)rayResolution - 1));

        return distance;
    }
}
