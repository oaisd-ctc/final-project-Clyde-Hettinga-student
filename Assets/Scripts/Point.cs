using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Point : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private int type;
    [SerializeField] private Player player;
    [SerializeField] private Score bonus;
    private static float lowerBound = -5.5f;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        bonus = FindObjectOfType<Score>();
        rigidbody.AddForce(Vector3.up * 2, (ForceMode2D)ForceMode.VelocityChange);
    }

    private void Update()
    {
        if (transform.position.y <= lowerBound) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GrazeBox"))
        {
            switch (type)
            {
                case 0:
                    if (player.GetPower() < player.GetMaxPower()) player.IncreasePower();
                    else
                    {
                        int chance = Random.Range(0, 3);
                        if (chance == 2) bonus.AddBonusPoints(1);
                    }
                    break;
                case 1:
                    player.IncreaseCharge();
                    break;
                case 2:
                    bonus.AddBonusPoints(1);
                    break;
                default:
                    break;
            }

            Destroy(gameObject);
        }
    }
}
