using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject[] enemies,
                    bosses;

    public float generatorTimeout = 4.0f,
                multiplier = 1.1f,
                difficultyTimeout = 15.0f,
                bossPerEnemies = 10.0f;
    public bool isRunning = true;

    private float generatorDelta = 0.0f,
                    difficultyDelta = 0.0f,
                    bossDelta = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            if (generatorDelta < generatorTimeout)
                generatorDelta += Time.deltaTime;
            else
            {
                generatorDelta = 0.0f;
                generateEnemy();
            }

            if (difficultyDelta < difficultyTimeout)
                difficultyDelta += Time.deltaTime;
            else
            {
                difficultyDelta = 0.0f;
                changeDifficulty();
            }
        }
    }

    private void changeDifficulty()
    {
        generatorTimeout /= multiplier;
        bossPerEnemies /= multiplier;
    }

    private void generateEnemy()
    {
        if(bossDelta < bossPerEnemies)
        {
            bossDelta += 1.0f;
            int no = (int)UnityEngine.Random.Range(0, enemies.Length);
            Vector3 tran = transform.position;
            Vector4 range = enemies[no].GetComponent<iEnemy>().getSpawnArea();
            Debug.Log(range.x + " " + range.y);
            tran.y += UnityEngine.Random.Range(range.x, range.y);
            Instantiate(enemies[no], tran, transform.rotation);
        }
        else
        {
            bossDelta = 0.0f;
            int no = (int)UnityEngine.Random.Range(0, bosses.Length);
            Vector3 tran = transform.position;
            Vector4 range = enemies[no].GetComponent<iEnemy>().getSpawnArea();
            tran.y += UnityEngine.Random.Range(range.x, range.y);
            Instantiate(bosses[no], tran, transform.rotation);
            isRunning = false;
        }
    }
}
