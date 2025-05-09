using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositePattern : MonoBehaviour
{
    [SerializeField] private List<GameObject> patterns = new List<GameObject>();
    [SerializeField] private List<float> offsets = new List<float>();
    [SerializeField] private float cooldown;

    void Awake()
    {
        Instantiate(patterns[0], transform.position, Quaternion.identity);
        cooldown = offsets[0];

        patterns.RemoveAt(0);
        offsets.RemoveAt(0);
    }

    void Update()
    {
        if (patterns.Count > 0)
        {
            if (cooldown <= 0)
            {
                Instantiate(patterns[0], transform.position, Quaternion.identity);
                cooldown = offsets[0];

                patterns.RemoveAt(0);
                offsets.RemoveAt(0);
            }
            else cooldown -= Time.deltaTime;
        }
        else Destroy(gameObject);
    }
}
