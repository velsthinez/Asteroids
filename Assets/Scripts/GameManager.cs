using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Beginning,
        Started,
        End
    }

    public GameState State = GameState.Beginning;

    public GameObject PlayerPrefab;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey && State != GameState.Started)
        {
            Instantiate(PlayerPrefab, transform.position, transform.rotation);
            State = GameState.Started;
        }

    }
}
