using DG.Tweening;
using UnityEngine;

public class Undead : MonoBehaviour, IPoolable
{
    // Data
    [SerializeField]
    private UndeadData _data;

    //Material
    [SerializeField]
    private Material _mat;

    // Stats
    private int _hp;
    private float _speed;

    // IPoolable
    [field: SerializeField]
    public bool InUse { get; private set; }

    private Rigidbody _rb;

    private bool _isMoving = false;
    private bool _hasBeenInstanciated = false;

    // Update is called once per frame
    private void Update()
    {
        if (_isMoving)
        {
            _rb.velocity = transform.forward * _speed;
        }
    }

    /// <summary>
    /// Has the Undead take damage by a given amount
    /// </summary>
    /// <param name="amount">The amount of damage dealt</param>
    public void TakeDamage(int amount)
    {
        _hp -= amount;
        DamageAnim();

        if (_hp <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Use the Undead and send it to attack
    /// </summary>
    /// <param name="position"></param>
    public void Use(Vector3 position, Quaternion rotation)
    {
        if (!_hasBeenInstanciated)
        {
            Init();
        }

        _hp = _data.HP;

        transform.position = position;
        transform.rotation = rotation;
        _isMoving = true;
        InUse = true;
    }

    /// <summary>
    /// Unuse the Undead and have it on standby
    /// </summary>
    public void Unuse()
    {
        transform.position = ObjectPool.Instance.transform.position;
        _isMoving = false;
        InUse = false;
    }

    /// <summary>
    /// Returns the Poolable's GameObject
    /// </summary>
    /// <returns></returns>
    public GameObject GetGameObject()
    {
        return this.gameObject;
    }

    /// <summary>
    /// Initializes the Undead when it is used for the first time
    /// </summary>
    private void Init()
    {
        _rb = GetComponent<Rigidbody>();

        LoadData();

        _hasBeenInstanciated = true;
    }

    /// <summary>
    /// Loads the data of the UndeadData into the Undead
    /// </summary>
    /// <param name="data"></param>
    private void LoadData()
    {
        _hp = _data.HP;
        _speed = _data.MovementSpeed;
    }

    /// <summary>
    /// Has the Undead die
    /// </summary>
    private void Die()
    {
        Unuse();
    }

    /// <summary>
    /// Animates Damage taken
    /// </summary>
    private void DamageAnim()
    {
        DOTween.Sequence()
            .Append(
                transform.DOScale(0.9f, 0.1f)
                )
            .Append(
                 transform.DOScale(1f, 0.1f)
                );
    }
}
