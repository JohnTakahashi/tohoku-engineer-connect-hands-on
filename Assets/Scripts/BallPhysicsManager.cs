using UnityEngine;

public class BallPhysicsManager : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;

    public void BallDrop()
    {
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;  // 物理演算(重力)を有効化
    }
}
