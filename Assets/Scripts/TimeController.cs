using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public float delta = 0.01f;
    public float update = 1.5f;
    private float counter = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (counter < update)
            counter += Time.deltaTime;
        else
        {
            counter = 0.0f;
            Time.timeScale += delta;
        }
    }
}
