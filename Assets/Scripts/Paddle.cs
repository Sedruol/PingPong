using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    [SerializeField] private bool isPaddle1;
    private float yBound = 3.75f;
    private float movement;
    private Vector2 paddlePosition;
    public float GetSpeed() { return speed; }
    public void SetSpeed(float s) { speed = s; }
    // Update is called once per frame
    void Update()
    {
        //float movement = Input.GetAxisRaw("Vertical");
        movement = isPaddle1 ? Input.GetAxisRaw("Vertical") : Input.GetAxisRaw("Vertical2");
        //transform.position += new Vector3(0, movement * speed * Time.deltaTime, 0);
        paddlePosition = transform.position;
        paddlePosition.y = Mathf.Clamp(paddlePosition.y + movement * speed * Time.deltaTime, -yBound, yBound);
        transform.position = paddlePosition;
    }
}