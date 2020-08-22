using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomBuilding : VisitorBuilding
{
    [Header("Bathroom Variables")]
    public int maxCapacity;
    public int curCapacity;

    public int maxTimesBeforeDirty;
    public int curTimesUsed;

    
}
