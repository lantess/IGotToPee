using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolabEnemy : iEnemy
{
    public float _xSpeed = 2.0f;

    public override void Move()
    {
        Vector3 pos = transform.position;
        pos.x -= _xSpeed * Time.deltaTime;
        transform.position = pos;
    }
    public override void Animate()
    {

    }

    public override void AnimateDeath()
    {

    }
}
