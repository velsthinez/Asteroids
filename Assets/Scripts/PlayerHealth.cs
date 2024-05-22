using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameManager GameManager;
    
    public int CurrentHealth = 1;
    public GameObject DeathParticles;
    public GameObject DeathSound;

    // Start is called before the first frame update
    void Start()
    {
        GameManager = FindObjectOfType<GameManager>();
    }

    void Damage()
    {
        CurrentHealth--;

        if (CurrentHealth > 0)
            return;
        
        Instantiate(DeathParticles, transform.position, transform.rotation);
        Instantiate(DeathSound, transform.position, transform.rotation);
        
        GameManager.State = GameManager.GameState.End;

        Destroy(gameObject);
    }
}
