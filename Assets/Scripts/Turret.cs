using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private List<GameObject> targets = new List<GameObject>();
    [SerializeField] private GameObject bullet;
    [SerializeField] private Animator animator;
    [SerializeField] private float activeFor = 7.5f;
    [SerializeField] private bool firing = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (targets.Count > 0) transform.up = targets[0].transform.position - transform.position;
        
        if (activeFor > 0) activeFor -= Time.deltaTime;
        else Destroy(gameObject);
    }

    private void RemoveInactive()
    {
        int i = 0;
        while (i < targets.Count)
        {
            if (targets[i]) i++;
            else targets.RemoveAt(i);
        }
    }

    IEnumerator Attack()
    {
        firing = true;
        animator.SetBool("Firing", true);

        while (targets.Count > 0)
        {
            RemoveInactive();
            if (targets.Count > 0) Instantiate(bullet, transform.position, transform.rotation);

            yield return new WaitForSeconds(.075f);
        }

        firing = false;
        animator.SetBool("Firing", false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy")) targets.Add(other.gameObject);

        if (!firing) StartCoroutine(Attack());
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy")) targets.Remove(other.gameObject);
    }
}
