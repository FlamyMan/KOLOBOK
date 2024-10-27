using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private Player_movement _movement;
    [SerializeField] private Button _startGame;
    [SerializeField] private Button _exitGame;

    private void Start()
    {
        _movement.enabled = false;
    }

    private void OnEnable()
    {
        _startGame.onClick.AddListener(StartGame);
        _exitGame.onClick.AddListener(ExitGame);
    }

    private void OnDisable()
    {
        _startGame.onClick.RemoveListener(StartGame);
        _exitGame.onClick.RemoveListener(ExitGame);
    }

    private void StartGame()
    {
        _movement.enabled = true;
        gameObject.SetActive(false);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
