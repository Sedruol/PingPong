using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    [SerializeField] private bool isPaddle1;
    [SerializeField] private GameObject ball;
    private float yBound = 3.75f;
    private float movement;
    private Vector2 paddlePosition;
    private Vector2 ballPosition;
    public float GetSpeed() { return speed; }
    public void SetSpeed(float s) { speed = s; }
    private void IA()
    {
        ballPosition = ball.transform.position;
        transform.position += transform.position.y > ballPosition.y ? new Vector3(0, -speed * Time.deltaTime) : new Vector3(0, speed * Time.deltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        //float movement = Input.GetAxisRaw("Vertical");
        //movement = isPaddle1 ? Input.GetAxisRaw("Vertical2") : Input.GetAxisRaw("Vertical");
        if (PlayerPrefs.GetInt("BtnGameplaySelected", 0) == 0)
        {
            if (isPaddle1) movement = Input.GetAxisRaw("Vertical2");
            else IA();
        }
        else if (PlayerPrefs.GetInt("BtnGameplaySelected", 0) == 1)
            movement = isPaddle1 ? Input.GetAxisRaw("Vertical2") : Input.GetAxisRaw("Vertical");
        //transform.position += new Vector3(0, movement * speed * Time.deltaTime, 0);
        paddlePosition = transform.position;
        paddlePosition.y = Mathf.Clamp(paddlePosition.y + movement * speed * Time.deltaTime, -yBound, yBound);
        transform.position = paddlePosition;
    }
}