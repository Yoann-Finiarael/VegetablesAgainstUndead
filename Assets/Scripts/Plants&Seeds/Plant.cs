using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Plant : MonoBehaviour, Interactable, IPoolable
{
    [field: Header("ScriptableObject")]

    [SerializeField]
    private PlantData _data;

    // Interactable
    public string InteractText { get; private set; }

    public bool IsInteractable { get; private set; }

    // IPoolable
    public bool InUse { get; private set; }

    // PlantStats
    private string _name;
    private float _growTime;
    private int _sellValue;

    private PlantAttack _attack;

    private LandPlot _plot;

    /// <summary>
    /// Sets the plant's current plot
    /// </summary>
    /// <param name="plot"></param>
    public void SetPlot(LandPlot plot)
    {
        _plot = plot;
    }

    /// <summary>
    /// The player harvests and sells the plant. Free the plant from its plot. Unuses the plant
    /// </summary>
    /// <param name="main"></param>
    public void OnInteract(PlayerMain main)
    {
        main.Money.GainMoney(_sellValue);
        _plot.FreePlot();

        Unuse();
    }

    /// <summary>
    /// Uses the plant, making it grow
    /// </summary>
    /// <param name="position">the position where the plant will go</param>
    public void Use(Vector3 position, Quaternion rotation)
    {
        if (_attack == null)
        {
            Init();
        }

        transform.position = position;
        transform.rotation = rotation;
        InUse = true;

        StartCoroutine(StartGrowth());
    }

    /// <summary>
    /// Unuses the plant and have it on standby
    /// </summary>
    public void Unuse()
    {
        transform.position = ObjectPool.Instance.transform.position;
        _attack.SetCanAttack(false);

        InUse = false;
    }

    /// <summary>
    /// Returns the plant's GameObject
    /// </summary>
    /// <returns></returns>
    public GameObject GetGameObject()
    {
        return this.gameObject;
    }

    /// <summary>
    /// Initializes the Plant when it is used for the first time
    /// </summary>
    private void Init()
    {
        _attack = transform.GetChild(0).GetComponent<PlantAttack>();
        _attack.Init();

        _attack.Attack += PlantAttackAnim;

        LoadData();
    }

    /// <summary>
    /// Hydrates the prefab from the Scriptable's Data
    /// </summary>
    private void LoadData()
    {
        _name = _data.Name;
        _growTime = _data.GrowTime;
        _sellValue = _data.SellValue;

        InteractText = "Haverst " + _name;

        _attack.LoadData(_data);
    }

    /// <summary>
    /// Grows the plant after a set amount of time. The plant then becomes Interactable
    /// </summary>
    /// <returns></returns>
    private IEnumerator StartGrowth()
    {
        transform.localScale = Vector3.one * 0.4f;
        IsInteractable = false;

        yield return new WaitForSeconds(_growTime);

        transform.localScale = Vector3.one;
        IsInteractable = true;

        _attack.SetCanAttack(true);
    }

    /// <summary>
    /// Animates the plant when it attacks
    /// </summary>
    private void PlantAttackAnim()
    {
        DOTween.Sequence()
            .Append(
                transform.DOScaleY(0.8f, 0.2f)

                )
            .Append(
                transform.DOScaleY(1f, 0.2f)
                );
    }
}