using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float health;
    public float min=0;
    public float max=100;

    [SerializeField]
    UnityEvent onDead;

    [SerializeField]
    UnityEvent onTakeDamage;


    private void Start()
    {
        health = max;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        onTakeDamage?.Invoke();
        if (health <= min)
        {
            onDead?.Invoke();
            enabled = false;
        }
    }

    public void Destroy()
    { 
        Destroy(gameObject);
    }
}
