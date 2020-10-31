using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    [SerializeField] float cowJumpPower = 1f;
    [SerializeField] GameObject poopRocket;
    [SerializeField] float projectileSpeed = 10f;

    Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.W))
        {
            rigidbody2D.velocity = new Vector2(0, cowJumpPower);
        }

        fire();
    }

    private void fire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject poop = Instantiate(poopRocket, transform.position, Quaternion.identity) as GameObject;
            poop.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0);

        }
    }
}
