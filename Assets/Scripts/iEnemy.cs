using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class iEnemy : MonoBehaviour
{
    public abstract Vector4 getSpawnArea();
    [SerializeField] public GameObject deathVFX;
    [SerializeField] public Cow cow;

    public float Speed = 1;

    // Update is called once per frame
    public void Update()
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
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Kolizja "+gameObject.tag);
        try
        {
            if (collision.gameObject.tag == "Poo" || (collision.gameObject.GetComponent<Cow>().isSuperFat))
                Die();
        } catch (NullReferenceException e)
        {

        }
    }

    public void Die()
    {
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(explosion, 1f);
    }
}
