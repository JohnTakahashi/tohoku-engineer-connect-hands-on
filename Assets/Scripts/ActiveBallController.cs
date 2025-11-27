using UnityEngine;
using UnityEngine.InputSystem;

public class ActiveBallController : MonoBehaviour
{
    [SerializeField] private GameObject _activeBall;
    private readonly float _speed = 5f;

    private Keyboard _keyboard = Keyboard.current;
    private bool _isDropped = false;

    private void Update()
    {
        // 落下済みの場合は何もしない
        if (_isDropped) 
            return;

        if (_keyboard.rightArrowKey.isPressed)
        {
            _activeBall.transform.Translate(Time.deltaTime * _speed, 0, 0);
        }

        if (_keyboard.leftArrowKey.isPressed)
        {
            _activeBall.transform.Translate(-Time.deltaTime * _speed, 0, 0);
        }

        if (_keyboard.spaceKey.wasPressedThisFrame)
        {
            var ballPhysicsManager = _activeBall.GetComponent<BallPhysicsManager>();
            ballPhysicsManager.BallDrop();
            _isDropped = true;
        }
    }
}
