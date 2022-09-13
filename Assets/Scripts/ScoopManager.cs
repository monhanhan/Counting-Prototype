using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoopManager : MonoBehaviour
{

    [SerializeField] int scoreVal;
    private GameManager gameManager;
    private bool isColliding;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        isColliding = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isColliding) return;
        isColliding = true;

        StartCoroutine(ResetCollide());

        Debug.Log("Value passed: " + scoreVal);
        gameManager.UpdateScore(scoreVal);
    }

    private IEnumerator ResetCollide()
    {
        yield return new WaitForEndOfFrame();
        isColliding = false;
    }
}
