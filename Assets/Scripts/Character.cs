using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CurrentOutfit CurrentOutfit;

    private CharacterMovement thisCharacter;
    [SerializeField] private Building currentTarget;

    private void CheckClick(RaycastHit hit)
    {
        if (hit.transform.tag == "Building")
        {
            Debug.Log("Building");
            currentTarget = hit.transform.GetComponent<Building>();
            thisCharacter.Move(currentTarget);
        }
        else
        {
            thisCharacter.Move(hit.point);
            currentTarget = null;
        }
    }

    public CurrentOutfit ReturnCurrentOutfit()
    {
        return CurrentOutfit;
    }

    public Building ReturnCurrentTarget()
    {
        return currentTarget;
    }

    // Start is called before the first frame update
    void Start()
    {
        thisCharacter = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount == 1)
        {
            if(Input.GetTouch(1).phase == TouchPhase.Ended)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(1).position);
                Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity);
                CheckClick(hit);
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity);
            CheckClick(hit);
        }
    }
}

public enum CurrentOutfit
{
    Janitor,
    ZooKeeper
}
