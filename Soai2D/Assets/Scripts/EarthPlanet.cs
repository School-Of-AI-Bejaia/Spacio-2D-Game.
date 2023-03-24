using UnityEngine;

public class EarthPlanet : MonoBehaviour
{
    [SerializeField] private Transform _startPos;
    [SerializeField] private Transform _endPos;
    [SerializeField] private float _ySpeed;
    private Vector2 _targetPos;
    private Rigidbody2D _rb;

    [SerializeField] private int _hp;
    [SerializeField] private float _immuneTime;
    private float _remainingImmuneTime;
    
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _targetPos = _startPos.position;
    }

    private void Update()
    {
        _remainingImmuneTime -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (_rb.position != _targetPos)
            _rb.velocity = (_targetPos - _rb.position).normalized * _ySpeed * Time.fixedDeltaTime;
        else
            _targetPos = (Vector3)_targetPos == _startPos.position? _endPos.position: _startPos.position;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Asteroid"))
        {
            ReceiveDamage();
            col.GetComponent<Animator>().Play("asteroid_destroy");   
        }
    }

    private void ReceiveDamage()
    {
        if(_remainingImmuneTime > 0)
            return;
        
        _hp--;
        _remainingImmuneTime = _immuneTime;
        GetComponent<Animator>().Play("earth_hurt");
        // UI
        UiManager.Instance.ChangeEarthHealth();
        
        if (_hp <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }
}