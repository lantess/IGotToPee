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

    float lastTimeInfinitePoop = 0f;
    public bool hasInfinitePoop = false;

    public SpriteRenderer spriteRenderer;

    public float Speed = 1;
    private Renderer rend;

    public Animator animator;

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
            animator.SetBool("isJumping", true);
            animator.SetBool("hasLanded", false);
        }

        fire();
        makeSuperCow();
        makeInfinitePoop();
        LimitByCamera();

        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("isJumping", false);
        }
    }

    private void makeSuperCow()
    {
        if (isSuperFat)
        {
            animator.SetBool("isFat", true);

            if (lastTime <= 5)
            {
                lastTime += Time.deltaTime;
                rend.material.SetColor("_Color", HSBColor.ToColor(new HSBColor(Mathf.PingPong(Time.time * Speed, 1), 1, 1)));
            }
            else
            {
                isSuperFat = false;
                animator.SetBool("isFat", false);
                rend.material.SetColor("_Color", Color.white);
                lastTime = 0.0f;
            }
        }
    }

    private void makeInfinitePoop()
    {
        if (hasInfinitePoop)
        {
            if (lastTimeInfinitePoop <= 5)
            {
                lastTimeInfinitePoop += Time.deltaTime;
                poopShotEquippedAmount = poopShotLimit;
            }
            else
            {
                hasInfinitePoop = false;
            }
        }
    }

    private void fire()
    {
        if (Input.GetKeyDown(KeyCode.Space) && poopShotEquippedAmount > 0 && !isSuperFat)
        {
            animator.SetBool("isPooping",true);
            

            GameObject poop = Instantiate(poopShot, transform.position + new Vector3(1,0,0), Quaternion.identity) as GameObject;
            poop.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0);

            poopShotEquippedAmount--;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("isPooping", false);
            
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
        if (collision.gameObject.tag == "Floor")
        {
            animator.SetBool("hasLanded", true);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isSuperFat)
        {
            Destroy(gameObject);
            GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
            Destroy(explosion, 1f);
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


    public bool getIsSuperFat()
    {
        return isSuperFat;
    }

}
