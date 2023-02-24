using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private int health;

    private void Awake()
    {
        health = 100;
    }
    public void GetDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("Game Over");
        }

        Debug.Log("Health : "+health);
    }
}
