using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    public IWeapon WeaponInfo;
    public GameObject Weapon;
    public ShopGenerator Shop;
    public bool Avaliable;
    public int Price = 10000;

    public TMP_Text Name;
    public TMP_Text Damage;
    public TMP_Text FireRate;
    public TMP_Text Reload;
    public TMP_Text ClipSize;
    public TMP_Text PriceText;

    public void ShowWeaponInfo()
    {
        if(Avaliable)
        {
            Name.text = WeaponInfo.Name;
            Damage.text = $"Damage: {Math.Round(WeaponInfo.Damage, 2)}";
            FireRate.text = $"Fire rate: {Math.Round(WeaponInfo.ShootTime, 2)}";
            Reload.text = $"Reload: {Math.Round(WeaponInfo.ReloadTime, 2)}";
            ClipSize.text = $"Clip Size: {WeaponInfo.AmmoClipSize}";
            PriceText.text = $"{Price} PTS";

            Shop.SelectedItem = this;
        }
    }
}
