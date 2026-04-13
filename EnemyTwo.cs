using UnityEngine;

public class EnemyTwo : MonoBehaviour
{
    [SerializeField] private float _verticalSpeed = 2.5f;
    [SerializeField] private float _frequency = 3f;   // Speed of the sway
    [SerializeField] private float _magnitude = 4f;   // Width of the sway

    private float _spawnX; // Store the starting X position

    void Start()
    {
        // Remember where we started so we sway relative to the spawn point
        _spawnX = transform.position.x;
    }

    void Update()
    {
        // 1. Calculate the new X position based on a Sine wave
        float xOffset = Mathf.Sin(Time.time * _frequency) * _magnitude;
        float newX = _spawnX + xOffset;

        // 2. Keep the enemy within screen bounds (-9 to 9)
        newX = Mathf.Clamp(newX, -9f, 9f);

        // 3. Calculate the new Y position (moving down)
        float newY = transform.position.y - (_verticalSpeed * Time.deltaTime);

        // 4. Apply the position directly
        transform.position = new Vector3(newX, newY, 0);

        // Destroy if it goes off screen bottom
        if (transform.position.y < -6.5f)
        {
            Destroy(this.gameObject);
        }
    }
}