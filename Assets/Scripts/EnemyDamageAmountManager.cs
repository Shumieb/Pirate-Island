using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageAmountManager : MonoBehaviour
{

    [SerializeField] float baseDamageAmount = 2;

    private float damageAmount;

    private static EnemyDamageAmountManager _instance;

    public static EnemyDamageAmountManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        damageAmount = baseDamageAmount;
    }

    public float GetDamageAmount() { return damageAmount; }

    public void SetDamageAmount(float value)
    {
        damageAmount = value;
    }

}
