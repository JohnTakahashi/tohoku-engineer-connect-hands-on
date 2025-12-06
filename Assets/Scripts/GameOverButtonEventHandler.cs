using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtonEventHandler : MonoBehaviour
{
    public void OnRestartButtonClicked()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnTitleButtonClicked()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
