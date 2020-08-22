using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CurrentOutfit CurrentOutfit;

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
        ChangeCurrentOutfit(CurrentOutfit.Casual);
    }

    public void DestinationReached()
    {
        if(currentBuildingTarget != null)
        {
            if (currentBuildingTarget is VisitorBuilding)
            {
                if (currentBuildingTarget.GetComponent<VisitorBuilding>().CheckIfCorrectOutfit(this))
                {
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

    public void ChangeCurrentOutfit(CurrentOutfit outfit)
    {
        List<Material> toChange = new List<Material>();
        switch (outfit)
        {
            case CurrentOutfit.Casual:
                toChange = currentAreaMaterials.casualOutfit;
                break;
            case CurrentOutfit.Janitor:
                toChange = currentAreaMaterials.janitorOutfit;
                break;
            case CurrentOutfit.ZooKeeper:
                toChange = currentAreaMaterials.zooKeeperOutfit;
                break;
        }

        for(int i = 0; i < toChange.Count; i++)
        {
            meshRenderers[i].material = toChange[i];
        }
    }

    public void DoActionRequired()
    {
        
    }

    public CurrentOutfit ReturnCurrentOutfit()
    {
        return CurrentOutfit;
    }

    public Building ReturnCurrentTarget()
    {
        return currentBuildingTarget;
    }

    private void Awake()
    {
        thisCharacter = GetComponent<CharacterAI>();
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum CurrentOutfit
{
    None,
    Casual,
    Janitor,
    ZooKeeper
}
