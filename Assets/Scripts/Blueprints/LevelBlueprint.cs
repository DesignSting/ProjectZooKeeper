using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBlueprint : MonoBehaviour
{
    public GameObject ground;

    [Header("Buildings Per Level")]
    public List<Building> level01Buildings = new List<Building>();
    public List<Building> level02Buildings = new List<Building>();
    public List<Building> level03Buildings = new List<Building>();
    public List<Building> level04Buildings = new List<Building>();
    public List<Building> level05Buildings = new List<Building>();
    public List<Building> level06Buildings = new List<Building>();
    public List<Building> level07Buildings = new List<Building>();
    public List<Building> level08Buildings = new List<Building>();
    public List<Building> level09Buildings = new List<Building>();
    public List<Building> level10Buildings = new List<Building>();

    public List<GameObject> levelOutlines = new List<GameObject>();

    public List<Building> ReturnLevelBuildings(int i)
    {
        List<Building> tempList = new List<Building>();
        switch(i)
        {
            case 1:
                tempList = level01Buildings;
                break;
            case 2:
                tempList = level02Buildings;
                break;
            case 3:
                tempList = level03Buildings;
                break;
            case 4:
                tempList = level04Buildings;
                break;
            case 5:
                tempList = level05Buildings;
                break;
            case 6:
                tempList = level06Buildings;
                break;
            case 7:
                tempList = level07Buildings;
                break;
            case 8:
                tempList = level08Buildings;
                break;
            case 9:
                tempList = level09Buildings;
                break;
            case 10:
                tempList = level10Buildings;
                break;
        }
        return tempList;
    }


    private void Awake()
    {
        foreach(GameObject go in levelOutlines)
        {
            go.SetActive(false);
        }
    }
}
