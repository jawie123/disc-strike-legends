using UnityEngine;

public class CarromPuck : MonoBehaviour
{
    public enum PuckType { White, Red, Black }
    [Header("Puck Configuration")]
    public PuckType type = PuckType.White;
    public int pointValue = 10;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Pocket check
        if (other.CompareTag("Pocket"))
        {
            // Score update trigger
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddScore(pointValue, type);
            }

            // Puck disable/hide
            gameObject.SetActive(false);
        }
    }
}
