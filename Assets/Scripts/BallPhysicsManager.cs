using System;
using UnityEngine;

public class BallPhysicsManager : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;

    public event Action OnLanded;

    public void BallDrop()
    {
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;  // 物理演算(重力)を有効化
    }

    // 衝突時にUnityが自動的に呼び出す関数
    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnLanded?.Invoke();
    }
}
