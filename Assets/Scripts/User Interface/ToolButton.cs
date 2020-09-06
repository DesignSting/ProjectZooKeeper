using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToolButton : MonoBehaviour
{

    public TMP_Text displayedText;
    private int currentOutfit;
    private Button thisButton;

    public void AcceptOutfit(OutfitList outfit)
    {
        switch (outfit)
        {
            case OutfitList.Casual:
                currentOutfit = 0;
                displayedText.text = "Casual";
                break;
            case OutfitList.Janitor:
                currentOutfit = 1;
                displayedText.text = "Janitor";
                break;
            case OutfitList.ZooKeeper:
                currentOutfit = 2;
                displayedText.text = "Zoo Keeper";
                break;
        }
        thisButton.onClick.AddListener(AttachOutfit);
    }


    private void AttachOutfit()
    {
        GetComponentInParent<ToolSwap>().ChangeClothes(currentOutfit);
    }

    private void Awake()
    {
        thisButton = GetComponent<Button>();
        displayedText = GetComponentInChildren<TMP_Text>();
    }
}
