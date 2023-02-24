using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static float range = 5.0f;

    [SerializeField] private Transform target;

    [SerializeField] private float rotateSpeed = 1f;

    private void Update()
    {
        if (IsThereAnyEnemy(out GameObject[] enemies))
        {
            FindNearestTargetInRange(enemies);
            Rotate();
        }
    }

    private void Rotate()
    {
        if (target != null)
        {
            Vector3 targetDirection = target.position - transform.position;
            targetDirection = new Vector3(targetDirection.x, 0, target.position.z).normalized;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDirection, transform.up), Time.deltaTime * rotateSpeed);
        }

    }
    private bool IsThereAnyEnemy(out GameObject[] enemies)
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length > 0)
        {
            return true;
        }

        return false;
    }


    private void FindNearestTargetInRange(GameObject[] enemies)
    {
        float maxDistance = range;


        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, new Vector3(transform.position.x, enemy.transform.position.y, transform.position.z));
            
            if (distance < maxDistance)
            {
                maxDistance = distance;
                target = enemy.transform;
            }

        }
    }
}
