using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstParticle : MonoBehaviour
{
    float life;

    // Start is called before the first frame update
    void Start()
    {
        life = 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        life -= 0.1f;
        if (life <= 0)
        {
            Destroy(this.GameObject);
        }
    }
}
