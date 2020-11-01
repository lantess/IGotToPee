using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject bgPrefab;
    public float velocity = 1.5f;

    private List<GameObject> bgs = new List<GameObject>();
    void Start()
    {
        bgs.Add(Instantiate(bgPrefab, new Vector3(17.2f, 0.0f, 0.0f), Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject bg in bgs)
        {
            Vector3 pos = bg.transform.position;
            pos.x -= velocity * Time.deltaTime;
            bg.transform.position = pos;
        }
    }
}
