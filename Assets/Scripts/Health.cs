using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private UnityEvent OnTakeDamage, OnDefeat;
    
    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0) OnDefeat.Invoke();
        else OnTakeDamage.Invoke();
    }

    public static void TryDamage(GameObject target, int damage)
    {
        Health health = target.GetComponent<Health>();

        if (health) health.TakeDamage(damage);
    }

    public void SetHealth(int health)
    {
        this.currentHealth = health;
    }

    public int GetHealth()
    {
        return currentHealth;
    }
}
