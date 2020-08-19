using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public List<Building> exhibitBuildingList = new List<Building>();

    public List<Building> toolShedList = new List<Building>();


    public void AcceptNewBuilding(Building b)
    {
        if (b is ToolShed)
            toolShedList.Add(b);
        else if (b is ExhibitBuilding)
            exhibitBuildingList.Add(b);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
