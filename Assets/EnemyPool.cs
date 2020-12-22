using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    private static EnemyPool instance;
    [SerializeField] private EnemySettings[] enemys;
    [SerializeField] private int count;
    private List<Enemy> enemysList = new List<Enemy>();
    
    private void Awake()
    {
        instance = this;
        for (int i = 0; i < enemys.Length; i++)
        {
            for (int j = 0; j < count; j++)
            {
                var enemy = SpawnEnemy(i);
                enemy.gameObject.SetActive(false);
                enemy.InitializableCharacter(enemys[i]);
            }
        }
    }

    private Enemy SpawnEnemy(int i)
    {
        var enemy = Instantiate(enemys[i].Character, transform);
        enemysList.Add(enemy);
        return enemy;
    }

    public static Enemy GetRandomEnemy()
    {
        if (instance.enemysList.Count == 0) instance.SpawnEnemy(Random.Range(0, instance.enemys.Length));
        var randomIndex = Random.Range(0, instance.enemysList.Count);
        var selectEnemy = instance.enemysList[randomIndex];
        selectEnemy.gameObject.SetActive(true);
        instance.enemysList.Remove(selectEnemy);
        return selectEnemy;
    }

    public static void ReturnEnemy(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
        instance.enemysList.Add(enemy);
    }
}
