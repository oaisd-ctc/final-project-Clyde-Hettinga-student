using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 3;
    [SerializeField] private int damage;
    [SerializeField] private Player player;
    [SerializeField] private Score bonus;
    private static float upperBound = 5.5f, lowerBound = -5.5f, rightBound = 5, leftBound = -5;

    void Start()
    {
        player = FindObjectOfType<Player>();
        bonus = FindObjectOfType<Score>();
    }

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;

        if (transform.position.y > upperBound || transform.position.y < lowerBound || transform.position.x > rightBound || transform.position.x < leftBound)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (tag.Equals("Bullet"))
        {
            if (other.gameObject.CompareTag("GrazeBox"))
            {
                int chance = Random.Range(0, 2);
                if (chance == 1) bonus.AddBonusPoints(1);
            }
            else if (other.gameObject.CompareTag("ParryRange"))
            {
                player.IncreaseCharge();
                Destroy(gameObject);
            }
            else if (other.gameObject.CompareTag("Player"))
            {
                if (!player.IsInvulnerable()) Health.TryDamage(other.gameObject, damage);
                Destroy(gameObject);
            }
        }
        else if (tag.Equals("PlayerBullet"))
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Health.TryDamage(other.gameObject, damage);
                Destroy(gameObject);
            }
        }
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
