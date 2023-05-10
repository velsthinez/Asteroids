using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{

    public float Duration = 1f;

    protected float _durationRemaining = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        _durationRemaining = Duration;
    }

    // Update is called once per frame
    void Update()
    {
        if(_durationRemaining <= 0)
            Destroy(gameObject);
        
        _durationRemaining -= Time.deltaTime;
    }
}
