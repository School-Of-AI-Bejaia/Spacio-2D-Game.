using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    [SerializeField]private PlayerController _player;
    [SerializeField]private EarthPlanet _earth;
    private int _playerScore;

    public static GameManager Instance => _instance;
    public PlayerController Player => _player;
    
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        
        AudioManager.Instance.Play(Audio.AudioClipsNames.GamePlay);
    }

    public void AddScore(int score)
    {
        _playerScore += score;
        UiManager.Instance.ChangeScoreText(_playerScore);
    }

    public void GameOver()
    {
        _player.GetComponent<Rigidbody2D>().gravityScale = 0.3f;
        _player.GetComponent<BoxCollider2D>().enabled = false;
        _earth.GetComponent<Rigidbody2D>().gravityScale = 0.3f;
        _player.enabled = false;
        _earth.enabled = false;
        
        if (_playerScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", _playerScore);
        }

        UiManager.Instance.GameOver();
    }

    public void PauseResumeGame(int timeScale)
    {
        Time.timeScale = timeScale;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
