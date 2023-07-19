using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public interface IWeapon
{
    string Name { get; set; }
    Transform GunPoint { get; set; }
    GameObject ProjectileObj { get; set; }
    IProjectile Projectile { get; set; }
    public event EventHandler<ShootingEventArgs> OnShoot;
    public event EventHandler<EventArgs> OnReload; 

    public float Damage { get; set; }
    public bool IsAutomatic { get; set; }
    public int AmmoClipSize { get; set; }
    public int CurrentAmmoInClip { get; set; }
    public int CurrentAmmo { get; set; }
    public int MaxAmmo { get; set; }
    public Sprite Ammo { get; set; }
    public Sprite Weapon { get; set; }
    public float ShootTime { get; set; }
    public float ReloadTime { get; set; }
    public float SpreadMultiplier { get; set; }

    public bool Shooting { get; set; }
    public bool Reloading { get; set; }

    public void Shoot();

    public void Reload();

    public IEnumerator ShootDelay();

    public IEnumerator ReloadDelay();
}
