using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollector : MonoBehaviour
{
    public string[] tagsToCollect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        for(int i = 0; i < tagsToCollect.Length; i++)
        {
            if (collision.gameObject.tag == tagsToCollect[i])
                Destroy(collision.gameObject);
        }
    }
}
