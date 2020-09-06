using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public OverviewCanvas overviewCanvas;
    public WorldSpaceCanvas worldCanvas;

    public void DisplayToolSwap()
    {
        overviewCanvas.DisplayToolSwap(GameManager.Instance.ReturnOutfitsUnlockedList());
        GameManager.Instance.MenuOpen();
    }

    public void DisplayToolCountdown(Vector3 newPos)
    {
        worldCanvas.DisplayToolCountdown(newPos);
    }

    public static UIManager Instance;

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
