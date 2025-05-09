using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MultiPoints : MonoBehaviour
{
    [SerializeField] private GameObject center, ring;
    [SerializeField] private int toSpawn;
    [SerializeField] private float radius, cooldown;

    void Awake()
    {
        Instantiate(center, transform.position, Quaternion.identity);

        cooldown = .2f;
    }

    void Update()
    {
        if (cooldown <= 0)
        {
            for (int i = 0; i < toSpawn; i++)
            {
                Vector3 place = Random.insideUnitCircle * radius;

                Instantiate(ring, transform.position + place, Quaternion.identity);
            }

            Destroy(gameObject);
        }
        else cooldown -= Time.deltaTime;
    }
}
