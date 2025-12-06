using UnityEngine;
using UnityEngine.InputSystem;

public class ActiveBallController : MonoBehaviour
{
    [SerializeField] private BallFactory _ballFactory;
    [SerializeField] private GameObject _rightWall;
    [SerializeField] private GameObject _leftWall;
    private float _rightLimitX;
    private float _leftLimitX;
    private GameObject _activeBall;
    private readonly float _speed = 5f;
    private const float Margin = 0.01f; // 壁とボールの間に隙間を設ける

    private Keyboard _keyboard = Keyboard.current;
    private bool _isDropped = true;

    private void Awake()
    {
        // 壁の位置を取得
        _rightLimitX = _rightWall.transform.position.x - _rightWall.transform.localScale.x / 2;
        _leftLimitX = _leftWall.transform.position.x + _leftWall.transform.localScale.x / 2;
    }

    private void Start()
    {
        // 最初のボールを生成
        CreateNewActiveBall();
    }   

    private void Update()
    {
        // 落下済みの場合は何もしない
        if (_isDropped) 
            return;

        float moveDistance = 0f;

        if (_keyboard.rightArrowKey.isPressed)
        {
            moveDistance += Time.deltaTime * _speed;
        }

        if (_keyboard.leftArrowKey.isPressed)
        {
            moveDistance -= Time.deltaTime * _speed;
        }

        _activeBall.transform.position = CalcPosition(moveDistance);

        if (_keyboard.spaceKey.wasPressedThisFrame)
        {
            BallPhysicsManager ballPhysicsManager = _activeBall.GetComponent<BallPhysicsManager>();
            ballPhysicsManager.OnLanded += CreateNewActiveBall;   // ボールが着地したときに新しいボールを生成するように登録
            ballPhysicsManager.BallDrop();
            _isDropped = true;
        }
    }

    private void CreateNewActiveBall()
    {
        // 既存のボールがあればイベントを解除
        if (_activeBall != null)
        {
            BallPhysicsManager ballPhysicsManager = _activeBall.GetComponent<BallPhysicsManager>();
            ballPhysicsManager.OnLanded -= CreateNewActiveBall;
        }
        
        _activeBall = _ballFactory.CreateBall();
        _isDropped = false;
    }

    // ボールの新しい位置を計算し、落下時に壁に当たらないように調整する
    private Vector3 CalcPosition(float moveDistance)
    {
        float activeBallRadius = _activeBall.transform.localScale.x / 2;
        float newPosX = _activeBall.transform.position.x + moveDistance;

        if (newPosX > _rightLimitX - activeBallRadius - Margin)
        {
            newPosX = _rightLimitX - activeBallRadius - Margin;
        }
        else if (newPosX < _leftLimitX + activeBallRadius + Margin)
        {
            newPosX = _leftLimitX + activeBallRadius + Margin;
        }

        return new Vector3(newPosX, _activeBall.transform.position.y, _activeBall.transform.position.z);
    }
}
