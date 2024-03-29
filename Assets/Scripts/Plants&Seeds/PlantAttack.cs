using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the Attacking of a plant
/// </summary>
public class PlantAttack : MonoBehaviour
{
    // Events
    public event Action Attack;

    // PlantAttackStats
    private int _attackDamage;
    private float _attackRate;
    private float _attackRange;

    // Private use
    private SphereCollider _rangeCollider;
    private List<Undead> targets;
    private Coroutine _coroutineAttackCycle;

    private bool _canAttack = false;
    private bool _isAttacking = false;

    // Attack Rate Comparator (inverses the attack speed)
    private float _initRate = 2;

    /// <summary>
    /// Initializes PlantAttack the first time it is used
    /// </summary>
    public void Init()
    {
        // Get the sphere collider in the child gameobject
        _rangeCollider = GetComponent<SphereCollider>();
        targets = new List<Undead>();
    }

    /// <summary>
    /// Loads the Attack data from PlantData
    /// </summary>
    /// <param name="data"></param>
    public void LoadData(PlantData data)
    {
        _attackDamage = data.AttackDamage;
        _attackRate = data.AttackRate;
        _attackRange = data.AttackRange;

        _rangeCollider.radius = _attackRange;
    }

    /// <summary>
    /// Sets if the plant can or not attack
    /// </summary>
    /// <param name="canAttack"></param>
    public void SetCanAttack(bool canAttack)
    {
        _canAttack = canAttack;

        if (targets.Count > 0)
        {
            StartAttacking();
        }

        if (!_canAttack)
        {
            StopAttacking();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Undead"))
        {
            targets.Add(other.gameObject.GetComponent<Undead>());

            if (_canAttack && !_isAttacking)
            {
                StartAttacking();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Undead"))
        {
            targets.Remove(other.gameObject.GetComponent<Undead>());

            if (targets.Count <= 0)
            {
                StopAttacking();
            }
        }
    }

    /// <summary>
    /// Starts the AttackCycle Coroutine and saves it
    /// </summary>
    private void StartAttacking()
    {
        _isAttacking = true;
        _coroutineAttackCycle = StartCoroutine(AttackCycle());
    }

    /// <summary>
    /// Stops the saved AttackCycle Coroutine
    /// </summary>
    private void StopAttacking()
    {
        _isAttacking = false;
        if (_coroutineAttackCycle != null)
        {
            StopCoroutine(_coroutineAttackCycle);

            _coroutineAttackCycle = null;
        }
    }

    /// <summary>
    /// Continuously attacks the target
    /// </summary>
    /// <returns></returns>
    private IEnumerator AttackCycle()
    {
        // Infinite loop
        while (true)
        {
            AttackFirstTarget();
            yield return new WaitForSeconds(_initRate / _attackRate);
        }
    }

    /// <summary>
    /// Attack the first target that entered the attack radius
    /// </summary>
    private void AttackFirstTarget()
    {
        targets[0].TakeDamage(_attackDamage);
        Attack?.Invoke();
    }
}