using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class OutfitsNeededDetails
{
    public CurrentOutfit outfitNeeded;
    [Range(1, 5)]
    public float timeForOutfit;

    [Space]
    [Range(5, 10)]
    public float countdownTime;
}
