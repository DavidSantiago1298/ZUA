using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField]

    private UnityEvent onGameStart;

    [SerializeField]

    private UnityEvent onRespawnGame;

    [SerializeField]

    private UnityEvent onFinishGame;

    [SerializeField]

    private UnityEvent onLoseGame;

    [SerializeField]

    private UnityEvent onShowGameOverScreen;
    [SerializeField]

    private float secondsToRestart = 2f;

    [SerializeField]

    private float finalSecondsToRestart = 5f;

    [SerializeField]

    private float secondsToShowGameOverScreen = 3f;

    private void Awake()
    {
        secondsToRestart += secondsToShowGameOverScreen;
        finalSecondsToRestart += secondsToShowGameOverScreen;
    }


    void Start()
    {
        onGameStart?.Invoke();
        
    }

    public void LoseGame()
    {
        onLoseGame?.Invoke();
        Invoke("ShowGameOverScreen", secondsToShowGameOverScreen);
    }

    private void  ShowGameOverScreen()
    {
        onShowGameOverScreen?.Invoke();
    }

    public void RespawnGame()
    {
        Invoke("RestartGame", secondsToRestart);
    }

    public void FinishGame()
    {
        onFinishGame?.Invoke();
        Invoke("Start", finalSecondsToRestart);
        Invoke("RestartGame", finalSecondsToRestart);
        

    }

    private void RestartGame()
    {
        onRespawnGame?.Invoke();
    }
}
