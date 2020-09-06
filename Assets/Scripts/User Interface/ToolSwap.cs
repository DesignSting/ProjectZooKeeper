using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSwap : MonoBehaviour
{
    public ToolShedUI oneOutfit;
    public ToolShedUI twoOutfits;
    public ToolShedUI threeOutfits;
    public ToolShedUI fourOutfits;

    private int currentlyUnlocked;

    public void ChangeClothes(int i)
    {
        GameManager.Instance.ChangeCharacterClothes(i);
        HideToolSwap();
        GameManager.Instance.MenuClosed();
    }

    public void DisplayToolSwap(List<OutfitList> outfitList)
    {
        gameObject.SetActive(true);
        currentlyUnlocked = outfitList.Count;
        switch(currentlyUnlocked)
        {
            case 1:
                oneOutfit.OpenToolShed(outfitList);
                break;
            case 2:
                twoOutfits.OpenToolShed(outfitList);
                break;
            case 3:
                threeOutfits.OpenToolShed(outfitList);
                break;
            case 4:
                fourOutfits.OpenToolShed(outfitList);
                break;
        }
    }

    public void HideToolSwap()
    {
        switch (currentlyUnlocked)
        {
            case 1:
                oneOutfit.CloseToolShed();
                break;
            case 2:
                twoOutfits.CloseToolShed();
                break;
            case 3:
                threeOutfits.CloseToolShed();
                break;
            case 4:
                fourOutfits.CloseToolShed();
                break;
        }
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        gameObject.SetActive(false);
    }
}
