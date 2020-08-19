using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingBuilding : Building
{



    public override void StartSession(Character c)
    {
        if (c.CurrentOutfit == currentOutfitNeeded)
        {
            currentCharacter = c;
            c.gameObject.SetActive(false);
            currentlyInside = true;
        }
    }

    private IEnumerator StartCountdown(Character c)
    {
        timer = 6;
        while (timer > 0)
        {
            foreach (MeshRenderer m in c.GetComponentsInChildren<MeshRenderer>())
            {
                Color color = m.material.color;
                color.a = timer / 6;
                timer -= Time.deltaTime;
            }
            yield return null;
        }
        timer = 0;
        currentlyInside = true;
        yield return null;
    }

    private void Update()
    {
        if (currentlyInside)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                Debug.Log("It is done");
                currentlyInside = false;
                currentCharacter.gameObject.SetActive(true);
            }
        }
    }
}
