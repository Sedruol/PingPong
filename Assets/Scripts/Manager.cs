using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class Manager : MonoBehaviour
{
    [SerializeField] private TMP_Text TMPScore1;
    [SerializeField] private TMP_Text TMPScore2;
    [SerializeField] private Transform paddle1;
    [SerializeField] private Transform paddle2;
    [SerializeField] private Transform ball;
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private TMP_Text TMP_Winner;
    [SerializeField] private Button btnReload;
    [SerializeField] private Button btnHome;
    [SerializeField] private Button btnExit;
    private int score1 = 0;
    private int score2 = 0;
    private int currentScene = 0;
    private static Manager instance;
    public static Manager Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<Manager>();
            return instance;
        }
    }
    public void ActivateResultPanel(int p)
    {
        resultPanel.SetActive(true);
        if (PlayerPrefs.GetInt("BtnGameplaySelected", 0) == 0)
        {
            if (p == 1) TMP_Winner.text = "Player " + p.ToString() + " win";
            else if (p == 2) TMP_Winner.text = "IA win";
        }
        else if (PlayerPrefs.GetInt("BtnGameplaySelected", 0) == 1) TMP_Winner.text = "Player " + p.ToString() + " win";
    }
    private IEnumerator SceneLoad(int n)
    {
        //transitionAnimator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(currentScene + n);
    }
    public void Reload()
    {
        Time.timeScale = 1f;
        StartCoroutine(SceneLoad(0));
    }
    public void GoHome()
    {
        Time.timeScale = 1f;
        StartCoroutine(SceneLoad(-1));
    }
    public void Exit()
    {
        Application.Quit();
    }
    private void PaddleWin(int score, int player)
    {
        if (score == PlayerPrefs.GetInt("BtnMaxValueSelected", 0))
        {
            Time.timeScale = 0f;
            ActivateResultPanel(player);
            //Debug.Log("el ganador es el jugador " + player);
        }
        Restart();
    }
    public void PaddleScore1()
    {
        score1++;
        TMPScore1.text = score1.ToString();
        PaddleWin(score1, 1);
    }
    public void PaddleScore2()
    {
        score2++;
        TMPScore2.text = score2.ToString();
        PaddleWin(score2, 2);
    }
    public void Restart()
    {
        paddle1.position = new Vector2(paddle1.position.x, 0);
        paddle2.position = new Vector2(paddle2.position.x, 0);
        ball.position = new Vector2(0, 0);
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        paddle1.GetComponent<Paddle>().SetSpeed(7f);
        paddle2.GetComponent<Paddle>().SetSpeed(7f);
    }
    // Start is called before the first frame update
    void Start()
    {
        resultPanel.SetActive(false);
        currentScene = SceneManager.GetActiveScene().buildIndex;
        btnReload.onClick.AddListener(() => Reload());
        btnHome.onClick.AddListener(() => GoHome());
        btnExit.onClick.AddListener(() => Exit());
    }
}