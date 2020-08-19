using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Movement;

public class CharacterAI : MonoBehaviour
{
    private NavMeshAgent thisAgent;
    private Character thisCharacter;

    private Vector3 currentTarget;
    [SerializeField] private bool isMoving;

    public void MoveCharacter(Vector3 clickedPos)
    {
        currentTarget = new Vector3();
        if(CharacterMovement.Move(thisAgent, clickedPos, out NavMeshPath path))
        {
            currentTarget = clickedPos;
            thisAgent.path = path;
            isMoving = true;
        }
    }

    public void MoveCharacter(Building building)
    {
        List<Transform> transList = building.ReturnAccessPoints();
        if(CharacterMovement.Move(thisAgent, transList, out NavMeshPath path, out currentTarget))
        {
            thisAgent.path = path;
            isMoving = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        thisAgent = GetComponent<NavMeshAgent>();
        thisCharacter = GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            CharacterMovement.PaintPath(thisAgent, out bool currentState);
            if (!currentState)
            {
                isMoving = false;
                thisCharacter.DestinationReached();
            }
        }
    }
}
