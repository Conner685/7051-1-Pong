using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private bool player1Goal;

    [SerializeField] private GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (player1Goal)
            {
                gameManager.Player2Scored();
            }
            else 
            {
                gameManager.Player1Scored();
            }
        }
        
        BallMovement ballMovement = other.GetComponent<BallMovement>();
        if (ballMovement != null)
        {
            ballMovement.ResetBall();
        }
    }
}
