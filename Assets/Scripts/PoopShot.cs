using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopShot : MonoBehaviour
{

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!(gameObject.tag == "Cow"))
        {
            Debug.Log("Kolizja koopa");
            Destroy(gameObject);
        }
     }
}
