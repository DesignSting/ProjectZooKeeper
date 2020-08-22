using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Area", menuName = "Game Options/Area Materials")]
public class AreaMaterials : ScriptableObject
{
    [Header("Player Outfits")]
    public List<Material> casualOutfit;
    public List<Material> janitorOutfit;
    public List<Material> zooKeeperOutfit;

    [Header("Building Materials")]
    public List<Material> toolshedMaterials;
    public List<Material> bathroomMaterials;
    public List<Material> smlExhibitMaterials;
    public List<Material> medExhibitMaterials;
    public List<Material> lrgExhibitMaterials;

    public List<Material> ReturnPlayerMaterial(CurrentOutfit outfit)
    {
        List<Material> mat = null;
        switch (outfit)
        {
            case CurrentOutfit.Casual:
                mat = casualOutfit;
                break;
            case CurrentOutfit.Janitor:
                mat = janitorOutfit;
                break;
            case CurrentOutfit.ZooKeeper:
                mat = zooKeeperOutfit;
                break;
        }

        return mat;
    }

    public List<Material> ReturnBuildingMaterial(BuildingType type)
    {
        List<Material> mat = null;
        switch (type)
        {
            case BuildingType.ToolShed:
                mat = toolshedMaterials;
                break;
            case BuildingType.Bathroom:
                mat = bathroomMaterials;
                break;
            case BuildingType.SmallExhibition:
                mat = smlExhibitMaterials;
                break;
            case BuildingType.MediumExhibition:
                break;
            case BuildingType.LargeExhibition:
                break;
        }

        return mat;
    }
}
