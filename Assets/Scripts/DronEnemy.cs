using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronEnemy : iEnemy
{
    public float _xSpeed = 2.0f;
    public float _ySpeed = 1.0f;
    public float _yChangeSpeed = 1.0f;
    public float _cos = 0.0f;
    public override void Move()
    {
        Vector3 pos = transform.position;
        pos.x -= _xSpeed * Time.deltaTime;
        pos.y += _ySpeed * Mathf.Cos(_cos) * Time.deltaTime;
        _cos += Time.deltaTime * _yChangeSpeed;
        transform.position = pos;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Kolizja dron");
        Destroy(gameObject);
    }
    public override void Animate()
    {

    }

    public override void AnimateDeath()
    {

    }
}
