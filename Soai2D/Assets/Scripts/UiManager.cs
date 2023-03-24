using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class UiManager : MonoBehaviour
{
    private static UiManager _instance;
    // [SerializeField] private TMP_Text _playerHPText;
    // [SerializeField] private TMP_Text _earthHPText;
    [SerializeField] private TMP_Text _playerScoreText;
    [SerializeField] private TMP_Text _soaiBulletsText;
    [SerializeField] private TMP_Text _waveTimeText;
    [SerializeField] private GameObject _gameOverMenu;

    [SerializeField] private GameObject _playersHPGroup;
    [SerializeField] private GameObject _earthHPGroup;
    private List<Transform> _playersHP;
    private List<Transform> _earthHP;
        
    
    public static UiManager Instance => _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;

        _playersHP = new List<Transform>(_playersHPGroup.transform.GetComponentsInChildren<Transform>());
        _earthHP = new List<Transform>(_earthHPGroup.transform.GetComponentsInChildren<Transform>());
    }


    public void ChangeBulletsNumber(int bulletsNb)
    {
        _soaiBulletsText.text = $"x {bulletsNb}";
    }

    public void ChangePlayerHealth()
    {
        // _playerHPText.text = hp.ToString();
        Destroy(_playersHP[_playersHP.Count - 1].gameObject);
        _playersHP.RemoveAt(_playersHP.Count - 1);

    }
    
    public void ChangeEarthHealth()
    {
        // _earthHPText.text = hp.ToString();
        Destroy(_earthHP[_earthHP.Count - 1].gameObject);
        _earthHP.RemoveAt(_earthHP.Count - 1);
    }

    public void ChangeScoreText(int score)
    {
        _playerScoreText.SetText($"x {score}");
    }
    
    public void ChangeWaveNumber(int waveNumber)
    {
        _waveTimeText.text = waveNumber.ToString();
    }

    public void GameOver()
    {
        _gameOverMenu.SetActive(true);
    }
}
