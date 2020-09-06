using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VisitorBuilding : Building
{
    [Header("Visitor Building")]
    public OutfitList currentOutfitNeeded;

    public List<Transform> viewingAccessPoints = new List<Transform>();
    public BuildingDetails buildingDetails;
    public GameObject buildingActivated;

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

    public void StartOutfitCountdown(OutfitList outfitNeeded)
    {
        currentOutfitNeeded = outfitNeeded;
        buildingActivated.SetActive(true);
    }

    public override void StartEmployeeSession(Character c)
    {
        currentOutfitDetails = buildingDetails.ReturnOutfitDetails(c.CurrentOutfit);
        
        StartCoroutine(EmployeeSession(c));
    }

    private void Start()
    {
        float maxY = GetComponentInChildren<MeshRenderer>().bounds.max.y + 1;
        positionOfCountdown = new Vector3(transform.position.x, transform.position.y + maxY, transform.position.z);
    }

    private IEnumerator EmployeeSession(Character c)
    {
        countdownActive = true;
        GameManager.Instance.CharacterUnavailable();
        float i = c.ReturnOutfitLevel(currentOutfitNeeded);
        c.gameObject.SetActive(false);
        float timer = 0;
        while(timer < currentOutfitDetails.timeForOutfit)
        {
            timer += Time.deltaTime * i;
            yield return null;
        }
        countdownActive = false;
        c.gameObject.SetActive(true);
        buildingActivated.SetActive(false);
        GameManager.Instance.CharacterAvailable();
    }

    private IEnumerator Countdown()
    {
        float timer = 0;
        while(timer < currentOutfitDetails.countdownTime)
        {
            if (!countdownActive)
            {
                timer += Time.deltaTime;
                yield return null;
            }
        }
    }
}
