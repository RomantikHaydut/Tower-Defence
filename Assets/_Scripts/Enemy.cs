using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int damage = 5;

    [SerializeField] private float moveSpeed = 2f;

    private Transform player;
    private void Start()
    {
        LookThePlayer();
    }
    private void Update()
    {
        Movement();
    }
    private void Movement()
    {
        if (player != null)
        {
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        }
    }

    public void LookThePlayer()
    {
        player = FindObjectOfType<Player>().transform;
        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0;
        transform.forward = direction;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Tower tower))
        {
            tower.GetDamage(damage);
            Destroy(gameObject);

        }
    }
}
