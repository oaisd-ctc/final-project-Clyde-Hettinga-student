using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcBurst : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int toSpawn, numberOfArcs;
    [SerializeField] private float maxSpeed, direction, angle;

    void Awake()
    {
        Bullet bullet = bulletPrefab.GetComponent<Bullet>();
        float miniArc = angle / (float)toSpawn;
        direction -= (angle / 2f);

        for (int i = 0; i < numberOfArcs; i++)
        {
            for (int j = 0; j < toSpawn; j++)
            {
                Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, miniArc * j + direction));
            }

            bullet.SetSpeed(maxSpeed / (float)(i + 1));
        }

        Destroy(gameObject);
    }
}
