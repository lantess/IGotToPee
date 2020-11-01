using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinitePoop : MonoBehaviour
{

    public float _xSpeed = 2.0f;

    public void Move()
    {
        Vector3 pos = transform.position;
        pos.x -= _xSpeed * Time.deltaTime;
        transform.position = pos;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cow")
        {
            collision.gameObject.GetComponent<Cow>().hasInfinitePoop = true;
            FindObjectOfType<GameStatus>().addToScorePerPoop();
            Destroy(gameObject);
        }

    }
}
