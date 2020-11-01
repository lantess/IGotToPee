using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossEnemy : iEnemy
{
    public GameObject forkPrefab;
    public int hitpoint = 3;
    public float shotDelay = 3.0f,
        shootTimer = 0.0f,
        ySpeed = 3.0f,
        maxY = 2.9f,
        minY = -2.9f;
    private float direction = 1.0f;
    //[SerializeField] GameObject deathVFX;


    public override void Move()
    {
        Vector3 vec = transform.position;
        vec.y += ySpeed * direction * Time.deltaTime;
        if (vec.x > 5)
            vec.x -= ySpeed * Time.deltaTime;
        this.transform.position = vec;
        if (vec.y >= maxY || vec.y <= minY)
            direction = -direction;
        
        Shoot();
    }

    private void Shoot()
    {
        if (shootTimer < shotDelay)
            shootTimer += Time.deltaTime;
        else
        {
            shootTimer = 0.0f;
            ejectProjectile();
        }
    }

    private void ejectProjectile()
    {
        Vector3 pos = transform.position;
        pos.x -=2;
        GameObject target = GameObject.Find("Cow");
        GameObject missle = Instantiate(forkPrefab, pos, rotateTo(target)) as GameObject;
        missle.GetComponent<Rigidbody2D>().velocity = target.transform.position;
    }

    private Quaternion rotateTo(GameObject target)
    {
        Vector3 vec = target.transform.position - transform.position;
        float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        return q;

    }

    public new void OnCollisionEnter2D(Collision2D collision)
    {
        if (hitpoint == 1)
        {
            base.OnCollisionEnter2D(collision);
/*            FindObjectOfType<GameStatus>().addToScorePerBoss();
            Destroy(gameObject);
            GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
            Destroy(explosion, 1f);*/
        }
        else
        {
            if (collision.gameObject.tag == "Poo")
                hitpoint--;
            Debug.Log("Boss hitpoints: " + hitpoint);
        }
    }

    public new void OnDestroy()
    {
        GameObject.Find("EnemyGenerator").GetComponent<EnemyGenerator>().isRunning = true;

        base.OnDestroy();
    }
    public override Vector4 getSpawnArea()
    {
        return new Vector4(3f, -3f, 0.0f, 0.0f);
    }
}
