using UnityEngine;

public class GameOverJudger : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        // 衝突したオブジェクトがBallタグを持っているか確認
        if (other.gameObject.CompareTag("Ball"))
        {
            BallPhysicsManager ballPhysicsManager = other.gameObject.GetComponent<BallPhysicsManager>();

            // ボールが着地していたらゲームオーバー
            if (ballPhysicsManager.IsLanded)
            {
                Debug.Log("Game Over!");
            }
        }
    }
}
