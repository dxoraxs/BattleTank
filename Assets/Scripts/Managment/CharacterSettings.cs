using UnityEngine;

public abstract class CharacterSettings : ScriptableObject
{
    public int Health;
    [Range(0, 1)] public float armor;
    public int SpeedMovement;
    public float SpeedRotate;
}