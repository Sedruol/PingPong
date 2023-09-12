using UnityEngine;
using UnityEngine.InputSystem;
public class Paddle : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    [SerializeField] private bool isPaddle1;
    [SerializeField] private GameObject ball;
    private PlayerInput playerInput;
    private float yBound = 3.75f;
    private float movement;
    private Vector2 paddlePosition;
    private Vector2 ballPosition;
    private Vector2 input;
    public float GetSpeed() { return speed; }
    public void SetSpeed(float s) { speed = s; }
    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }
    private void IA()
    {
        ballPosition = ball.transform.position;
        transform.position += transform.position.y > ballPosition.y ? new Vector3(0, -speed * Time.deltaTime) : new Vector3(0, speed * Time.deltaTime);
    }
    private void Update()
    {
        if (PlayerPrefs.GetInt("BtnGameplaySelected", 0) == 0 && !isPaddle1) IA();
        else
        {
            input = playerInput.actions["Move"].ReadValue<Vector2>();
            movement = input.y;
        }
        paddlePosition = transform.position;
        paddlePosition.y = Mathf.Clamp(paddlePosition.y + movement * speed * Time.deltaTime, -yBound, yBound);
        transform.position = paddlePosition;
    }
}