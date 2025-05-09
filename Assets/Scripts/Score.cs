using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private static int currentScore, bonus;
    [SerializeField] private Text scoreText, bonusCounter;

    void Awake()
    {
        currentScore = 0;
        bonus = 0;
    }

    void Update()
    {
        if (currentScore < 10) scoreText.text = $"Score: 000000000{currentScore}";
        else if (currentScore < 100) scoreText.text = $"Score: 00000000{currentScore}";
        else if (currentScore < 1000) scoreText.text = $"Score: 0000000{currentScore}";
        else if (currentScore < 10000) scoreText.text = $"Score: 000000{currentScore}";
        else if (currentScore < 100000) scoreText.text = $"Score: 00000{currentScore}";
        else if (currentScore < 1000000) scoreText.text = $"Score: 0000{currentScore}";
        else if (currentScore < 10000000) scoreText.text = $"Score: 000{currentScore}";
        else if (currentScore < 100000000) scoreText.text = $"Score: 00{currentScore}";
        else if (currentScore < 1000000000) scoreText.text = $"Score: 0{currentScore}";
        else scoreText.text = $"Score: {currentScore}";

        bonusCounter.text = $"Bonus: {bonus}";
    }

    public void Increase(int toAdd)
    {
        currentScore += toAdd;
    }

    public void AddBonusPoints(int toAdd)
    {
        bonus += toAdd;
    }

    public static int GetScore()
    {
        return currentScore;
    }

    public static int GetBonusPoints()
    {
        return bonus;
    }
}
