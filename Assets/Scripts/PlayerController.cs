using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    public Exhaust ExhaustPrefab;
    public WeaponHandler WeaponHandler;

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        Movement = new Vector3(

            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"),
            Input.GetAxis("Sideways")
        );

        _movement.TargetMovement = Movement;
        ExhaustPrefab.Movement = Movement;
        
        if(Input.GetButtonDown("Fire"))
            WeaponHandler.Fire();
    }

}
