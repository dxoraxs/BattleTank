using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunsManager : MonoBehaviour
{
    [SerializeField] private Transform parentGun;
    private List<Gun> guns = new List<Gun>();
    private int selectGunIndex;

    private Gun SelectGun => guns[selectGunIndex];
    
    public void SpawnGun(GunSettings[] gunsSettings)
    {
        foreach (var gun in gunsSettings)
        {
            var newGun = Instantiate(gun.Gun, parentGun);
            newGun.gameObject.SetActive(false);
            newGun.InitializedGun(gun);
            guns.Add(new Gun(newGun.GetComponent<GunVisual>(), newGun));
        }
        
        SelectGun.Show();
    }

    public void Shot()
    {
        SelectGun.Shot();
    }

    public void ChangeGun(int vectorChange)
    {
        SelectGun.Hide();
        selectGunIndex += vectorChange;
        
        if (selectGunIndex < 0) selectGunIndex = guns.Count - 1;
        else if (selectGunIndex >= guns.Count) selectGunIndex = 0;
        
        SelectGun.Show();
    }
}
