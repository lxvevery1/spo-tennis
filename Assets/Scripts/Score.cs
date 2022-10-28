using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class Score : NetworkBehaviour
{
    private float BallBorder = 12f;
    [SerializeField] public Text ScoreText1, ScoreText2;
    public int ScorePlayer1, ScorePlayer2;
    public ball Ball;
    private void Start()
    {
        ScoreText1.text = "0";
        ScoreText2.text = "0";
    }
    void Update()
    {
        ScorePlus();
    }
    
    private void ScorePlus()
    {
        if (Ball.PosBall.x < -BallBorder)
        {
            ScorePlayer1 += 1;
            //Ball.updateScore(ScorePlayer1);
            //Ball._Reset();
        }

        if (Ball.PosBall.x > BallBorder)
        {
            ScorePlayer2 += 1;
            //Ball.updateScore(ScorePlayer2);
            //Ball._Reset();
        }
    }
}
