using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Material", menuName = "Player Options/Materials")]
public class CharacterMaterialManager : ScriptableObject
{
    public Material casualOutfit;
    public Material janitorOutfit;
    public Material zooKeeperOutfit;

    public Material ReturnSpecificMaterial(OutfitList outfit)
    {
        Material mat = null;
        switch (outfit)
        {
            case OutfitList.Casual:
                mat = casualOutfit;
                break;
            case OutfitList.Janitor:
                mat = janitorOutfit;
                break;
            case OutfitList.ZooKeeper:
                mat = zooKeeperOutfit;
                break;
        }

        return mat;
    }
}
