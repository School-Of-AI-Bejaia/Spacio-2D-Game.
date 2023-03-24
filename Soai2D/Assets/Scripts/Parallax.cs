using UnityEngine;

public class Parallax : MonoBehaviour
{
    [Range(0, 1)][SerializeField]private float parallaxEffect;    // 0: default (fixed pos) -   1: follows the camera
    private const float StartX = 47;
    private const float EndX = -41;
    private void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x - parallaxEffect * Time.fixedDeltaTime * 10, transform.position.y);

        if (transform.position.x <= EndX)
        {
            transform.position = new Vector2(StartX, transform.position.y);
        }
        
        
    }
}
