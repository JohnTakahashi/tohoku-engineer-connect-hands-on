using UnityEngine;

public class BallFactory : MonoBehaviour
{
    [SerializeField] private GameObject[] _ballPrefab;
    [SerializeField] private Transform _ballParent;

    public GameObject CreateBall()
    {
        int ballSize = Random.Range(0, 5);
        return CreateBall(ballSize, this.transform.position, false);    // アクティブなボール生成時は落下させない
    }

    public GameObject CreateBall(int ballSize, Vector3 position, bool isDropped = true)
    {
        GameObject newBall = Instantiate(_ballPrefab[ballSize], position, Quaternion.identity, _ballParent);
        BallPhysicsManager ballPhysicsManager = newBall.GetComponent<BallPhysicsManager>();
        ballPhysicsManager.Initialize(ballSize, isDropped);
        // TODO: BallPhysicsManagerのOnCollidedイベントにBallMergerのMergeBallを登録する
        return newBall;
    }
}
