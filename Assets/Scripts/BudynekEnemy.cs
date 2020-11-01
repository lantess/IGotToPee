using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BudynekEnemy : iEnemy
{
    public float _xSpeed = 0.75f;


    public override void Move()
    {
        Vector3 pos = transform.position;
        pos.x -= _xSpeed * Time.deltaTime;
        transform.position = pos;
    }

    public override Vector4 getSpawnArea()
    {
        return new Vector4(-3.5f, -3.5f, 0.0f, 0.0f);
    }

}
