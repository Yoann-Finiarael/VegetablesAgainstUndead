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

    //IPoolable
    public bool InUse { get; private set; }

    // PlantStats
    public string Name { get; private set; }

    public float GrowTime { get; private set; }

    public int SellValue { get; private set; }

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
        main.Money.GainMoney(SellValue);
        _plot.FreePlot();

        Unuse();
    }

    /// <summary>
    /// Uses the plant
    /// </summary>
    /// <param name="position"></param>
    public void Use(Vector3 position)
    {
        if (Name != _data.Name)
        {
            LoadData();
        }

        transform.position = position;
        InUse = true;

        StartCoroutine(StartGrowth());
    }

    /// <summary>
    /// Unuses the plant
    /// </summary>
    public void Unuse()
    {
        transform.position = ObjectPool.Instance.transform.position;

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
    /// Hydrates the prefab from the Scriptable's Data
    /// </summary>
    private void LoadData()
    {
        Name = _data.Name;
        GrowTime = _data.GrowTime;
        SellValue = _data.SellValue;

        InteractText = "Haverst " + Name;
    }

    /// <summary>
    /// Grows the plant after a set amount of time. The plant then becomes Interactable
    /// </summary>
    /// <returns></returns>
    private IEnumerator StartGrowth()
    {
        transform.localScale = Vector3.one * 0.4f;
        IsInteractable = false;

        yield return new WaitForSeconds(GrowTime);

        transform.localScale = Vector3.one;
        IsInteractable = true;
    }
}