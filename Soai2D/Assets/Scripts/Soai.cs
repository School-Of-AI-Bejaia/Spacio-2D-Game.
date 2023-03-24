using UnityEngine;

public class Soai : Projectile
{
    private enum SoaiType
    {
        Bullet,
        Score
    }
    [SerializeField] private SoaiType _type;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (_type == SoaiType.Bullet)
                GameManager.Instance.Player.AddBullets();
            else
                GameManager.Instance.AddScore(_value);
            Destroy(gameObject);
            
            AudioManager.Instance.Play(Audio.AudioClipsNames.Score);

        }
    }
}
