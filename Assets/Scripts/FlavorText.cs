using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlavorText : MonoBehaviour
{
    [SerializeField] private Text title, location, music;

    public void ChallengeNextStage(int stageNumber, string whatDoing, string where)
    {
        if (stageNumber != 7) title.text = $"Stage {stageNumber} - {whatDoing}";
        else title.text = $"Challenge - {whatDoing}";
        location.text = where;
    }

    public void ChangeMusic(string title)
    {
        music.text = $"Now Playing: {title}";
    }
}
