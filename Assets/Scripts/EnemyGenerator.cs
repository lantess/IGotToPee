using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject[] enemies,
                    bosses;
    public float generatorTimeout = 4.0f,
                maxEnemies = 1.0f,
                multiplier = 1.1f,
                difficultyTimeout = 15.0f,
                bossOffset = 60.0f;

    public bool isRunning = true;

    private float generatorDelta = 4.0f,
                    difficultyDelta = 0.0f,
                    bossDelta = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning) {
            if (bossDelta >= bossOffset)
                generateBoss();
            else
                bossDelta += Time.deltaTime;

            if (generatorDelta >= generatorTimeout)
                generateEnemy();
            else
                generatorDelta += Time.deltaTime;

            if(difficultyDelta >= difficultyTimeout)
            {
                maxEnemies *= multiplier;
                generatorTimeout /= multiplier;
            }
        }
    }

    private void generateBoss()
    {
        throw new NotImplementedException();
    }

    private void generateEnemy()
    {
        
    }
}
