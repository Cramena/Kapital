﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineNode : ScenarioNode
{
    public string lockey;

    public override void OnNodeEntered()
    {
        ScenarioService.instance.DisplayLine(lockey);
    }
}
