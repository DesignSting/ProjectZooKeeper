using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public List<Building> exhibitBuildingList = new List<Building>();
    public List<Building> bathroomList = new List<Building>();

    public List<Building> toolShedList = new List<Building>();

    private AreaMaterials currentAreaMaterials;

    public void AcceptNewBuilding(Building b)
    {
        if (b is ToolShed)
            toolShedList.Add(b);
        else if (b is ExhibitBuilding)
            exhibitBuildingList.Add(b);
        else if (b is BathroomBuilding)
            bathroomList.Add(b);
    }

    public void PaintBuildings(AreaMaterials areaMaterials)
    {
        currentAreaMaterials = areaMaterials;
        PaintBuildings(exhibitBuildingList);
        PaintBuildings(bathroomList);
        PaintBuildings(toolShedList);
        
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
