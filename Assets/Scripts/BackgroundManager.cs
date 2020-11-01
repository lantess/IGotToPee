using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject bgPrefab;
    public float yOffset = 0.0f;
    public float velocity = 1.5f;

    private List<GameObject> bgs = new List<GameObject>();
    void Start()
    {
        bgs.Add(Instantiate(bgPrefab, new Vector3(0.0f, yOffset, 0.0f), Quaternion.identity));
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
        if (bgs[0].transform.position.x < 0.0f && bgs.Count < 2)
            bgs.Add(Instantiate(bgPrefab, new Vector3(22.5f, yOffset, 0.0f), Quaternion.identity));
        else if (bgs[0].transform.position.x < -22.50f)
        {
            GameObject bg = bgs[0];
            bgs.RemoveAt(0);
            Destroy(bg);
        }
    }
}
