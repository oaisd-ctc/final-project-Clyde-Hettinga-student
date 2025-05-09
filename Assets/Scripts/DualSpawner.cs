using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> setOne = new List<GameObject>(), setTwo = new List<GameObject>();
    [SerializeField] private float spawnRate = 1;
    [SerializeField] private int spawned = 0;

    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            child.SetActive(false);
        }

        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (spawned < setOne.Count)
        {
            setOne[spawned].SetActive(true);
            setTwo[spawned].SetActive(true);
            spawned++;

            yield return new WaitForSeconds(spawnRate);
        }
    }
}
