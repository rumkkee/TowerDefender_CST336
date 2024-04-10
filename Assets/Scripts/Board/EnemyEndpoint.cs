using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEndpoint : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if(enemy != null)
        {
            PlayerStats.lives--;
            Destroy(enemy.gameObject);
            Debug.Log("Enemy destroyed");
        }
    }
}
