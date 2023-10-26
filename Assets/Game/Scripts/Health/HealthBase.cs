using System;
using UnityEngine;

namespace Game { 
public class HealthBase : MonoBehaviour
{
    [Header("Life")]
    public float startLife = 10;
    public int damage = 2;
    public bool destroyOnKill = false;
    public float damageMultiply = 1f;
    public float timeToDestroy = 1.5f;
    public Action<HealthBase> onKill;
    public Action<HealthBase> onDamage;

    public RandomObjectRespawn objectRespawn;

    [SerializeField] private float _currentLife;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            Damage(damage);
        }
    }

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        ResetLife();
    }
    public void ResetLife()
    {
        _currentLife = startLife;
    }

    [NaughtyAttributes.Button]
    public void Damage()
    {
        Damage(5);
    }
    public void Damage(float damage)
    {
        _currentLife -= damage * damageMultiply;
        if (_currentLife <= 0)
        {
            Kill();
        }
        onDamage?.Invoke(this);
    }

    public void Kill()
    {
        if (destroyOnKill)
        {
            Destroy(gameObject, timeToDestroy);
            onKill?.Invoke(this);
            objectRespawn.DestroyRespawn(timeToDestroy);
        }
    }
}

}