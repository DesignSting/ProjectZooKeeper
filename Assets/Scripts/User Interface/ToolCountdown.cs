using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolCountdown : MonoBehaviour
{
    public Image countdownCircle;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 lookAt = new Vector3(transform.position.x, Camera.main.transform.position.y, transform.position.z - 5);
        gameObject.transform.LookAt(lookAt);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
