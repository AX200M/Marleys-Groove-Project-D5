using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestKill : MonoBehaviour
{
    public KeyCode destroyKey = KeyCode.Space;
    public float destroyDistance = 10f;

    public List<GameObject> enemies = new List<GameObject>();
    public Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(destroyKey))
        {
            GameObject closestEnemy = FindClosestEnemy();

            if (closestEnemy != null && Vector3.Distance(player.position, closestEnemy.transform.position) <= destroyDistance)
            {
                Destroy(closestEnemy);
                enemies.Remove(closestEnemy);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemies.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemies.Remove(other.gameObject);
        }
    }

    GameObject FindClosestEnemy()
    {
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(player.position, enemy.transform.position);

            if (distance < closestDistance)
            {
                closestEnemy = enemy;
                closestDistance = distance;
            }
        }

        return closestEnemy;
    }
}
