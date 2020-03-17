using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public List<Transform> accessPoints = new List<Transform>();
    public CurrentOutfit currentOutfitNeeded;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Character")
        {
            Character c = other.GetComponent<Character>();
            if (c.ReturnCurrentTarget() == this)
            {
                if(c.ReturnCurrentOutfit() == currentOutfitNeeded)
                {
                    Debug.Log("This is correct");

                    //StartCoroutine(StartCountdown(c));
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

    private IEnumerator StartCountdown(Character c)
    {
        yield return null;
    }
}
