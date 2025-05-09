using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies = new List<GameObject>();
    [SerializeField] private float spawnRate = 1;
    [SerializeField] private int spawned = 0;
    
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;

            enemies.Add(child);
            child.SetActive(false);
        }

        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (spawned < enemies.Count)
        {
            enemies[spawned].SetActive(true);
            spawned++;

            yield return new WaitForSeconds(spawnRate);
        }
    }
}
