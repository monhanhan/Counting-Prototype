using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoopManager : MonoBehaviour
{

    [SerializeField] int scoreVal;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        gameManager.UpdateScore(scoreVal);
    }
}
