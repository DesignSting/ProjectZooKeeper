using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Material", menuName = "Player Options/Materials")]
public class CharacterMaterialManager : ScriptableObject
{
    public Material casualOutfit;
    public Material janitorOutfit;
    public Material zooKeeperOutfit;

    public Material ReturnSpecificMaterial(CurrentOutfit outfit)
    {
        Material mat = null;
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
}
