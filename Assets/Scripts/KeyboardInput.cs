using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    private MotorObject motor;
    private GunsManager gunsManager;

    private void Start()
    {
        motor = GetComponent<MotorObject>();
        gunsManager = GetComponent<GunsManager>();
    }

    private bool GetAxis(string name, out float value)
    {
        value = Input.GetAxis(name);
        return Mathf.Abs(value) > 0;
    }

    private void Update()
    {
        if (GetAxis("Vertical", out var movement))
            motor.Movement(movement);
        
        if (GetAxis("Horizontal", out var rotation))
            motor.Rotate(rotation * (1 / Time.deltaTime));

        if (Input.GetKeyDown(KeyCode.X))
            gunsManager.Shot();
        
        if (Input.GetKeyDown(KeyCode.W))
            gunsManager.ChangeGun(1);
        else if (Input.GetKeyDown(KeyCode.Q))
            gunsManager.ChangeGun(-1);
    }
}
