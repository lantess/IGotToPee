using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolabEnemy : iEnemy
{
    public float _xSpeed = 2.0f;
    public float _ySpeed = 0.0f;
    public float _yChangeSpeed = 7.5f;
    public float _sin = 0.0f;


    public override void Move()
    {
        Vector3 pos = transform.position;
        pos.x -= _xSpeed * Time.deltaTime;
        pos.y += _ySpeed * Mathf.Sin(_sin) * Time.deltaTime;
        _sin += Time.deltaTime * _yChangeSpeed;
        transform.position = pos;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Kolizja gołąb");
        Destroy(gameObject);
    }
    public override void Animate()
    {

    }

    public override void AnimateDeath()
    {

    }
}
