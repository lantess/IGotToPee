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

    public bool isSuperFat = false;


    Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.W))
        {
            rigidbody2D.velocity = new Vector2(0, cowJumpPower);
        }

        fire();

        if (isSuperFat)
        {

        }

        Debug.Log(isSuperFat);
    }

    private void fire()
    {
        if (Input.GetKeyDown(KeyCode.Space) && poopShotEquippedAmount > 0)
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
