﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CommoditiesService : MonoBehaviour
{
    public static CommoditiesService instance;
    public Commodity commodityPrefab;
    public CommoditySO plusValue;
    public CommoditySO workforce;
    public List<Recipe> recipes = new List<Recipe>();

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
    }

    public CommoditySO GetCommodityByComponents(List<Commodity> _components)
    {
        List<CommoditySO> tempComponents;
        foreach (Recipe recipe in recipes)
        {
            tempComponents = (from _component in _components
                             select _component.type).ToList();
            if (recipe.components.Count != tempComponents.Count) continue; 
            foreach (CommoditySO component in recipe.components)
            {
                if (tempComponents.Contains(component))
                {
                    tempComponents.Remove(component);
                }
                else
                {
                    break;
                }
            }
            if (tempComponents.Count > 0)
            {
                continue;
            }
            else
            {
                return recipe.result;
            }
        }
        return null;
    }

    public Commodity SpawnCommodity(CommoditySO _type)
    {
        Commodity instatiatedCommodity = Instantiate(commodityPrefab, transform);
        instatiatedCommodity.InitializeProfile(_type);
        return instatiatedCommodity;
    }
}
