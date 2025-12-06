using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtonEventHandler : MonoBehaviour
{
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnExitButtonClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
