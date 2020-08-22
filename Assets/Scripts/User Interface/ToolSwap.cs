using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSwap : MonoBehaviour
{
    public void ChangeClothes(int i)
    {
        GameManager.Instance.ChangeCharacterClothes(i);
        HideToolSwap();
        GameManager.Instance.MenuClosed();
    }

    public void DisplayToolSwap()
    {
        gameObject.SetActive(true);
    }

    public void HideToolSwap()
    {
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        gameObject.SetActive(false);
    }
}
