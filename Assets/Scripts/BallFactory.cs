using UnityEngine;

public class BallFactory : MonoBehaviour
{
    [SerializeField] private GameObject[] _ballPrefab;
    [SerializeField] private Transform _ballParent;

    public GameObject CreateBall()
    {
        int ballSize = Random.Range(0, 5);
        return Instantiate(_ballPrefab[ballSize], this.transform.position, Quaternion.identity, _ballParent);
    }
}
