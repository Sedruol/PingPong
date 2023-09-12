using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private Button btnPlay;
    [SerializeField] private List<Button> ListBtnMaxScore = new List<Button>();
    [SerializeField] private List<Button> ListBtnGameplay = new List<Button>();
    [SerializeField] private Color selectedColor;
    [SerializeField] private Canvas canvas;
    private int[] maxValues = { 3, 5, 7, 10, 12, 15, 17, 20 };
    private int maxPosSelected = 0;
    private int maxValueSelected = 0;
    private int gameplaySelected = 0;
    private IEnumerator SceneLoad()
    {
        canvas.gameObject.SetActive(true);
        StartCoroutine(LoadScene.Instance.ChangeScene());
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    // Start is called before the first frame update
    void Start()
    {
        maxPosSelected = PlayerPrefs.GetInt("BtnMaxScoreSelected", 0);
        maxValueSelected = PlayerPrefs.GetInt("BtnMaxValueSelected", 3);
        gameplaySelected = PlayerPrefs.GetInt("BtnGameplaySelected", 0);
        btnPlay.onClick.AddListener(() => StartGame());
        for (int i = 0; i < ListBtnMaxScore.Count; i++)
        {
            int iCopy = i;
            ListBtnMaxScore[i].image.color = i == maxPosSelected ? selectedColor : Color.white;
            ListBtnMaxScore[i].onClick.AddListener(() => ChangeBtnMaxScore(iCopy, maxValues[iCopy]));
        }
        for (int j = 0; j < ListBtnGameplay.Count; j++)
        {
            int jCopy = j;
            ListBtnGameplay[j].image.color = j == gameplaySelected ? selectedColor : Color.white;
            ListBtnGameplay[j].onClick.AddListener(() => ChangeBtnGameplay(jCopy));
        }
    }
    private void ChangeBtnGameplay(int pos)
    {
        if (pos != gameplaySelected)
        {
            ListBtnGameplay[gameplaySelected].image.color = Color.white;
            ListBtnGameplay[pos].image.color = selectedColor;
            gameplaySelected = pos;
        }
    }
    private void ChangeBtnMaxScore(int pos, int value)
    {
        if (pos != maxPosSelected)
        {
            ListBtnMaxScore[maxPosSelected].image.color = Color.white;
            ListBtnMaxScore[pos].image.color = selectedColor;
            maxPosSelected = pos;
            maxValueSelected = value;
        }
    }
    private void StartGame()
    {
        PlayerPrefs.SetInt("BtnMaxScoreSelected", maxPosSelected);
        PlayerPrefs.SetInt("BtnMaxValueSelected", maxValueSelected);
        PlayerPrefs.SetInt("BtnGameplaySelected", gameplaySelected);
        StartCoroutine(SceneLoad());
    }
}