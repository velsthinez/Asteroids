using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float TopBoundary = 10f;
    public float BotBoundary = -10f;
    public float LeftBoundary = -10f;
    public float RightBoundary = 10f;
    public float Buffer = 0.5f;

    public float Speed = 10f;
    public float MaxSpeed = 20f;
    public float DecelSpeed = 0.98f;

    public float RotateSpeed = 0.4f;
    public float MaxRotateSpeed = 2f;
    public float RotateDecelSpeed = 0.9f;

    public GameObject Bullet;
    public Transform BulletSpawnPosition;

    public ParticleSystem BackExhaustParticleSystem;
    public ParticleSystem RightExhaustParticleSystem;
    public ParticleSystem LeftExhaustParticleSystem;
    
    Rigidbody2D _rigidbody2D;
    Renderer[] renderers;
    
    // Start is called before the first frame update
    void Start()
    {
        renderers = gameObject.GetComponentsInChildren<Renderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_rigidbody2D == null)
            return;
        
        if(Input.GetAxis("Horizontal") > 0 && !RightExhaustParticleSystem.isPlaying )
            RightExhaustParticleSystem.Play(true);
        else if (Input.GetAxis("Horizontal") <= 0 && RightExhaustParticleSystem.isPlaying )
        { 
            RightExhaustParticleSystem.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            
        }
            
        if(Input.GetAxis("Horizontal") < 0 && !LeftExhaustParticleSystem.isPlaying )
            LeftExhaustParticleSystem.Play(true);
        else if(Input.GetAxis("Horizontal") >= 0 && LeftExhaustParticleSystem.isPlaying)
        { 
            LeftExhaustParticleSystem.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }
        
        if(Input.GetAxis("Vertical") > 0 && !BackExhaustParticleSystem.isPlaying)
            BackExhaustParticleSystem.Play(true);
        else if (Input.GetAxis("Vertical") <= 0 && BackExhaustParticleSystem.isPlaying)
        {
                BackExhaustParticleSystem.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }
        
        if (Input.GetAxis("Horizontal") != 0 && (_rigidbody2D.angularVelocity < MaxRotateSpeed && _rigidbody2D.angularVelocity > -MaxRotateSpeed))
        {
            _rigidbody2D.AddTorque( ((Input.GetAxis("Horizontal") * RotateSpeed) * -1 ));
        }
        else
        {

            _rigidbody2D.angularVelocity *= RotateDecelSpeed;
        }
        
        if (Input.GetAxis("Vertical") > 0  && _rigidbody2D.velocity.magnitude < MaxSpeed)
        {
            // BackExhaustParticleSystem.gameObject.SetActive(true);
            _rigidbody2D.AddForce( transform.up  * (Speed * Time.deltaTime));
        }
        else
        {

            // BackExhaustParticleSystem.gameObject.SetActive(false);


            _rigidbody2D.velocity *= DecelSpeed;
            
        }

        if (Input.GetButtonDown("Fire"))
        {
            Instantiate(Bullet, BulletSpawnPosition.position, BulletSpawnPosition.rotation);
            Debug.Log("shoot");
        }
        
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
    
    

    bool CheckRenderers()

    {

        foreach(var renderer in renderers)

        {

            // If at least one render is visible, return true

            if(renderer.isVisible)

            {

                return true;

            }

        }

        // Otherwise, the object is invisible

        return false;

    }

}