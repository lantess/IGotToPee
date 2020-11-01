using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpGenerator : MonoBehaviour
{
    public GameObject[] prefabs;
    public float spawnTimeout = 20.0f;

    private float spawnDelta = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnDelta < spawnTimeout)
            spawnDelta += Time.deltaTime;
        else
        {
            spawnDelta = 0.0f;
            int no = UnityEngine.Random.Range(0, prefabs.Length);
            Instantiate(prefabs[no], transform.position, Quaternion.identity);
        }
    }
}
