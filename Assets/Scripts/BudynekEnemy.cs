using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BudynekEnemy : iEnemy
{
    public float _xSpeed = 1.5f;
    public Sprite[] sprites;
    public void Start()
    {
        int no = UnityEngine.Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[no];
        Debug.Log("Drzewo: " + transform.localScale.y);
    }

    public override void Move()
    {
        Vector3 pos = transform.position;
        pos.x -= _xSpeed * Time.deltaTime;
        transform.position = pos;
    }

    public override Vector4 getSpawnArea()
    {
        return new Vector4(-2.5f, -2.5f, 0.0f, 0.0f);
    }

    public new void OnCollisionEnter2D(Collision2D collision)
    {

    }

}
