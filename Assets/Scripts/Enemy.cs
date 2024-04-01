using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    public float health = 100f;

    public int worth = 50;

    public GameObject deathEffect;

    public void Start()
    {
        speed = startSpeed;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Slow(float amount)
    {
        speed = startSpeed * (1f - amount);
    }

    private void Die()
    {
        PlayerStats.money += worth;

        Instantiate(deathEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

}
