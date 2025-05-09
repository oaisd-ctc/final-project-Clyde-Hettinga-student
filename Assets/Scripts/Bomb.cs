using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float speed, duration;
    [SerializeField] private int damage;
    [SerializeField] private Score bonus;

    void Start()
    {
        bonus = FindObjectOfType<Score>();
    }

    void Update()
    {
        if (duration > 0)
        {
            transform.localScale += new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, 0);
            duration -= Time.deltaTime;
        }
        else Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            int chance = Random.Range(0, 3);
            if (chance != 0) bonus.AddBonusPoints(1);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            Health.TryDamage(other.gameObject, damage);
        }
    }
}
