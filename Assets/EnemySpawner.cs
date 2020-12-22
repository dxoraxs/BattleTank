using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int startCount;
    [SerializeField] private Transform[] pointSpawn;
    [SerializeField] private float radius;

    private void Start()
    {
        for (int i = 0; i < startCount; i++)
        {
            SpawnNewEnemy();
        }
    }

    private void SpawnNewEnemy()
    {
        var enemy = EnemyPool.GetRandomEnemy();
        GameController.AddNewEnemy(enemy.GetRigidbody, enemy);

        while (true)
        {
            if (RandomPoint(pointSpawn[Random.Range(0, pointSpawn.Length)].position, radius, out var point))
                if (CameraRayCasterPoint.RayCastPointInCamera(point))
                {
                    enemy.transform.position = point;
                    break;
                }
        }

        enemy.SubscribeEnemyDied(OnEnemyDied);
    }

    private void OnEnemyDied(Enemy enemy)
    {
        enemy.transform.localScale = Vector3.one;
        EnemyPool.ReturnEnemy(enemy);
        SpawnNewEnemy();
    }

    private bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }

        result = Vector3.zero;
        return false;
    }

    private void OnDrawGizmos()
    {
        if (pointSpawn == null) return;
        Gizmos.color = Color.blue;
        foreach (var point in pointSpawn)
        {
            Gizmos.DrawWireSphere(point.position, radius);
        }
    }
}