using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Building", menuName = "Game Options/Building Details")]
public class BuildingDetails : ScriptableObject
{
    public BuildingType BuildingType;
    public List<OutfitsNeededDetails> outfitsNeeded = new List<OutfitsNeededDetails>();

    public OutfitsNeededDetails ReturnOutfitDetails(OutfitList outfit)
    {
        OutfitsNeededDetails toReturn = null;

        foreach(OutfitsNeededDetails needed in outfitsNeeded)
        {
            if(needed.outfitNeeded == outfit)
            {
                toReturn = needed;
                break;
            }
        }
        return toReturn;
    }
}
