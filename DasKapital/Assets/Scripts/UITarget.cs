using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITarget : MonoBehaviour
{
    public int stockID;
    public System.Action<Commodity> onCommodityPlaced;
    public System.Action<Commodity> onCommodityUnloaded;
    [HideInInspector] public RectTransform rect;
    [HideInInspector] public Commodity loadedCommodity;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    public bool OnCommodityPlaced(Commodity _commodity)
    {
        if (loadedCommodity != null) return false;

        if (_commodity.target != null) _commodity.target.UnloadCommodity();
        _commodity.lastTarget = _commodity.target;
        _commodity.target = this;
        loadedCommodity = _commodity;
        onCommodityPlaced?.Invoke(loadedCommodity);
        return true;
    }

    public void UnloadCommodity()
    {
        onCommodityUnloaded?.Invoke(loadedCommodity);
        loadedCommodity = null;
    }
}
