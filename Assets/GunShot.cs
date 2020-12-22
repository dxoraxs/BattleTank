using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GunShot : MonoBehaviour
{
    [SerializeField] private Transform spawnBulletPoint;
    private float delay;
    private float maxTimeDelay = 2;
    private int damage;

    public void InitializedGun(GunSettings settings)
    {
        maxTimeDelay = settings.Delay;
        delay = 0;
        Debug.Log($"SetDelay = {delay}");
        damage = settings.Damage;
    }

    private bool IsGunReload => delay > 0;

    private void Update()
    {
        if (IsGunReload)
        {
            delay -= Time.deltaTime;
            EventManager.OnUpdatePlayerReload?.Invoke(delay / maxTimeDelay);
        }
    }

    public void Shot()
    {
        if (!IsGunReload)
        {
            delay = maxTimeDelay;
            Debug.Log($"Shot! delay = {delay}");

            if (Physics.Raycast(spawnBulletPoint.position, spawnBulletPoint.up, out var hit, Mathf.Infinity))
            {
                ShotLineRenderer.OnShot(spawnBulletPoint.position, hit.point);
                GameController.EnemyTakeDamage(hit.rigidbody, damage);
            }
        }
    }
}