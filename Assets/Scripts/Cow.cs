using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Cow : MonoBehaviour
{
    [SerializeField] float cowJumpPower = 12f;
    [SerializeField] GameObject poopShot;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] int poopShotLimit = 5;
    [SerializeField] int poopShotEquippedAmount = 5;
    [SerializeField] int milkAmount = 0;

    [SerializeField] GameObject deathVFX;

    float lastTime = 0f;
    public bool isSuperFat = false;

    public Sprite[] spriteArray;
    public SpriteRenderer spriteRenderer;

    public float Speed = 1;
    private Renderer rend;

    Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rend = GetComponent<Renderer>();
        Time.timeScale = 1.0f;
    }
    public void LimitByCamera()
    {
        float height = GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize;
        Vector3 pos = transform.position;
        float max = height - transform.localScale.y / 2;
        if (pos.y > max)
            pos.y = max;
        else if (pos.y < -max+1)
            pos.y = -max+1;
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.W))
        {
            rigidbody2D.velocity = new Vector2(0, cowJumpPower);
        }

        fire();
        makeSuperCow();
        LimitByCamera();
    }

    private void makeSuperCow()
    {
        if (isSuperFat)
        {
            if (lastTime <= 5)
            {
                lastTime += Time.deltaTime;
                spriteRenderer.sprite = spriteArray[1];
                rend.material.SetColor("_Color", HSBColor.ToColor(new HSBColor(Mathf.PingPong(Time.time * Speed, 1), 1, 1)));

            }
            else
            {
                isSuperFat = false;
                spriteRenderer.sprite = spriteArray[0];
                rend.material.SetColor("_Color", Color.white);

            }
        }
    }

    private void fire()
    {
        if (Input.GetKeyDown(KeyCode.Space) && poopShotEquippedAmount > 0 && !isSuperFat)
        {
            GameObject poop = Instantiate(poopShot, transform.position + new Vector3(1,0,0), Quaternion.identity) as GameObject;
            poop.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0);

            poopShotEquippedAmount--;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mleko") 
        {
            Debug.Log(milkAmount + "ILOSC MLEKA");
            milkAmount++;
            shouldLoadPoopAmmunition();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isSuperFat)
        {
            Destroy(gameObject);
            GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
            Destroy(explosion, 1f);
            Time.timeScale = 0.1f;
            SceneManager.LoadScene("GameOverScene");
        }
    }

    private void shouldLoadPoopAmmunition()
    {
        if (milkAmount >= 2)
        {
            if (poopShotEquippedAmount < poopShotLimit)
            {
                milkAmount = 0;
                poopShotEquippedAmount++;
            }
            else
            {
                milkAmount = 2;
            }
        }
    }

}
