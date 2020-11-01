using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Cow : MonoBehaviour
{
    [SerializeField] float cowJumpPower = 12f;
    [SerializeField] GameObject poopShot;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] int poopShotLimit = 5;
    [SerializeField] int poopShotEquippedAmount = 5;
    [SerializeField] int milkAmount = 0;

    float lastTime = 0f;

    public bool isSuperFat = false;
    public Sprite[] spriteArray;
    public SpriteRenderer spriteRenderer;


    Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
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


        Debug.Log(isSuperFat);
    }

    private void makeSuperCow()
    {
        if (isSuperFat)
        {
            if (lastTime <= 5)
            {
                lastTime += Time.deltaTime;
                spriteRenderer.sprite = spriteArray[1];

            }
            else
            {
                isSuperFat = false;
                spriteRenderer.sprite = spriteArray[0];

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

    private void shouldLoadPoopAmmunition()
    {
        if (milkAmount == 2)
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
