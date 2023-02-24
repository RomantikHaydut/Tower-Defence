using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    private Transform _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>().transform;
        Spawn();
    }

    private void Update()
    {
        Movement();
    }
    private void Movement()
    {
        if (_player != null)
        {
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        }  
    }

    private void Spawn()
    {
        Vector3 direction = (_player.transform.position - transform.position).normalized;
        direction.y = 0;
        transform.forward = direction;
    }
}
