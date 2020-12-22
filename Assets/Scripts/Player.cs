using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private GunsManager gunsManager;
    private int maxHealth;

    public override void InitializableCharacter(CharacterSettings settings)
    {
        base.InitializableCharacter(settings);
        var playerSettings = settings as PlayerSettings;
        maxHealth = settings.Health;
        gunsManager.SpawnGun(playerSettings.Guns);
        EventManager.OnUpdatePlayerHealth?.Invoke(1, health);
    }

    public override void TakeDamage(int count)
    {
        base.TakeDamage(count);
        EventManager.OnUpdatePlayerHealth?.Invoke((float)health/maxHealth, health);
    }
}