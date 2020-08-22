using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Building", menuName = "Game Options/Building Details")]
public class BuildingDetails : ScriptableObject
{
    public List<OutfitsNeededDetails> outfitsNeeded = new List<OutfitsNeededDetails>();
}
