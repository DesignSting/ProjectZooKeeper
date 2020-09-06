using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OverviewCanvas : MonoBehaviour
{
    public ToolSwap toolSwap;
    public TMP_Text toNextLevelAmount;
    public TMP_Text toNextLevelTotal;
    public TMP_Text failsAmount;
    public TMP_Text failsTotal;



    public void DisplayToolSwap(List<OutfitList> outfitList)
    {
        toolSwap.DisplayToolSwap(outfitList);
    }
}
