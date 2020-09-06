using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public List<Building> bathroomList = new List<Building>();
    public List<Building> exhibitBuildingList = new List<Building>();

    public List<Building> toolShedList = new List<Building>();

    public List<Building> unactivatedList = new List<Building>();

    private AreaMaterials currentAreaMaterials;
    private LevelBlueprint currentLevelBlueprint;

    [Space]
    public List<LevelBlueprint> levelBlueprints = new List<LevelBlueprint>();

    [Space]
    public List<BuildingDetails> buildingDetails = new List<BuildingDetails>();

    public void AcceptNewBlueprint()
    {
        int rand = Random.Range(0, levelBlueprints.Count);
        currentLevelBlueprint = levelBlueprints[rand];
        currentLevelBlueprint.gameObject.SetActive(true);
    }

    public void AcceptNewLevel(int level)
    {
        List<Building> buildings = currentLevelBlueprint.ReturnLevelBuildings(level + 1);
        foreach(Building b in buildings)
        {
            unactivatedList.Add(b);
        }
    }

    public void ActivateBuilding(OutfitList outfit)
    {
        List<int> canUse = new List<int>(buildingDetails.Count);
        int buildingIndex = 0;
        foreach(BuildingDetails details in buildingDetails)
        {
            bool hasGot = false;
            foreach(OutfitsNeededDetails outfitsNeeded in details.outfitsNeeded)
            {
                if(outfit == outfitsNeeded.outfitNeeded)
                {
                    hasGot = true;
                    break;
                }
            }
            if(hasGot)
            {
                switch (details.BuildingType)
                {
                    case BuildingType.Bathroom:
                        if (bathroomList.Count == 0)
                            hasGot = false;
                        else
                            buildingIndex = 0;
                        break;
                    case BuildingType.SmallExhibition:
                        if (exhibitBuildingList.Count == 0)
                            hasGot = false;
                        else
                            buildingIndex = 1;
                        break;
                    case BuildingType.MediumExhibition:
                        if (exhibitBuildingList.Count == 0)
                            hasGot = false;
                        else
                            buildingIndex = 1;
                        break;
                    case BuildingType.LargeExhibition:
                        if (exhibitBuildingList.Count == 0)
                            hasGot = false;
                        else
                            buildingIndex = 1;
                        break;
                }
            }
            if(hasGot)
            {
                canUse.Add(buildingIndex);
            }
        }
        int rand = Random.Range(0, canUse.Count);
        VisitorBuilding selectedBuilding = null;
        int buildRand = 0;
        switch(rand)
        {
            case 0:
                buildRand = Random.Range(0, bathroomList.Count);
                selectedBuilding = bathroomList[buildRand] as VisitorBuilding;
                break;
            case 1:
                buildRand = Random.Range(0, exhibitBuildingList.Count);
                selectedBuilding = exhibitBuildingList[buildRand] as VisitorBuilding;
                break;
        }
        selectedBuilding.StartOutfitCountdown(outfit);
    }

    public void NextLevel()
    {
        foreach(Building b in unactivatedList)
        {
            if (b is ToolShed)
                toolShedList.Add(b);
            else if (b is ExhibitBuilding)
                exhibitBuildingList.Add(b);
            else if (b is BathroomBuilding)
                bathroomList.Add(b);
            b.gameObject.SetActive(true);
        }
    }

    public void AcceptAreaMaterials(AreaMaterials materials)
    {
        currentAreaMaterials = materials;
    }


    private void PaintBuildings(List<Building> buildings)
    {
        foreach(Building b in buildings)
        {
            b.PaintBuilding(currentAreaMaterials);
        }
    }

    public static BuildingManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
