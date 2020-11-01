using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronEnemy : iEnemy
{
    public float _xSpeed = 4.0f;
    public float _ySpeed = 1.0f;
    public float _yChangeSpeed = 1.5f;
    public float _cos = 0.0f;
    public override void Move()
    {
        Vector3 pos = transform.position;
        pos.x -= _xSpeed * Time.deltaTime;
        pos.y += _ySpeed * Mathf.Cos(_cos) * Time.deltaTime;
        _cos += Time.deltaTime * _yChangeSpeed;
        transform.position = pos;
    }


    public new void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<GameStatus>().addToScorePerEnemy();
        base.OnCollisionEnter2D(collision);
    }

    public override Vector4 getSpawnArea()
    {
        return new Vector4(3.5f, -2.5f, 0.0f, 0.0f);
    }

}
