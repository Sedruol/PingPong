using UnityEngine;
using TMPro;
public class Manager : MonoBehaviour
{
    [SerializeField] private TMP_Text TMPScore1;
    [SerializeField] private TMP_Text TMPScore2;
    [SerializeField] private Transform paddle1;
    [SerializeField] private Transform paddle2;
    [SerializeField] private Transform ball;
    private int score1 = 0;
    private int score2 = 0;
    private static Manager instance;
    public static Manager Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<Manager>();
            return instance;
        }
    }
    public void PaddleScore1()
    {
        score1++;
        TMPScore1.text = score1.ToString();
    }
    public void PaddleScore2()
    {
        score2++;
        TMPScore2.text = score2.ToString();
    }
    public void Restart()
    {
        paddle1.position = new Vector2(paddle1.position.x, 0);
        paddle2.position = new Vector2(paddle2.position.x, 0);
        ball.position = new Vector2(0, 0);
        paddle1.GetComponent<Paddle>().SetSpeed(7f);
        paddle2.GetComponent<Paddle>().SetSpeed(7f);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}