using UnityEngine;

public class Asteriod : Projectile
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            GameManager.Instance.Player.ReceiveDamage();
            
            AudioManager.Instance.Play(Audio.AudioClipsNames.Asteroid);
            GetComponent<Animator>().Play("asteroid_destroy");
        }
        else if (col.transform.CompareTag("Bullet"))
        {
            Destroy(col.gameObject);
            GameManager.Instance.AddScore(_value);
            
            AudioManager.Instance.Play(Audio.AudioClipsNames.Asteroid);
            GetComponent<Animator>().Play("asteroid_destroy");
        }
    }
    
    private void DestroyAsteroid()
    {
        Destroy(gameObject);
    }
}
