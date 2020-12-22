using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private MotorObject motor;
    private List<Vector3> pathMovement = new List<Vector3>();
    private Transform target;
    private Action onCollisitionPlayer;

    public Action OnCollisitionPlayer
    {
        get => onCollisitionPlayer;
        set => onCollisitionPlayer = value;
    }

    private void Start()
    {
        motor = GetComponent<MotorObject>();
        RefreshPath();
        transform.LookAt(pathMovement[1]);
    }

    private void RefreshPath()
    {
        NavMeshPath path = new NavMeshPath();
        target = GameController.GetEnemyTarget;
        NavMesh.CalculatePath(transform.position, target.position, NavMesh.AllAreas, path);
        pathMovement = new List<Vector3>(path.corners);
        if (pathMovement.Count > 1) pathMovement.RemoveAt(0);
    }

    private void Update()
    {
        var startPoint = transform.position + Vector3.up;
        if (Physics.Raycast(startPoint, (target.position - startPoint).normalized,
            out var hit, Mathf.Infinity))
        {
            Debug.DrawLine(startPoint, hit.point);
            if (hit.rigidbody == null)
                RefreshPath();
            else if (hit.rigidbody.transform.position != target.position)
                RefreshPath();
            else
            {
                MoveToPoint(target.position);
                return;
            }
        }

        MoveToPoint(pathMovement[0]);
    }

    private void MoveToPoint(Vector3 point)
    {
        var vector3 = (point - transform.position);
        var distance = vector3.magnitude;
        motor.Movement(1);
        if (distance < 2f)
            pathMovement.RemoveAt(0);
        var direction = vector3.normalized;
        motor.Rotate(direction);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (pathMovement != null)
        {
            if (pathMovement.Count >= 2)
            {
                Gizmos.DrawLine(transform.position, pathMovement[0]);
                Gizmos.DrawLine(pathMovement[pathMovement.Count - 2], target.position);
                for (int i = 0; i < pathMovement.Count - 2; i++)
                {
                    Gizmos.DrawLine(pathMovement[i], pathMovement[i + 1]);
                }
            }
            else
            {
                Gizmos.DrawLine(transform.position, target.position);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!enabled) return;

            enabled = false;
            motor.ResetRigidbody();
            DOVirtual.DelayedCall(5, () => enabled = true);
            other.rigidbody.AddForce(other.impulse.normalized * -2.5f, ForceMode.VelocityChange);
            onCollisitionPlayer?.Invoke();
        }
    }
}