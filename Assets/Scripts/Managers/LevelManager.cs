using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<LevelDifficulty> levelList = new List<LevelDifficulty>();

    public LevelDifficulty ReturnLevel(int i)
    {
        return levelList[i];
    }
}
