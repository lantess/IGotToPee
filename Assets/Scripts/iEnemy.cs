﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class iEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Animate();
    }

    public abstract void Move();
    public abstract void Animate();

    public void OnDestroy()
    {
        AnimateDeath();
        Debug.Log("Destroy");
    }

    public abstract void AnimateDeath();

    public void OnCollisionEnter2D(Collision2D collision, string name)
    {
        Debug.Log("Kolizja "+name);
        if(collision.gameObject.name == "Circle")
            Destroy(gameObject);
    }
}
