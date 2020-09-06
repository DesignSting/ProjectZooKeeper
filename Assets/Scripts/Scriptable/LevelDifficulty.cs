using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Game Options/Level Difficulty"), ExecuteInEditMode]
public class LevelDifficulty : ScriptableObject
{
    public OutfitList specificOutfit;
    public float timeBetween;
    public int amountToNextLevel;
}
