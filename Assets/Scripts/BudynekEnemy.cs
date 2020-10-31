using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BudynekEnemy : iEnemy
{
    public override void Animate()
    {

    }

    public override void AnimateDeath()
    {

    }

    public override void Move()
    {

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Kolizja budynek");
        Destroy(gameObject);
    }
}
