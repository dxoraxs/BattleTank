using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Create Gun", order = 0)]
public class GunSettings : ScriptableObject
{
    public GunShot Gun;
    public float Delay;
    public int Damage;
}