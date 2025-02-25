using UnityEngine;


public class ScreenManager : MonoBehaviour
{
    public void LoadScene (string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene (sceneName);
    }
}
