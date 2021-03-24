﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UseValue
{
    None,
    AddValue,
    Spicy,
    Sour,
    Acidic,
    Sweet,
    Salty
}

[CreateAssetMenu(fileName = "CommoditySO", menuName = "DasKapital/CommoditySO")]
public class CommoditySO : ScriptableObject
{
    public string commodityName;
    public int exchangeValue;
    public UseValue useValue;
    public string useValueDescription;
    public bool isDurable;
    public int usesAmount;
    public List<CommoditySO> components;
    public Sprite icon;
    public float sizeModifier = 1;
    public Color color;
}
