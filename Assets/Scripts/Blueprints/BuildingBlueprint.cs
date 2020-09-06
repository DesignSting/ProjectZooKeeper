using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBlueprint : MonoBehaviour
{
    public BuildingType buildingType;
    public BoxCollider buildingOutline;
    public List<SphereCollider> accessPointOutlines = new List<SphereCollider>();
    public List<SphereCollider> visitorPointOutline = new List<SphereCollider>();

    void OnDrawGizmos()
    {
        switch (buildingType)
        {
            case BuildingType.ToolShed:
                Gizmos.color = Color.yellow;
                break;
            case BuildingType.Bathroom:
                Gizmos.color = Color.red;
                break;
            case BuildingType.SmallExhibition:
                Gizmos.color = Color.red;
                break;
            case BuildingType.MediumExhibition:
                Gizmos.color = Color.magenta;
                break;
            case BuildingType.LargeExhibition:
                Gizmos.color = Color.green;
                break;
        }
        
        Gizmos.DrawCube(buildingOutline.gameObject.transform.position, buildingOutline.gameObject.transform.lossyScale);

        Gizmos.color = Color.white;
        foreach(SphereCollider sphere in accessPointOutlines)
            Gizmos.DrawSphere(sphere.transform.localPosition, sphere.radius);

        Gizmos.color = Color.black;
        foreach (SphereCollider sphere in visitorPointOutline)
            Gizmos.DrawSphere(sphere.transform.localPosition, sphere.radius);
    }
}
