using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameManager GameManager;

    public GameObject UI;
    // Update is called once per frame
    void Update()
    {
        if (GameManager.State != GameManager.GameState.Started)
        {
            UI.SetActive(true);
        }
        else
        {
            UI.SetActive(false);
        }
    }
}
