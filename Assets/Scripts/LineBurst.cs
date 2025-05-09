using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBurst : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int toSpawn;
    [SerializeField] private float maxSpeed, angle;
    [SerializeField] private bool targetPlayer;

    void Awake()
    {
        if (targetPlayer)
        {
            Player player = FindObjectOfType<Player>();
            transform.up = player.transform.position - transform.position;
        }

        Bullet bullet = bulletPrefab.GetComponent<Bullet>();

        for (int i = 0; i < toSpawn; i++)
        {
            if (targetPlayer) Instantiate(bulletPrefab, transform.position, transform.rotation);
            else Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, angle));
            bullet.SetSpeed(maxSpeed / (float)(i + 1));
        }

        Destroy(gameObject);
    }
}
