using System.Collections;
using UnityEngine;

public class Plant : MonoBehaviour, Interactable
{
    [field: Header("Interactable")]
    [field: SerializeField]
    public string InteractText { get; private set; }

    [field: SerializeField]
    public bool IsInteractable { get; private set; }

    [field: Header("PlantStats")]
    [field: SerializeField]
    public string Name { get; private set; }

    [field: SerializeField]
    public float GrowTime { get; private set; }

    [field: SerializeField]
    public int SellValue { get; private set; }


    private LandPlot _plot;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(StartGrowth());
    }

    public IEnumerator StartGrowth()
    {
        transform.localScale = Vector3.one * 0.4f;
        IsInteractable = false;

        yield return new WaitForSeconds(GrowTime);

        transform.localScale = Vector3.one;
        IsInteractable = true;
    }

    public void SetPlot(LandPlot plot)
    {
        _plot = plot;
    }

    public void OnInteract(PlayerMain main)
    {
        main.Money.GainMoney(SellValue);
        _plot.FreePlot();

        Destroy(gameObject);
    }
}