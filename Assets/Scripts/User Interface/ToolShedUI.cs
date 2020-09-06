using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolShedUI : MonoBehaviour
{
    private ToolButton[] toolButtons;
    private bool isSet;

    public void CloseToolShed()
    {
        gameObject.SetActive(false);
    }

    public void OpenToolShed(List<OutfitList> outfitList)
    {
        gameObject.SetActive(true);
        int i = 0;
        foreach (OutfitList outfit in outfitList)
        {
            toolButtons[0].AcceptOutfit(outfit);
            i++;
        }
    }

    public void SetToolShed(List<OutfitList> outfitList)
    {
        if (!isSet)
        {
            int i = 0;
            foreach (OutfitList outfit in outfitList)
            {
                toolButtons[0].AcceptOutfit(outfit);
                i++;
            }
            isSet = true;
        }
    }

    private void Awake()
    {
        toolButtons = GetComponentsInChildren<ToolButton>();
        gameObject.SetActive(false);
    }
}
