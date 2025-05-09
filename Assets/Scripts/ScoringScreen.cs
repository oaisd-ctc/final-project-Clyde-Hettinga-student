using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringScreen : MonoBehaviour
{
    [SerializeField] private int baseScore, bonus, difficulty, hitless, finalScore, show;
    [SerializeField] private float timer = 1, difMult, hitMult;
    [SerializeField] private Text initial, add, final;

    void Awake()
    {
        baseScore = Score.GetScore();
        bonus = Score.GetBonusPoints();
        difficulty = GameManager.GetDifficulty();
        hitless = Player.GetHits();

        show = 0;

        initial.text = $"";
        add.text = "";
        final.text = "";
    }

    void Update()
    {
        if (timer <= 0)
        {
            switch (show)
            {
                case 0:
                    if (baseScore < 10) initial.text = $"Score: 000000000{baseScore}";
                    else if (baseScore < 100) initial.text = $"Score: 00000000{baseScore}";
                    else if (baseScore < 1000) initial.text = $"Score: 0000000{baseScore}";
                    else if (baseScore < 10000) initial.text = $"Score: 000000{baseScore}";
                    else if (baseScore < 100000) initial.text = $"Score: 00000{baseScore}";
                    else if (baseScore < 1000000) initial.text = $"Score: 0000{baseScore}";
                    else if (baseScore < 10000000) initial.text = $"Score: 000{baseScore}";
                    else if (baseScore < 100000000) initial.text = $"Score: 00{baseScore}";
                    else if (baseScore < 1000000000) initial.text = $"Score: 0{baseScore}";
                    else initial.text = $"Score: {baseScore}";

                    timer = 1.25f;
                    show++;
                    break;
                case 1:
                    add.text = $"Bonus: {bonus}\n\n";
                    timer = .75f;
                    show++;
                    break;
                case 2:
                    switch (difficulty)
                    {
                        case 0:
                            difMult = .9f;
                            add.text = $"Bonus: {bonus}\nBeginner: X 0.9\n";
                            break;
                        case 1:
                            difMult = 1;
                            add.text = $"Bonus: {bonus}\nEasy: X 1.0\n";
                            break;
                        case 2:
                            difMult = 1;
                            add.text = $"Bonus: {bonus}\nNormal: X 1.0\n";
                            break;
                        case 3:
                            difMult = 1.1f;
                            add.text = $"Bonus: {bonus}\nHard: X 1.1\n";
                            break;
                        case 4:
                            difMult = 1.25f;
                            add.text = $"Bonus: {bonus}\nExpert: X 1.25\n";
                            break;
                        case 5:
                            difMult = 1.5f;
                            add.text = $"Bonus: {bonus}\nChallenge: X 1.5\n";
                            break;
                        default:
                            break;
                    }
                    timer = .75f;
                    show++;
                    break;
                case 3:
                    if (hitless == 1) add.text += $"{hitless} Hit: X ";
                    else add.text += $"{hitless} Hits: X ";

                    if (hitless == 0)
                    {
                        add.text += "1.25";
                        hitMult = 1.25f;
                    }
                    else if (hitless < 6)
                    {
                        add.text += "0.95";
                        hitMult = .95f;
                    }
                    else if (hitless < 11)
                    {
                        add.text += "0.8";
                        hitMult = .8f;
                    }
                    else if (hitless < 21)
                    {
                        add.text += "0.7";
                        hitMult = .7f;
                    }
                    else if (hitless < 26)
                    {
                        add.text += "0.6";
                        hitMult = .6f;
                    }
                    else
                    {
                        add.text += "0.5";
                        hitMult = .5f;
                    }

                    timer = 2.75f;
                    show++;
                    break;
                case 4:
                    finalScore = baseScore + (int)(bonus * difMult * hitMult);

                    if (finalScore < 10) final.text = $"Final Score: 000000000{finalScore}";
                    else if (finalScore < 100) final.text = $"Final Score: 00000000{finalScore}";
                    else if (finalScore < 1000) final.text = $"Final Score: 0000000{finalScore}";
                    else if (finalScore < 10000) final.text = $"Final Score: 000000{finalScore}";
                    else if (finalScore < 100000) final.text = $"Final Score: 00000{finalScore}";
                    else if (finalScore < 1000000) final.text = $"Final Score: 0000{finalScore}";
                    else if (finalScore < 10000000) final.text = $"Final Score: 000{finalScore}";
                    else if (finalScore < 100000000) final.text = $"Final Score: 00{finalScore}";
                    else if (finalScore < 1000000000) final.text = $"Final Score: 0{finalScore}";
                    else final.text = $"Final Score: {finalScore}";

                    show++;
                    break;
                default:
                    break;
            }
        }
        else timer -= Time.deltaTime;
    }
}
