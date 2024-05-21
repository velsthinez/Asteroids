using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed = 10f;
    public float BackpedalSpeed = 5f;
    public float SidewaySpeed = 5f;
    public float MaxSpeed = 20f;
    public float DecelSpeed = 0.98f;

    public float RotateSpeed = 0.4f;
    public float MaxRotateSpeed = 2f;
    public float RotateDecelSpeed = 0.9f;
    
    Rigidbody2D _rigidbody2D;
    Renderer[] renderers;

    public Vector3 TargetMovement { get { return _targetMovement; } set { _targetMovement = value; } }
    private Vector3 _targetMovement;

    // Start is called before the first frame update
    void Start()
    {
        renderers = gameObject.GetComponentsInChildren<Renderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        DoTorque();

        DoStrafe();
        
        DoForward();
    }

    /// <summary>
    /// Handles forward movement using _targetMovement.y
    /// </summary>
    protected virtual void DoForward()
    {
        if (_rigidbody2D == null)
            return;
        
        if (_targetMovement.y > 0 && _rigidbody2D.velocity.magnitude < MaxSpeed)
        {
            _rigidbody2D.AddForce(transform.up * (Speed * Time.deltaTime));
        }
        else if (_targetMovement.y < 0 && _rigidbody2D.velocity.magnitude < MaxSpeed)
        {
            _rigidbody2D.AddForce(-transform.up * (BackpedalSpeed * Time.deltaTime));
        }
        else
        {
            _rigidbody2D.velocity *= DecelSpeed;
        }
    }

    /// <summary>
    /// Handles forward movement using _targetMovement.z
    /// </summary>
    protected virtual void DoStrafe()
    {
        if (_rigidbody2D == null)
            return;
        
        if (_targetMovement.z != 0 && _rigidbody2D.velocity.magnitude < MaxSpeed)
        {
            _rigidbody2D.AddForce(transform.right * (_targetMovement.z * (SidewaySpeed * Time.deltaTime)));
        }
    }

    /// <summary>
    /// Handles forward movement using _targetMovement.x
    /// </summary>
    protected virtual void DoTorque()
    {
        if (_rigidbody2D == null)
            return;

        if (_targetMovement.x != 0 &&
            (_rigidbody2D.angularVelocity < MaxRotateSpeed && _rigidbody2D.angularVelocity > -MaxRotateSpeed))
        {
            _rigidbody2D.AddTorque(((_targetMovement.x * RotateSpeed) * -1));
        }
        else
        {
            _rigidbody2D.angularVelocity *= RotateDecelSpeed;
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
