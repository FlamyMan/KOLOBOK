using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathControl : MonoBehaviour
{
    [SerializeField] private GameObject _deathMenu;

    public event Action OnDeath;

    private void Update()
    {
        if (gameObject.transform.position.y < 0)
        {
            OnDeath?.Invoke();
            _deathMenu.SetActive(true);
        }
    }

    public void RestartScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
