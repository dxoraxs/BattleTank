using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "Create Player Settings", order = 0)]
public class PlayerSettings : CharacterSettings
{
    public GunSettings[] Guns;
}