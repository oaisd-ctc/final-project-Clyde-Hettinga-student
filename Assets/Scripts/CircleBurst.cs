using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBurst : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int toSpawn, numberOfCircles;
    [SerializeField] private float maxSpeed, rotateBy;

    void Awake()
    {
        Bullet bullet = bulletPrefab.GetComponent<Bullet>();
        float currentArc = 360 / toSpawn;

        for (int i = 0; i < numberOfCircles; i++)
        {
            for (int j = 0; j < toSpawn; j++)
            {
                Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, currentArc * j + rotateBy * i));
            }

            bullet.SetSpeed(maxSpeed / (float)(i + 1));
        }

        Destroy(gameObject);
    }
}
