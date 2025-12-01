using System;
using UnityEngine;

public class BallPhysicsManager : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    
    public int BallSize { get; private set; }

    public event Action OnLanded;
    public event Action<GameObject, GameObject, int> OnBallCollided;

    public void Initialize(int ballSize, bool isDropped)
    {
        BallSize = ballSize;

        if (isDropped)
        {
            BallDrop();
        }
    }

    public void BallDrop()
    {
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;  // 物理演算(重力)を有効化
    }

    // 衝突時にUnityが自動的に呼び出す関数
    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnLanded?.Invoke();

        // 衝突したオブジェクトがBallタグを持っているか確認
        if (collision.gameObject.CompareTag("Ball"))
        {
            BallPhysicsManager otherBallPhysicsManager = collision.gameObject.GetComponent<BallPhysicsManager>();
            // 衝突した相手のボールのサイズが同じか確認
            if (otherBallPhysicsManager != null && otherBallPhysicsManager.BallSize == this.BallSize)
            {
                OnBallCollided?.Invoke(this.gameObject, collision.gameObject, this.BallSize);
            }
        }
    }
}
