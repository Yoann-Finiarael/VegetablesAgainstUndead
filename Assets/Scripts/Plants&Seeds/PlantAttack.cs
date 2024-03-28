using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAttack : MonoBehaviour
{
    // PlantAttackStats
    private int _attackDamage;
    private float _attackRate;
    private float _attackRange;

    private SphereCollider _rangeCollider;
    private List<GameObject> targets;
    private Coroutine _coroutineAttackCycle;

    private bool _isAttacking = false;

    /// <summary>
    /// Initializes PlantAttack the first time it is used
    /// </summary>
    public void Init()
    {
        // Get the sphere collider in the child gameobject
        _rangeCollider = GetComponent<SphereCollider>();
        targets = new List<GameObject>();
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Undead"))
        {
            targets.Add(other.gameObject);

            if (!_isAttacking)
            {
                StartAttacking();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Undead"))
        {
            targets.Remove(other.gameObject);

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
        StopCoroutine(_coroutineAttackCycle);
    }

    /// <summary>
    /// Continuously attacks the target
    /// </summary>
    /// <returns></returns>
    private IEnumerator AttackCycle()
    {
        //Infinite loop
        while (true)
        {
            AttackFirstTarget();
            yield return new WaitForSeconds(_attackRate);
        }
    }

    /// <summary>
    /// Attack the first target that entered the attack radius
    /// </summary>
    private void AttackFirstTarget()
    {
        Debug.Log("I attack " + targets[0]);
    }
    
}
