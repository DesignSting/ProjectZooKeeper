using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VisitorBuilding : Building
{
    [Header("Visitor Building")]
    public CurrentOutfit currentOutfitNeeded;

    public List<Transform> viewingAccessPoints = new List<Transform>();
    public List<CurrentOutfit> outfitsNeeded = new List<CurrentOutfit>();

    private Vector3 positionOfCountdown;

    public virtual void StartVisitorSession(Visitor v)
    {

    }

    public bool CheckIfCorrectOutfit(Character c)
    {
        if (currentOutfitNeeded == c.CurrentOutfit)
            return true;

        return false;
    }

    public void StartNeededCountdown()
    {

    }

    public override void StartEmployeeSession(Character c)
    {
        
    }

    private void Start()
    {
        float maxY = GetComponentInChildren<MeshRenderer>().bounds.max.y + 1;
        positionOfCountdown = new Vector3(transform.position.x, transform.position.y + maxY, transform.position.z);
    }
}
