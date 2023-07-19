using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour, IProjectile
{
    public float Damage;

    [SerializeField] private float _lifeTime;
    [SerializeField] private float _speed;
    [SerializeField] private bool _isPlayerBullet;

    [field:SerializeField] public GameObject SelfRef { get; set; }

    private Rigidbody2D _rigidbody;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Project(Vector2 direction, float damage)
    {
        _rigidbody.AddForce(direction * _speed);
        Damage = damage;

        Destroy(this.gameObject, _lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamagable damageModel;
        if (collision.gameObject.TryGetComponent(out damageModel))
        {
            damageModel.ReceiveDamage(Damage, _isPlayerBullet);
        }
        Destroy(gameObject);
    }
}
