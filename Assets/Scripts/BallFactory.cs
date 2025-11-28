using UnityEngine;

public class BallFactory : MonoBehaviour
{
    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private Transform _ballParent;

    public GameObject CreateBall()
    {
        return Instantiate(_ballPrefab, this.transform.position, Quaternion.identity, _ballParent);
    }
}
