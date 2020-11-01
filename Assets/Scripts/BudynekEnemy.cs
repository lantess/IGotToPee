using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BudynekEnemy : iEnemy
{
    public float _xSpeed = 3.0f;
    public Sprite[] sprites;
    private int no;
    public void Start()
    {
        no = UnityEngine.Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[no];
        if (no == 0)
        {
            Vector3 v = transform.position;
            v.y -= 1.0f;
            transform.position = v;
        }
    }

    public override void Move()
    {
        Vector3 pos = transform.position;
        pos.x -= _xSpeed * Time.deltaTime;
        transform.position = pos;
    }

    public override Vector4 getSpawnArea()
    {
        return new Vector4(-1.75f, -1.75f, 0.0f, 0.0f);
    }

    public new void OnCollisionEnter2D(Collision2D collision)
    {

    }

}
