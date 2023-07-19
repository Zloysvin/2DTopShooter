using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWeaponGenerator : MonoBehaviour
{
    public GameObject[] Weapons;
    public PlayerController Player;

    void Awake()
    {
        Player = GetComponent<PlayerController>();

        for (int i = 0; i < 5; i++)
        {
            GameObject wepObj = Instantiate(Weapons[Random.Range(0, Weapons.Length)], transform, true);
            Player.Weapons.Add(wepObj);

            IWeapon wep = wepObj.GetComponent<IWeapon>();
            wep.Damage = Random.Range(wep.Damage * 0.8f, wep.Damage * 1.75f);
            wep.AmmoClipSize = Mathf.RoundToInt(Random.Range(wep.AmmoClipSize * 0.8f, wep.AmmoClipSize * 1.75f));
            wep.CurrentAmmoInClip = wep.AmmoClipSize;
            wep.IsAutomatic = Random.value > 0.5f;
            wep.SpreadMultiplier = Random.Range(wep.SpreadMultiplier * 0.8f, wep.SpreadMultiplier * 3.75f);
            wep.ReloadTime = Random.Range(wep.ReloadTime * 0.5f, wep.ReloadTime * 1.25f);
            wep.ShootTime = Random.Range(wep.ShootTime * 0.5f, wep.ShootTime * 1.25f);

            wep.OnShoot += Player.PlayerController_OnShoot;
            wep.OnReload += Player.PlayerController_OnReload;
        }

    }
}
