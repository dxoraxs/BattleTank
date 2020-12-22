using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorObject : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    private float speedMovement;
    private float speedRotate;

    public float SpeedRotate
    {
        private get => speedRotate;
        set => speedRotate = value;
    }

    public float SpeedMovement
    {
        private get => speedMovement;
        set => speedMovement = value;
    }

    public Rigidbody GetRigidbody => rigidbody;

    public void Movement(float force)
    {
        rigidbody.velocity = transform.forward * (force * SpeedMovement);
    }

    public void Rotate(float force)
    {
        var speedRotate = Time.deltaTime * force * SpeedRotate;
        rigidbody.angularVelocity = Vector3.up * speedRotate;
    }

    public void Rotate(Vector3 direction)
    {
        var angle = SignedAngleBetween(transform.forward, direction, transform.up);
        Rotate(angle);
    }

    public void ResetRigidbody()
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
    }
    
    private float SignedAngleBetween(Vector3 a, Vector3 b, Vector3 n){
        float angle = Vector3.Angle(a,b);
        float sign = Mathf.Sign(Vector3.Dot(n,Vector3.Cross(a,b)));
        float signed_angle = angle * sign;
        
        return signed_angle;
    }
}