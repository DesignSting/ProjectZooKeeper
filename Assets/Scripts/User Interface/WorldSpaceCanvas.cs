using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpaceCanvas : MonoBehaviour
{
    public GameObject toolCountdownPrefabs;


    public void DisplayToolCountdown(Vector3 newPos)
    {
        Instantiate(toolCountdownPrefabs, newPos, Quaternion.identity, transform);
    }
}
