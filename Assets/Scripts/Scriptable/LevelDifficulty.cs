using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Game Options/Level Difficulty"), ExecuteInEditMode]
public class LevelDifficulty : ScriptableObject
{
    public int jobsUnlocked;
    public float timeBetween;

}
