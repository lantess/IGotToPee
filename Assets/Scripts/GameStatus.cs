using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [SerializeField] int scorePerEnemyDestroyed = 30;
    [SerializeField] int scorePerBossDestroyed = 100;
    [SerializeField] int scorePerMilkGathered = 15;
    [SerializeField] int scorePerStarGathered = 55;
    [SerializeField] int scorePerPoopGathered = 25;
    [SerializeField] TextMeshProUGUI scoreText;


    // state variables
    [SerializeField] int currentScore = 0;


    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void addToScorePerEnemy()
    {
        currentScore += scorePerEnemyDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void addToScorePerBoss()
    {
        currentScore += scorePerBossDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void addToScoreMilk()
    {
        currentScore += scorePerMilkGathered;
        scoreText.text = currentScore.ToString();
    }

    public void addToScorePerStar()
    {
        currentScore += scorePerStarGathered;
        scoreText.text = currentScore.ToString();
    }

    public void addToScorePerPoop()
    {
        currentScore += scorePerPoopGathered;
        scoreText.text = currentScore.ToString();
    }
}
