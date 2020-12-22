using UnityEngine;

[CreateAssetMenu(fileName = "EnemySettings", menuName = "Create Enemy Settings", order = 0)]
public class EnemySettings : CharacterSettings
{
    public Enemy Character;
    public int Damage;
}