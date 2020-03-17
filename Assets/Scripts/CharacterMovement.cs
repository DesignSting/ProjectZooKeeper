using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour
{
    private NavMeshAgent thisAgent;
    private Character thisCharacter;
    private Vector3 currentTarget;

    private bool isMoving;


    public void Move(Vector3 pos)
    {
        Debug.Log(pos);
        NavMeshPath path = new NavMeshPath();
        if (thisAgent.CalculatePath(pos, path))
        {
            thisAgent.path = path;
            isMoving = true;
            currentTarget = thisAgent.pathEndPosition;
        }
    }

    public void Move(Building b)
    {
        NavMeshPath path = new NavMeshPath();
        thisAgent.SetDestination(b.transform.position);
    }

    private float GetPathLength(NavMeshPath path)
    {
        float toReturn = 0.0f;
        for (int i = 1; i < path.corners.Length; i++)
        {
            toReturn += Vector3.Distance(path.corners[i - 1], path.corners[i]);
        }
        return toReturn;
    }

    // Start is called before the first frame update
    void Start()
    {
        thisAgent = GetComponent<NavMeshAgent>();
        thisCharacter = GetComponentInChildren<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            for (int i = 0; i < thisAgent.path.corners.Length - 1; i++)
            {
                Debug.DrawLine(thisAgent.path.corners[i], thisAgent.path.corners[i + 1], Color.red);

            }
            if (thisAgent.path.corners.Length <= 2)
            {
                if (thisAgent.remainingDistance - thisAgent.stoppingDistance <= 0.1f)
                {
                    //thisCharacter.AtDestination();
                    isMoving = false;
                }
            }
        }
    }
}
