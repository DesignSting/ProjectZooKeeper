using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolShed : Building
{
    public override void StartEmployeeSession(Character c)
    {
        DisplayToolSwap();
    }

    private void DisplayToolSwap()
    {
        UIManager.Instance.DisplayToolSwap();
    }
}
