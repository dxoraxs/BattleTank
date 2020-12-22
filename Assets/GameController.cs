using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    [SerializeField] private Player target;
    [SerializeField] private PlayerSettings playerSettings;
    private Dictionary<Rigidbody, Enemy> enemyList = new Dictionary<Rigidbody, Enemy>();

    public static void EnemyTakeDamage(Rigidbody rigidbody, int damage)
    {
        if (rigidbody != null && instance.enemyList.TryGetValue(rigidbody, out var character))
            character.TakeDamage(damage);
    }

    public static void AddNewEnemy(Rigidbody rigidbody, Enemy character)
    {
        if (!instance.enemyList.TryGetValue(rigidbody, out var enemy))
            instance.enemyList.Add(rigidbody, character);
    }

    public static Transform GetEnemyTarget => instance.target.transform;
    public static void PlayerTakeDamage(int damage) => instance.target.TakeDamage(damage);

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    private void Start()
    {
        target.InitializableCharacter(playerSettings);
    }
}