using System;
using UnityEngine;

public class BallPhysicsManager : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    
    public int BallSize { get; private set; }
    public bool IsLanded { get; private set; } = false;

    public event Action OnLanded;
    public event Action<GameObject, GameObject, int> OnBallCollided;

    private readonly float[] _bouncinessTable = {
        0.1f, 0.15f, 0.2f, 0.25f, 0.3f,
        0.35f, 0.4f, 0.45f, 0.5f, 0.55f
    };

    public void Initialize(int ballSize, bool isDropped)
    {
        BallSize = ballSize;

        ApplyBounciness();

        if (isDropped)
        {
            BallDrop();
        }
    }
    private void ApplyBounciness()
    {
        if (BallSize < 0 || BallSize >= _bouncinessTable.Length) return;

        PhysicsMaterial2D mat = new PhysicsMaterial2D("BallMaterial_" + BallSize);
        mat.bounciness = _bouncinessTable[BallSize];
        mat.friction = 0.4f;

        _rigidbody.sharedMaterial = mat;
    }

    public void BallDrop()
    {
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;  // 物理演算(重力)を有効化
    }

    // 衝突時にUnityが自動的に呼び出す関数
    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnLanded?.Invoke();
        IsLanded = true;

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
