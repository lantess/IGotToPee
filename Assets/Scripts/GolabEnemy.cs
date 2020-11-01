using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolabEnemy : iEnemy
{
    public float _xSpeed = 4.0f;

    public override void Move()
    {
        Vector3 pos = transform.position;
        pos.x -= _xSpeed * Time.deltaTime;
        transform.position = pos;
    }

    public new void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<GameStatus>().addToScorePerEnemy();
        base.OnCollisionEnter2D(collision);
    }

    public override Vector4 getSpawnArea()
    {
        return new Vector4(4.5f, -3.5f, 0.0f, 0.0f);
    }
}
