using UnityEngine;

public class DestroyObstacles : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }
}