using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public OutfitList CurrentOutfit;

    [Header("Stats")]
    public int janitorLevel;
    public int zooKeeperLevel;

    private CharacterAI thisCharacter;
    [SerializeField] private Building currentBuildingTarget;

    private MeshRenderer[] meshRenderers;
    private AreaMaterials currentAreaMaterials;

    public void AcceptMaterials(AreaMaterials areaMaterials)
    {
        currentAreaMaterials = areaMaterials;
        ChangeCurrentOutfit(OutfitList.Casual);
    }

    public void DestinationReached()
    {
        Debug.Log("Destination Win");
        if(currentBuildingTarget != null)
        {
            if (currentBuildingTarget is VisitorBuilding)
            {
                Debug.Log("Visitor");
                if (currentBuildingTarget.GetComponent<VisitorBuilding>().CheckIfCorrectOutfit(this))
                {
                    Debug.Log("Correct Outfit");
                    currentBuildingTarget.StartEmployeeSession(this);
                }
            }
            else if (currentBuildingTarget is ToolShed)
            {
                currentBuildingTarget.StartEmployeeSession(this);
            }
        }
    }

    public void CheckClick(RaycastHit hit)
    {
        if (hit.transform.tag == "Building")
        {
            Debug.Log("Building");
            currentBuildingTarget = hit.transform.GetComponentInParent<Building>();
            thisCharacter.MoveCharacter(currentBuildingTarget);
        }
        else
        {
            Debug.Log("Not Building");
            thisCharacter.MoveCharacter(hit.point);
            currentBuildingTarget = null;
        }
    }

    public void ChangeCurrentOutfit(OutfitList outfit)
    {
        List<Material> toChange = new List<Material>();
        switch (outfit)
        {
            case OutfitList.Casual:
                toChange = currentAreaMaterials.casualOutfit;
                break;
            case OutfitList.Janitor:
                toChange = currentAreaMaterials.janitorOutfit;
                break;
            case OutfitList.ZooKeeper:
                toChange = currentAreaMaterials.zooKeeperOutfit;
                break;
        }

        for(int i = 0; i < toChange.Count; i++)
        {
            meshRenderers[i].material = toChange[i];
        }

        CurrentOutfit = outfit;
    }

    public OutfitList ReturnCurrentOutfit()
    {
        return CurrentOutfit;
    }

    public Building ReturnCurrentTarget()
    {
        return currentBuildingTarget;
    }

    public float ReturnOutfitLevel(OutfitList type)
    {
        float toReturn = 0;
        switch (type)
        {
            case OutfitList.Janitor:
                toReturn = janitorLevel;
                break;
            case OutfitList.ZooKeeper:
                toReturn = zooKeeperLevel;
                break;
        }
        return toReturn;
    }

    private void Awake()
    {
        thisCharacter = GetComponent<CharacterAI>();
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
        janitorLevel = 1;
        zooKeeperLevel = 1;
    }


}


