using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 10f;
    private Rigidbody2D _rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
        _rigidbody2D.AddRelativeForce(Vector2.up * Speed);
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
            return;
        
        col.SendMessage("Damage",SendMessageOptions.DontRequireReceiver);
        
        Destroy(gameObject);
    }
    
    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
