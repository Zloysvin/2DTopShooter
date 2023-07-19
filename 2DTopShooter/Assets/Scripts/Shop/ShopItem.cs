using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    public IWeapon WeaponInfo;
    public GameObject Weapon;

    public TMP_Text Name;
    public TMP_Text Damage;
    public TMP_Text FireRate;
    public TMP_Text Reload;
    public TMP_Text ClipSize;

    public void ShowWeaponInfo()
    {
        Name.text = WeaponInfo.Name;
        Damage.text = $"Damage: {Math.Round(WeaponInfo.Damage, 2)}";
        FireRate.text = $"Fire rate: {Math.Round(WeaponInfo.ShootTime, 2)}";
        Reload.text = $"Reload: {Math.Round(WeaponInfo.ReloadTime, 2)}";
        ClipSize.text = $"Clip Size: {WeaponInfo.AmmoClipSize}";
    }
}
