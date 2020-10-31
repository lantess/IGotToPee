using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BudynekEnemy : iEnemy
{
    public float _xSpeed = 0.75f;

    public override void Animate()
    {

    }

    public override void AnimateDeath()
    {

    }

    public override void Move()
    {
        Vector3 pos = transform.position;
        pos.x -= _xSpeed * Time.deltaTime;
        transform.position = pos;
    }
}
