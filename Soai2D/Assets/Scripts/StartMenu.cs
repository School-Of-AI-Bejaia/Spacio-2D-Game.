using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _highScoreText;

    private void Start()
    {
        _highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        AudioManager.Instance.Play(Audio.AudioClipsNames.GamePlay);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
