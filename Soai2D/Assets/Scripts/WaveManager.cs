using UnityEngine;
using Random = UnityEngine.Random;

public class WaveManager : MonoBehaviour
{
    private GameObject _asteroidPrefab;
    private GameObject _soaiBulletPrefab;
    private GameObject _scorePrefab;
    private GameObject[] _asteroidsPositions;
    private GameObject[] _soaiPositions;
    [SerializeField] private float _asteroidCooldown;
    [SerializeField] private float _soaiCooldown;
    [SerializeField] private int _waveTime;
    private float _asteroidRemainingCooldown;
    private float _soaiRemainingCooldown;
    private float _waveRemainingTime;
    private int _waveNumber = 1;
    
    private const float MinAsteroidCooldown = 0.25f;
    

    private void Start()
    {
        _asteroidPrefab = Resources.Load<GameObject>("Prefabs/Asteroid");
        _soaiBulletPrefab = Resources.Load<GameObject>("Prefabs/SoaiBullet");
        _scorePrefab = Resources.Load<GameObject>("Prefabs/SoaiScore");
        
        _asteroidsPositions = GameObject.FindGameObjectsWithTag("AsteroidPosition");
        _soaiPositions = GameObject.FindGameObjectsWithTag("SoaiPosition");
        
        _asteroidRemainingCooldown = _asteroidCooldown;
        _soaiRemainingCooldown = _soaiCooldown / 2;
        _waveRemainingTime = _waveTime;
    }

    private void Update()
    {
        _asteroidRemainingCooldown -= Time.deltaTime;
        _soaiRemainingCooldown -= Time.deltaTime;
        _waveRemainingTime -= Time.deltaTime;

        if (_asteroidRemainingCooldown <= 0)
        {
            GenerateAsteroid();
            _asteroidRemainingCooldown = _asteroidCooldown;
        }

        if (_soaiRemainingCooldown <= 0)
        {
            GenerateSoai();
            _soaiRemainingCooldown = _soaiCooldown;
        }

        if (_waveRemainingTime <= 0)
        {
            _waveNumber++;
            _waveTime += 4;
            if (_asteroidCooldown > MinAsteroidCooldown)
            {
                _asteroidCooldown -= 0.25f;
                _soaiCooldown -= 0.25f;
            }
            _waveRemainingTime = _waveTime;
            //UI
            UiManager.Instance.ChangeWaveNumber(_waveNumber);
        }
    }
    
    private void GenerateAsteroid()
    {
        Instantiate(_asteroidPrefab, _asteroidsPositions[Random.Range(0, _asteroidsPositions.Length)].transform.position, Quaternion.identity);
    }

    private void GenerateSoai()
    {
        GameObject soai = Random.Range(0, 2) == 1 ? _soaiBulletPrefab : _scorePrefab;
        Instantiate(soai, _soaiPositions[Random.Range(0, _soaiPositions.Length)].transform.position, Quaternion.identity);
    }
}