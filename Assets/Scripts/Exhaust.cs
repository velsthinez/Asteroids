using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exhaust : MonoBehaviour
{
    public Vector3 Movement;
    
    public ParticleSystem BackExhaustParticleSystem;
    public ParticleSystem FrontExhaustParticleSystem;
    public ParticleSystem RightExhaustParticleSystem;
    public ParticleSystem LeftExhaustParticleSystem;
    public ParticleSystem SidewayRightExhaustParticleSystem;
    public ParticleSystem SidewayLeftExhaustParticleSystem;


    // Update is called once per frame
    void Update()
    {
        if (BackExhaustParticleSystem == null ||
            FrontExhaustParticleSystem == null ||
            RightExhaustParticleSystem == null ||
            LeftExhaustParticleSystem == null ||
            SidewayRightExhaustParticleSystem == null ||
            SidewayLeftExhaustParticleSystem == null
           )
            return;

        if (Movement.z < 0 && !SidewayRightExhaustParticleSystem.isPlaying)
            SidewayRightExhaustParticleSystem.Play(true);
        else if (Movement.z >= 0 && SidewayRightExhaustParticleSystem.isPlaying)
        {
            SidewayRightExhaustParticleSystem.Stop(true, ParticleSystemStopBehavior.StopEmitting);

        }

        if (Movement.z > 0 && !SidewayLeftExhaustParticleSystem.isPlaying)
            SidewayLeftExhaustParticleSystem.Play(true);
        else if (Movement.z <= 0 && SidewayLeftExhaustParticleSystem.isPlaying)
        {
            SidewayLeftExhaustParticleSystem.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }

        if (Movement.x > 0 && !RightExhaustParticleSystem.isPlaying)
            RightExhaustParticleSystem.Play(true);
        else if (Movement.x <= 0 && RightExhaustParticleSystem.isPlaying)
        {
            RightExhaustParticleSystem.Stop(true, ParticleSystemStopBehavior.StopEmitting);

        }

        if (Movement.x < 0 && !LeftExhaustParticleSystem.isPlaying)
            LeftExhaustParticleSystem.Play(true);
        else if (Movement.x >= 0 && LeftExhaustParticleSystem.isPlaying)
        {
            LeftExhaustParticleSystem.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }

        if (Movement.y > 0 && !BackExhaustParticleSystem.isPlaying)
            BackExhaustParticleSystem.Play(true);
        else if (Movement.y < 0 && !FrontExhaustParticleSystem.isPlaying)
        {
            FrontExhaustParticleSystem.Play(true);
        }
        else if (Movement.y == 0)
        {
            if (BackExhaustParticleSystem.isPlaying)
                BackExhaustParticleSystem.Stop(true, ParticleSystemStopBehavior.StopEmitting);

            if (FrontExhaustParticleSystem.isPlaying)
                FrontExhaustParticleSystem.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }
    }
}