using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour
{
    public float MinForce = 1f;
    public float MaxForce = 10f;

    public GameObject DeathParticles;
    
    public int Health = 1;
    public int Score = 100;
    private Rigidbody2D _rigidbody;

    protected ScorePanel _scorePanel;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        
        float randomForce = Random.Range(MinForce, MaxForce);
        
        Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;

        Debug.Log(randomForce + " " + randomDirection);
        
        _rigidbody.AddForce(randomDirection * randomForce );
    }

    void Damage()
    {
        Health--;

        if (Health <= 0)
        {
            Instantiate(DeathParticles, transform.position, transform.rotation);
            _scorePanel.UpdateScore(Score);
            Destroy(gameObject);
        }
    }

    public void Move(Vector2 direction, float force   )
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag("Player"))
            return;
        
        col.gameObject.SendMessage("Damage",SendMessageOptions.DontRequireReceiver);

    }

    public void SetupScorePanel(ScorePanel scorePanel)
    {
        _scorePanel = scorePanel;
    }
}
