using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : iEnemy
{
    public int hitpoint = 3;
    public float shotDelay = 1.0f;
    public float ySpeed = 3.0f,
        maxY = 3.0f,
        minY = 3.0f;
    private float direction = 1.0f;

    public override void Animate()
    {

    }

    public override void AnimateDeath()
    {

    }

    public override void Move()
    {
        Vector3 vec = transform.position;
        vec.y += ySpeed * direction * Time.deltaTime;
        this.transform.position = vec;
        if (vec.y > maxY && vec.y < minY)
            direction = -direction;
    }
    public new void OnCollisionEnter2D(Collision2D collision)
    {
        if (hitpoint == 1)
            base.OnCollisionEnter2D(collision);
        else
        {
            if(collision.gameObject.tag == "Poo")
                hitpoint--;
            Debug.Log("Boss hitpoints: " + hitpoint);
        }
    }
}
