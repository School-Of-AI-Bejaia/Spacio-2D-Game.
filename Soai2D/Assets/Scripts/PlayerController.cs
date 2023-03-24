using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private float _speed;
    [SerializeField]private float _speedLerp;
    private Vector2 _direction;

    [SerializeField] private Transform _bulletPosition;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _shootForce;
    private int _bulletsNb;

    [SerializeField] private int _hp;
    [SerializeField] private float _immuneTime;
    private float _remainingImmuneTime;
    
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet");
    }
    
    
    private void FixedUpdate()
    {
        _rb.AddForce(_direction * _speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        
        _rb.velocity = Vector2.Lerp(_rb.velocity, Vector2.zero, _speedLerp * Time.fixedDeltaTime);
    }
    private void Update()
    {
        // Input
        _direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if(Input.GetKeyDown(KeyCode.Space))
            ShootBullet();
        
        _remainingImmuneTime -= Time.deltaTime;
    }

    public void ReceiveDamage()
    {
        if (_remainingImmuneTime > 0 || _hp <= 0)
            return;

        _hp--;
        _remainingImmuneTime = _immuneTime;
        GetComponent<Animator>().Play("player_hurt");
        
        //UI
        UiManager.Instance.ChangePlayerHealth();
        
        if (_hp <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }

    public void ShootBullet()
    {
        if (_bulletsNb <= 0)
            return;
        
        GameObject bullet = Instantiate(_bulletPrefab, _bulletPosition.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(_shootForce, 0));
        _bulletsNb--;
        // UI
        UiManager.Instance.ChangeBulletsNumber(_bulletsNb);
        
        AudioManager.Instance.Play(Audio.AudioClipsNames.Bullet);

    }
    
    public void AddBullets()
    {
        _bulletsNb += 5;
        UiManager.Instance.ChangeBulletsNumber(_bulletsNb);
    }
}
