using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

namespace Game { 
public class HealthBase : MonoBehaviour
{
    [Header("Life")]
    public float startLife = 10;
    public int damage = 2;
    public bool destroyOnKill = false;
    public float damageMultiply = 1f;
    public int timeToDestroy = 2;

    [Header("Animation")]
    public float shakeDuration = .1f;
    public int shakeForce = 1;

    public Action<HealthBase> onKill;
    public Action<HealthBase> onDamage;
    public List<UiFillUpdate> uiHealthUpdater;

    public RandomObjectRespawn objectRespawn;
    public TextMeshProUGUI dieText;
    public MenuButtons respawnButton;


    [SerializeField] private float _currentLife;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            Damage(damage);
            
        }
    }
        private void Start()
        {
          dieText.enabled = false;         
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

    public void Damage(float damage)
    {
        _currentLife -= damage * damageMultiply;
        if (_currentLife <= 0)
        {
            Kill();
                if (respawnButton != null) respawnButton.gameObject.SetActive(true);
            }
            UpdateUi();
            gameObject.transform.DOShakeScale(shakeDuration / 2, Vector3.up, shakeForce / 2);
            onDamage?.Invoke(this);
    }

    public void Kill()
    {
        if (destroyOnKill)
        {
            gameObject.transform.DOShakeRotation(2f, 30f, 10, 30f, true);
            objectRespawn.DestroyRespawn(timeToDestroy);
            dieText.enabled = true;
            Destroy(gameObject, timeToDestroy);
            onKill?.Invoke(this);
        }
    }

        private void UpdateUi()
        {
            if (uiHealthUpdater != null)
            {
                uiHealthUpdater.ForEach(i => i.UpdateValue(_currentLife / startLife));
            }
        }


 }

}
