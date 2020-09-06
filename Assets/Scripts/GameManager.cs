using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Character playersCharacter;

    [Header("The Different Area Materials", order = 2), Space(20, order = 1)]
    public List<AreaMaterials> areaMaterials = new List<AreaMaterials>();

    [Header("Difficulties Per Level", order = 2), Space(20, order = 1)]
    public List<LevelDifficulty> levelDifficulties = new List<LevelDifficulty>();


    public AreaMaterials currentArea;
    private bool menuOpen;
    private bool characterUnavailable;

    private int currentLevel;
    private LevelDifficulty currentLevelDifficulty;
    private float currentTimeBetween;
    
    private List<OutfitList> currentOutfitsUnlocked = new List<OutfitList>();
    private BuildingManager buildManager;
    private float timer;

    public void ActivateBuilding()
    {
        int rand = Random.Range(0, currentOutfitsUnlocked.Count);
        buildManager.ActivateBuilding(currentOutfitsUnlocked[rand]);
    }

    public void ChangeCharacterClothes(int i)
    {
        switch (i)
        {
            case 0:
                playersCharacter.ChangeCurrentOutfit(OutfitList.Casual);
                break;
            case 1:
                playersCharacter.ChangeCurrentOutfit(OutfitList.Janitor);
                break;
            case 2:
                playersCharacter.ChangeCurrentOutfit(OutfitList.ZooKeeper);
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
        }
    }

    public void MenuOpen()
    {
        menuOpen = true;
    }

    public void MenuClosed()
    {
        menuOpen = false;
    }

    public void CharacterUnavailable()
    {
        characterUnavailable = true;
    }

    public void CharacterAvailable()
    {
        characterUnavailable = false;
    }

    private void LoadInLevelDifficulty(int i)
    {
        currentLevelDifficulty = levelDifficulties[i - 1];
        bool toAdd = false;

        if(currentLevelDifficulty.specificOutfit != OutfitList.None)
        {
            if (currentOutfitsUnlocked.Count == 0)
            {
                toAdd = true;
            }
            else
            {
                foreach (OutfitList outfit in currentOutfitsUnlocked)
                {
                    if (outfit == currentLevelDifficulty.specificOutfit)
                    {
                        toAdd = true;
                    }
                }
            }
            if(toAdd)
                currentOutfitsUnlocked.Add(currentLevelDifficulty.specificOutfit);
        }
        currentTimeBetween = currentLevelDifficulty.timeBetween;
    }

    public void PrepareNextLevel()
    {
        buildManager.AcceptNewLevel(currentLevel);
        currentLevel++;
    }

    public int ReturnNumberOutfitsUnlocked()
    {
        return currentOutfitsUnlocked.Count;
    }

    public List<OutfitList> ReturnOutfitsUnlockedList()
    {
        return currentOutfitsUnlocked;
    }

    public void SetUpNextLevel()
    {
        buildManager.NextLevel();
        LoadInLevelDifficulty(currentLevel);
        PrepareNextLevel();
    }

    private void Start()
    {
        int rand = Random.Range(0, areaMaterials.Count);
        currentArea = areaMaterials[rand];

        
        buildManager.AcceptAreaMaterials(currentArea);
        playersCharacter.AcceptMaterials(currentArea);

        buildManager.AcceptNewBlueprint();
        PrepareNextLevel();
        SetUpNextLevel();
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

        if(FindObjectsOfType<Character>().Length > 1)
        {
            Debug.LogError("There are 2 characters in the scene.");
        }
        else
        {
            playersCharacter = FindObjectOfType<Character>();
        }

        buildManager = BuildingManager.Instance;
    }
    public static GameManager Instance;

    private void Update()
    {
        if (!menuOpen || characterUnavailable)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Physics.Raycast(ray, out RaycastHit hit, 100);
                playersCharacter.CheckClick(hit);
            }
        }

        if(currentTimeBetween != 0)
        {
            timer += Time.deltaTime;
            if(timer > currentTimeBetween)
            {
                timer = 0;
                ActivateBuilding();
            }
        }
    }
}
