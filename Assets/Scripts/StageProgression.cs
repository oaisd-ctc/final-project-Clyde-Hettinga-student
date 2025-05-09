using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class StageProgression : MonoBehaviour
{
    [SerializeField] private List<float> timers = new List<float>();
    [SerializeField] private List<GameObject> enemies = new List<GameObject>();
    [SerializeField] private bool bossActive, runningDialogue;
    [SerializeField] private float stall;
    
    void Start()
    {
        foreach (GameObject g in enemies) g.SetActive(false);
    }

    void Update()
    {
        if (!runningDialogue)
        {
            if (!bossActive)
            {
                if (stall <= 0)
                {
                    if (enemies.Count > 0 && timers.Count > 0)
                    {
                        enemies[0].SetActive(true);

                        if (!bossActive)
                        {
                            stall = timers[0];

                            timers.RemoveAt(0);
                            enemies.RemoveAt(0);
                        }
                    }
                }
                else stall -= Time.deltaTime;
            }

            if (enemies.Count == 0) GameManager.GoToScreen(6);
        }
    }

    public void SetBossActive()
    {
        bossActive = true;
    }

    public void KickBoss()
    {
        bossActive = false;
    }

    public bool FightingBoss()
    {
        return bossActive;
    }


    public void SetDialogue(bool b)
    {
        runningDialogue = b;
    }

    public bool DialogueCurrentlyRunning()
    {
        return runningDialogue;
    }
}
