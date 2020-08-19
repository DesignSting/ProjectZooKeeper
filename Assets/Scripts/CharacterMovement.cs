using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Movement
{
    public class CharacterMovement : MonoBehaviour
    {
        private bool isMoving;

        
        public static bool Move(NavMeshAgent thisAgent, Vector3 pos, out NavMeshPath path)
        {
            path = new NavMeshPath();
            if (thisAgent.CalculatePath(pos, path))
            {
                thisAgent.path = path;
                return true;
            }
            return false;
        }

        public static bool Move(NavMeshAgent thisAgent, List<Transform> transformList, out NavMeshPath path, out Vector3 theTarget)
        {
            Debug.Log("Character Move");
            float closest = 0;
            int target = 0;
            bool isPath = false;
            path = null;
            theTarget = new Vector3();
            List<NavMeshPath> pathList = new List<NavMeshPath>(transformList.Count);
            for (int i = 0; i < transformList.Count; i++)
            {
                pathList.Add(new NavMeshPath());
                thisAgent.CalculatePath(transformList[i].position, pathList[i]);
                float f = GetPathLength(pathList[i]);
                if (i == 0)
                {
                    closest = f;
                }
                else if (closest > f)
                {
                    closest = f;
                    target = i;
                }
            }
            if (closest != 0)
            {
                path = pathList[target];
                theTarget = thisAgent.pathEndPosition;
                isPath = true;
            }
            return isPath;
        }

        private static float GetPathLength(NavMeshPath path)
        {
            float toReturn = 0.0f;
            for (int i = 1; i < path.corners.Length; i++)
            {
                toReturn += Vector3.Distance(path.corners[i - 1], path.corners[i]);
            }
            return toReturn;
        }

        public static void PaintPath(NavMeshAgent thisAgent, out bool toReturn)
        {
            toReturn = true;
            for (int i = 0; i < thisAgent.path.corners.Length - 1; i++)
            {
                Debug.DrawLine(thisAgent.path.corners[i], thisAgent.path.corners[i + 1], Color.red);
            }
            if (thisAgent.remainingDistance <= thisAgent.stoppingDistance)
            {
                if (!thisAgent.hasPath || thisAgent.velocity.sqrMagnitude == 0f)
                {
                    Debug.Log("This is the end");
                    toReturn = false;
                }
            }
        }
    }
}
