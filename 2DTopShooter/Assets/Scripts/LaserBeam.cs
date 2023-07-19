using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour, IProjectile
{
    public float Damage;

    [SerializeField] private bool _isPlayerBullet;

    [field:SerializeField] public GameObject SelfRef { get; set; }

    public float fadeSpeed = 1f; // Speed at which the line renderer fades

    private float currentAlpha = 1f;

    private LineRenderer _lr;
    void Awake()
    {
        _lr = GetComponent<LineRenderer>();
    }

    public void Project(Vector2 direction, float damage)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 20f);
        if (hit.collider != null)
        {
            _lr.SetPosition(0, transform.position);
            _lr.SetPosition(1, hit.point);

            IDamagable damageModel;
            if (hit.collider.TryGetComponent(out damageModel))
            {
                Damage = damage;
                damageModel.ReceiveDamage(Damage, _isPlayerBullet);
            }
        }
        else
        {
            _lr.SetPosition(0, transform.position);
            _lr.SetPosition(1, new Vector2(transform.position.x, transform.position.y) + direction*20f);
        }

        StartCoroutine(FadeOutAndDestroy());
    }

    private IEnumerator FadeOutAndDestroy()
    {
        while (currentAlpha > 0f)
        {
            // Reduce the alpha value of the line renderer
            currentAlpha -= fadeSpeed * Time.deltaTime;
            SetAlpha(currentAlpha);

            yield return null;
        }

        Destroy(gameObject);
    }

    private void SetAlpha(float alpha)
    {
        // Create a new color with the same RGB values and the specified alpha
        Color color = _lr.startColor;
        color.a = alpha;

        // Update the start and end color of the line renderer
        _lr.startColor = color;
        _lr.endColor = color;
    }
}
