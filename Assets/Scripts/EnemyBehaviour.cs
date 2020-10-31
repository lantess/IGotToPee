using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private float _xSpeed = 2.0f;
    private float _ySpeed = 20.0f;
    private int _yChangeSpeed = 10;
    private float _sin = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        Vector3 pos = transform.position;
        pos.x -= _xSpeed * Time.deltaTime;
        pos.y += _ySpeed * Mathf.Sin(_sin) * Time.deltaTime;
        _sin += Time.deltaTime*_yChangeSpeed;
        transform.position = pos;

    }
}
