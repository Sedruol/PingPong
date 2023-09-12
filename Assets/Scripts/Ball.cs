using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private float velocity = 4f;
    [SerializeField] private float velocityMultiplier = 1.1f;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(ReLaunch());
    }

    private void Launch()
    {
        sr.enabled = true;
        float xVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        float yVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        rb.velocity = new Vector2(xVelocity, yVelocity) * velocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            rb.velocity *= velocityMultiplier;
            Paddle col = collision.gameObject.GetComponent<Paddle>();
            col.SetSpeed(col.GetSpeed() * velocityMultiplier);
        }
    }
    private IEnumerator ReLaunch()
    {
        yield return new WaitForSecondsRealtime(1f);//0.75f
        if (!resultPanel.activeSelf) Launch();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal1")) Manager.Instance.PaddleScore1();
        else if (collision.gameObject.CompareTag("Goal2")) Manager.Instance.PaddleScore2();
        sr.enabled = false;
        StartCoroutine(ReLaunch());
    }
}