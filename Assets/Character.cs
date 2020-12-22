using DG.Tweening;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private MotorObject motor;
    protected int health;
    private float armor;
    
    public Rigidbody GetRigidbody => motor.GetRigidbody;
    
    public virtual void InitializableCharacter(CharacterSettings settings)
    {
        health = settings.Health;
        armor = settings.armor;
        motor.SpeedMovement = settings.SpeedMovement;
        motor.SpeedRotate = settings.SpeedRotate;
    }

    public virtual void TakeDamage(int count)
    {
        var damage = (int)(count * armor);
        health -= damage;
        if (health <= 0)
            Death();
    }

    private void Death()
    {
        transform.DOScale(0, 0.5f).OnComplete(OnCompleteDieAnimation);
    }

    protected virtual void OnCompleteDieAnimation()
    {
        gameObject.SetActive(false);
    }
}
