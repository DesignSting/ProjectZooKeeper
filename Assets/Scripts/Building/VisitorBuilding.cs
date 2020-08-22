using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VisitorBuilding : Building
{
    [Header("Visitor Building")]
    public CurrentOutfit currentOutfitNeeded;

    public List<Transform> viewingAccessPoints = new List<Transform>();
    public BuildingDetails buildingDetails;

    private Vector3 positionOfCountdown;
    private bool countdownActive;
    private OutfitsNeededDetails currentOutfitDetails;

    public virtual void StartVisitorSession(Visitor v)
    {

    }

    public bool CheckIfCorrectOutfit(Character c)
    {
        if (currentOutfitNeeded == c.CurrentOutfit)
            return true;

        return false;
    }

    

    public override void StartEmployeeSession(Character c)
    {
        currentOutfitDetails = buildingDetails.outfitsNeeded.Find(x => x.outfitNeeded == c.CurrentOutfit);
        StartCoroutine(EmployeeSession(c));
    }

    private void Start()
    {
        float maxY = GetComponentInChildren<MeshRenderer>().bounds.max.y + 1;
        positionOfCountdown = new Vector3(transform.position.x, transform.position.y + maxY, transform.position.z);
    }

    private IEnumerator EmployeeSession(Character c)
    {
        float i = c.ReturnOutfitLevel(currentOutfitNeeded);
        c.gameObject.SetActive(false);
        float timer = 0;
        while(timer < currentOutfitDetails.timeForOutfit)
        {
            timer += Time.deltaTime * i;
            yield return null;
        }
        c.gameObject.SetActive(true);
    }

    private IEnumerator Countdown()
    {
        float timer = 0;
        while(timer < currentOutfitDetails.countdownTime)
        {
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
