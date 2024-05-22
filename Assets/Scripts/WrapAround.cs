using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapAround : MonoBehaviour
{
    
    public float TopBoundary = 5.5f;
    public float BotBoundary = -5.5f;
    public float LeftBoundary = -8.5f;
    public float RightBoundary = 8.5f;
    public float Buffer = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > TopBoundary )
        {
            transform.position = new Vector3(transform.position.x, (transform.position.y * -1) + Buffer, transform.position.z);

        }        
        
        if (transform.position.y < BotBoundary )
        {
            transform.position = new Vector3(transform.position.x, (transform.position.y * -1) - Buffer, transform.position.z);

        }
        
        if (transform.position.x > RightBoundary )
        {
            transform.position = new Vector3( (transform.position.x *-1) + Buffer, transform.position.y, transform.position.z);

        }        
        
        if (transform.position.x < LeftBoundary )
        {
            transform.position = new Vector3( (transform.position.x *-1) - Buffer, transform.position.y, transform.position.z);

        }
    }
}
