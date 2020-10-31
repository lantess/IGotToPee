using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPowerUp : MonoBehaviour
{
    public float _xSpeed = 2.0f;
    public float _ySpeed = 1f;
    public float _yChangeSpeed = 1.0f;
    public float _cos = 0.0f;


    public void Move()
    {
        Vector3 pos = transform.position;
        pos.x -= _xSpeed * Time.deltaTime;
        pos.y += _ySpeed * Mathf.Cos(_cos) * Time.deltaTime;
        _cos += Time.deltaTime * _yChangeSpeed;
        transform.position = pos;
    }

    void Update()
    {
        Move();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cow")
        {
            collision.gameObject.GetComponent<Cow>().isSuperFat = true;
            Invoke("setSuperFatBack", 5f);
            FindObjectOfType<GameStatus>().addToScorePerStar();
            Destroy(gameObject);
        }

    }

    private void setSuperFatBack()
    {
        GetComponent<Cow>().isSuperFat = false;

    }



}
