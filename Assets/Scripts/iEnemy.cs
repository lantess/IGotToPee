﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class iEnemy : MonoBehaviour
{
    public abstract Vector4 getSpawnArea();
    [SerializeField] GameObject deathVFX;

    // Update is called once per frame
    void Update()
    {
        Move();
        LimitByCamera();
    }

    public abstract void Move();
    public void LimitByCamera()
    {
        float height = GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize;
        Vector3 pos = transform.position;
        float max = height - transform.localScale.y / 2;
        if (pos.y > max)
            pos.y = max;
        else if (pos.y < -max)
            pos.y = -max;
        transform.position = pos;
    }

    public void OnDestroy()
    {
        Debug.Log("Destroy");
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Kolizja "+gameObject.tag);
        if (collision.gameObject.tag == "Poo")
            Die();
    }

    public void Die()
    {
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(explosion, 1f);

    }
}
