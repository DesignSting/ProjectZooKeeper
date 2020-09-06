using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    [Header("Building Variables")]
    public BuildingType buildingType;

    [Space(20)]
    public List<Transform> staffAccessPoints = new List<Transform>();
    
    public Transform exitPoint;

    protected float timer;
    protected bool playerCurrentlyInside;
    protected Character currentCharacter;
    protected MeshRenderer[] meshRenderers;
    
    public void PaintBuilding(AreaMaterials areaMaterials)
    {
        switch (buildingType)
        {
            case BuildingType.ToolShed:
                PaintBuilding(areaMaterials.toolshedMaterials);
                break;
            case BuildingType.Bathroom:
                PaintBuilding(areaMaterials.bathroomMaterials);
                break;
            case BuildingType.SmallExhibition:
                PaintBuilding(areaMaterials.smlExhibitMaterials);
                break;
            case BuildingType.MediumExhibition:
                break;
            case BuildingType.LargeExhibition:
                break;
        }
    }

    private void PaintBuilding(List<Material> materials)
    {
        for(int i = 0; i < materials.Count; i++)
        {
            meshRenderers[i].material = materials[i];
        }
    }

    public List<Transform> ReturnAccessPoints()
    {
        return staffAccessPoints;
    }

    public virtual void StartEmployeeSession(Character c)
    {
        Debug.Log("Visitor Building");
    }

    private void Awake()
    {
        //BuildingManager.Instance.AcceptNewBuilding(this);
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
        gameObject.SetActive(false);
    }

}


