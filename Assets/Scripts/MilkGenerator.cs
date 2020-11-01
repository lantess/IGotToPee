using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkGenerator : MonoBehaviour
{
    public GameObject milkPrefab;
    public float maxTimeOffset = 15.0f;
    public int minMilk = 5,
                maxMilk = 10;

    private float deltaTime = 0.0f,
                    currTimeOffset,
                currMilkdelta = 0.0f;
    private int milkCount = 0;
    private Vector3 pos = new Vector3(0.0f, 0.0f, 0.0f);
    // Start is called before the first frame update
    void Start()
    {
        currTimeOffset = UnityEngine.Random.Range(0.0f, maxTimeOffset);
    }

    // Update is called once per frame
    void Update()
    {
        if (milkCount == 0)
        {
            if (deltaTime < currTimeOffset)
                deltaTime += Time.deltaTime;
            else
            {
                deltaTime = 0.0f;
                milkCount = UnityEngine.Random.Range(minMilk, maxMilk);
                currTimeOffset = UnityEngine.Random.Range(milkCount, maxTimeOffset);
            }
        }
        else
        {
            if (currMilkdelta > 1.0f)
            {
                currMilkdelta = 0.0f;
                milkCount--;
                Instantiate(milkPrefab, pos, Quaternion.identity);
                pos.y += UnityEngine.Random.Range(-1, 1);
                if (pos.y > 4.0f)
                    pos.y = 4.0f;
                else if (pos.y < -4.0f)
                    pos.y = -4.0f;
            }
            else
                currMilkdelta += Time.deltaTime;
        }
    }
}
