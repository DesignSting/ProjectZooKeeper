using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Character playersCharacter;

    public AreaMaterials zooArea;

    private int currentArea;
    private bool menuOpen;

    public void ChangeCharacterClothes(int i)
    {
        switch (i)
        {
            case 0:
                playersCharacter.ChangeCurrentOutfit(CurrentOutfit.Casual);
                break;
            case 1:
                playersCharacter.ChangeCurrentOutfit(CurrentOutfit.Janitor);
                break;
            case 2:
                playersCharacter.ChangeCurrentOutfit(CurrentOutfit.ZooKeeper);
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

    private void Start()
    {
        BuildingManager.Instance.PaintBuildings(zooArea);
        playersCharacter.AcceptMaterials(zooArea);
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
    public static GameManager Instance;

    private void Update()
    {
        if (!menuOpen)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Physics.Raycast(ray, out RaycastHit hit, 100);
                playersCharacter.CheckClick(hit);
            }
        }
    }
}
