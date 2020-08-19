using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CurrentOutfit CurrentOutfit;

    private CharacterAI thisCharacter;
    [SerializeField] private Building currentBuildingTarget;

    public void DestinationReached()
    {
        if(currentBuildingTarget != null)
        {
            if(currentBuildingTarget.CheckIfCorrectOutfit(this))
            {
                currentBuildingTarget.StartSession(this);
            }
        }
    }

    private void CheckClick(RaycastHit hit)
    {
        if (hit.transform.tag == "Building")
        {
            Debug.Log("Building");
            currentBuildingTarget = hit.transform.GetComponent<Building>();
            thisCharacter.MoveCharacter(currentBuildingTarget);
        }
        else
        {
            Debug.Log("Not Building");
            thisCharacter.MoveCharacter(hit.point);
            currentBuildingTarget = null;
        }
    }

    public CurrentOutfit ReturnCurrentOutfit()
    {
        return CurrentOutfit;
    }

    public Building ReturnCurrentTarget()
    {
        return currentBuildingTarget;
    }

    // Start is called before the first frame update
    void Start()
    {
        thisCharacter = GetComponent<CharacterAI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit hit, 100);
            CheckClick(hit);
        }
    }
}

public enum CurrentOutfit
{
    Casual,
    Janitor,
    ZooKeeper
}
