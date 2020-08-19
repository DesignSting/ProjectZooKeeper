using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    public List<Transform> staffAccessPoints = new List<Transform>();
    
    public Transform exitPoint;
    public CurrentOutfit currentOutfitNeeded;

    protected float timer;
    protected bool currentlyInside;
    protected Character currentCharacter;
    
    public List<Transform> ReturnAccessPoints()
    {
        return staffAccessPoints;
    }

    public virtual void StartSession(Character c)
    {

    }

    public bool CheckIfCorrectOutfit(Character c)
    {
        if (currentOutfitNeeded == c.CurrentOutfit)
            return true;

        return false;
    }

    private void Awake()
    {
        BuildingManager.Instance.AcceptNewBuilding(this);
    }
}
