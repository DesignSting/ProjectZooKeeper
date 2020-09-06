using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueprintManager : MonoBehaviour
{
    public List<LevelBlueprint> levelBlueprints = new List<LevelBlueprint>();

    public LevelBlueprint currentLevelBlueprint;

    [Header("Building Prefabs")]
    public GameObject toolShed;
    public GameObject bathroom;
    public List<GameObject> smallExhibitionBuildings = new List<GameObject>();
    public List<GameObject> medExhibitionBuildings = new List<GameObject>();
    public List<GameObject> lrgExhibitionBuildings = new List<GameObject>();

    public void RetrieveLevelBuildings(int i)
    {
        List<Building> newBuildings = currentLevelBlueprint.ReturnLevelBuildings(i + 1);
        if (newBuildings.Count > 0 && newBuildings != null)
        {
            foreach (Building b in newBuildings)
            {
                b.gameObject.SetActive(false);
            }
        }
    }

    public void ActivateBlueprint()
    {
        int rand = Random.Range(0, levelBlueprints.Count);
        currentLevelBlueprint = levelBlueprints[rand];
        Instantiate(currentLevelBlueprint.ground);
    }

    public LevelBlueprint ReturnCurrentBlueprint()
    {
        return currentLevelBlueprint;
    }

    public LevelBlueprint ReturnRandomBlueprint()
    {
        int rand = Random.Range(0, levelBlueprints.Count);
        currentLevelBlueprint = levelBlueprints[rand];
        return levelBlueprints[rand];
    }


    public LevelBlueprint ReturnSpecificBlueprint(int i)
    {
        currentLevelBlueprint = levelBlueprints[i];
        return levelBlueprints[i];
    }


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
    public static BlueprintManager Instance;
}
