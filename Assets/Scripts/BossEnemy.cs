using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : iEnemy
{
    public int hitpoint = 3;
    public float shotDelay = 1.0f;

    public override void Animate()
    {

    }

    public override void AnimateDeath()
    {

    }

    public override void Move()
    {

    }
    public new void OnCollisionEnter2D(Collision2D collision)
    {
        if(hitpoint == 1)
            base.OnCollisionEnter2D(collision);
    }
}
