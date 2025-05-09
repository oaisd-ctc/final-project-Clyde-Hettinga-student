using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPattern : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private Bullet bullet;
    [SerializeField] private int division, spawned;
    [SerializeField] private float speed, rotateBy, cutoff, delay, currentDelay;

    void Awake()
    {
        bullet = bulletPrefab.GetComponent<Bullet>();

        cutoff = 360f / division;
        if (rotateBy < 0) cutoff = -cutoff;

        currentDelay = delay;
    }

    void Update()
    {
        if (currentDelay <= 0)
        {
            for (int i = 0; i < division; i++)
            {
                Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, transform.rotation.z + rotateBy * spawned + cutoff * i));
            }

            bullet.SetSpeed(speed);

            spawned++;
            currentDelay = delay;
        }
        else currentDelay -= Time.deltaTime;

        if (rotateBy > 0 && rotateBy * spawned >= cutoff) Destroy(gameObject);
        else if (rotateBy < 0 && rotateBy * spawned <= cutoff) Destroy(gameObject);
    }
}
