using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIService : MonoBehaviour
{
    public static UIService instance;
    [HideInInspector] public GraphicRaycaster graphicRaycatser;
    public InfoPanel infoPanel;
    [HideInInspector] public bool infoPanelDisplaying;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            throw new System.Exception($"Too many {this} instances");
        }
        graphicRaycatser = GetComponent<GraphicRaycaster>();
    }

    private void Start()
    {
        HideInfoPanel();
    }

    private void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) && !infoPanel.hovering)
        {
            HideInfoPanel();
        }
    }

    public void DisplayInfoPanel(Commodity _commodity)
    {
        infoPanel.gameObject.SetActive(true);
        infoPanel.Initialize(_commodity);
        infoPanelDisplaying = true;
    }

    public void HideInfoPanel()
    {
        infoPanel.gameObject.SetActive(false);
        infoPanelDisplaying = false;
    }
}
