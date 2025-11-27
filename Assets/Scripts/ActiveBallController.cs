using UnityEngine;
using UnityEngine.InputSystem;

public class ActiveBallController : MonoBehaviour
{
    [SerializeField] private GameObject _activeBall;
    private readonly float _speed = 5f;

    private Keyboard _keyboard = Keyboard.current;

    private void Update()
    {
        if (_keyboard.rightArrowKey.isPressed)
        {
            _activeBall.transform.Translate(Time.deltaTime * _speed, 0, 0);
        }

        if (_keyboard.leftArrowKey.isPressed)
        {
            _activeBall.transform.Translate(-Time.deltaTime * _speed, 0, 0);
        }
    }
}
