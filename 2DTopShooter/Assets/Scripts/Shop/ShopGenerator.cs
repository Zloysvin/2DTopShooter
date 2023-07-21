using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ShopGenerator : MonoBehaviour
{
    public GameObject[] Weapons;
    public PlayerController Player;

    public ShopItem[] items;

    public ShopItem SelectedItem;

    public GameObject Shop;

    void Awake()
    {
        GenerateShop();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Shop.SetActive(false);
        }
    }

    private void GenerateShop()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject wepObj = Instantiate(Weapons[Random.Range(0, Weapons.Length)], items[i].gameObject.transform);
            IWeapon wep = wepObj.GetComponent<IWeapon>();
            wep.Damage = Random.Range(wep.Damage * 0.8f, wep.Damage * 1.75f);
            wep.AmmoClipSize = Mathf.RoundToInt(Random.Range(wep.AmmoClipSize * 0.8f, wep.AmmoClipSize * 1.75f));
            wep.CurrentAmmoInClip = wep.AmmoClipSize;
            //wep.IsAutomatic = Random.value > 0.5f;
            wep.SpreadMultiplier = Random.Range(wep.SpreadMultiplier * 0.8f, wep.SpreadMultiplier * 1.75f);
            wep.ReloadTime = Random.Range(wep.ReloadTime * 0.5f, wep.ReloadTime * 1.25f);
            wep.ShootTime = Random.Range(wep.ShootTime * 0.5f, wep.ShootTime * 1.25f);

            items[i].WeaponInfo = wep;
            items[i].Weapon = wepObj;

            items[i].GetComponent<Image>().sprite = wep.Weapon;
        }
    }

    public void BuyWeapon()
    {
        if(Player.Points >= SelectedItem.Price)
        {
            GameObject weapon = SelectedItem.Weapon;
            GameObject newWeapon = Instantiate(weapon, Player.transform);
            Destroy(weapon);
            Player.Weapons.Add(newWeapon);
            Player.Points -= SelectedItem.Price;
            Player.UpdateScore();

            newWeapon.GetComponent<IWeapon>().OnShoot += Player.PlayerController_OnShoot;
            newWeapon.GetComponent<IWeapon>().OnReload += Player.PlayerController_OnReload;

            SelectedItem.GetComponent<Image>().sprite = null;
        }
    }
}
