using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Milk : MonoBehaviour
{
    public float _xSpeed = 3.0f;


    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cow")
        {
            FindObjectOfType<GameStatus>().addToScoreMilk();
            Destroy(gameObject);
        }
    }

    public void Move()
    {
        Vector3 pos = transform.position;
        pos.x -= _xSpeed * Time.deltaTime;
        transform.position = pos;
    }

}
