using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsDisplay : MonoBehaviour
{
    [SerializeField] private Text skill, charge, power;
    [SerializeField] private Image[] hearts, lost;
    [SerializeField] private Player player;
    [SerializeField] private Health playerHealth;

    void Start()
    {
        player = FindObjectOfType<Player>();
        playerHealth = player.GetComponent<Health>();
    }

    void Update()
    {
        skill.text = $"Skill: {player.Ability()}";
        charge.text = $"({player.GetCharge()} / {player.GetTotal()})";
        power.text = $"Power: {player.GetPower()}";

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerHealth.GetHealth()) hearts[i].enabled = true;
            else hearts[i].enabled = false;
        }

        for (int i = 0; i < lost.Length; i++)
        {
            if (i > playerHealth.GetHealth() - 1) lost[i].enabled = true;
            else lost[i].enabled = false;
        }
    }
}
