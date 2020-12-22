using System;
using DG.Tweening;
using UnityEngine;

public class Enemy : Character
{
    private int damage;
    private Action<Enemy> onEnemyDied;

    public void SubscribeEnemyDied(Action<Enemy> action) => onEnemyDied += action;
    
    public override void InitializableCharacter(CharacterSettings settings)
    {
        base.InitializableCharacter(settings);
        var enemySettings = settings as EnemySettings;
        damage = enemySettings.Damage;
        GetComponent<EnemyMovement>().OnCollisitionPlayer += DamagePlayer;
    }

    private void DamagePlayer() => GameController.PlayerTakeDamage(damage);

    protected override void OnCompleteDieAnimation()
    {
        base.OnCompleteDieAnimation();
        onEnemyDied?.Invoke(this);
        onEnemyDied = null;
    }
}