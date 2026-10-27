using UnityEngine;

public class CarromStriker : MonoBehaviour
{
    [Header("Physics Controls")]
    public float maxPower = 15f;
    public float powerMultiplier = 3f;
    private Rigidbody2D rb;
    private Vector2 startPos;
    private Vector2 currentPos;
    private bool isDragging = false;

    [Header("Visual Guidelines")]
    public LineRenderer aimLine;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        if (aimLine != null) aimLine.enabled = false;
    }

    void OnMouseDown()
    {
        if (rb.velocity.magnitude < 0.1f)
        {
            isDragging = true;
            if (aimLine != null) aimLine.enabled = true;
        }
    }

    void OnMouseDrag()
    {
        if (!isDragging) return;

        currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dragVector = startPos - currentPos;

        if (aimLine != null)
        {
            aimLine.SetPosition(0, transform.position);
            aimLine.SetPosition(1, (Vector2)transform.position + Vector2.ClampMagnitude(dragVector, 3f));
        }
    }

    void OnMouseUp()
    {
        if (!isDragging) return;
        isDragging = false;
        if (aimLine != null) aimLine.enabled = false;

        Vector2 forceVector = Vector2.ClampMagnitude(startPos - currentPos, 3f) * powerMultiplier;
        rb.AddForce(forceVector, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pocket"))
        {
            rb.velocity = Vector2.zero;
            transform.position = new Vector3(0, -2.5f, 0);
        }
    }
}
