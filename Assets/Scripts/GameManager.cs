using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI ballsRemainingText;

    [SerializeField] int numBalls;

    private int score;

    GameObject currBall;

    // Start is called before the first frame update
    void Start()
    {
        UpdateBalls(0);
        currBall = Instantiate(ball, FindBallPos(), ball.transform.rotation);
        currBall.SetActive(false);

        score = 0;
        UpdateScore(0);

    }

    // Update is called once per frame
    void Update()
    {
        currBall.transform.position = FindBallPos();
        //Debug.Log("Mouse Position: " + mousePos.x);

        if (Input.GetMouseButtonDown(0))
        {
            currBall.SetActive(true);       
        }

        if (Input.GetMouseButtonUp(0))
        {
            UpdateBalls(-1);
            Rigidbody currBallRb = currBall.GetComponent<Rigidbody>();
            currBallRb.useGravity = true;

            currBall = Instantiate(ball, FindBallPos(), ball.transform.rotation);
            currBall.SetActive(false);
        }


    }

    private Vector3 FindBallPos()
    {
        
        Vector3 ballPos = ball.transform.position;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 0));
        ballPos.x = mousePos.x;

        return ballPos;

    }

    public void UpdateScore(int addScore)
    {
        score += addScore;
        scoreText.text = "Score: " + score;

    }

    public void UpdateBalls(int updateNum)
    {
        numBalls += updateNum;
        ballsRemainingText.text = "Balls Remaining: " + numBalls;
    }

}
