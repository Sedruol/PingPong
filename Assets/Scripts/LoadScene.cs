using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private Image courtine;
    [SerializeField] private float speed;
    private float radiousColor = 1;
    private Canvas canvas;
    private static LoadScene instance;
    public static LoadScene Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<LoadScene>();
            return instance;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        courtine.material.SetFloat("_Cutoff", radiousColor);
        StartCoroutine(Initialize());
    }
    IEnumerator Initialize()
    {
        while (courtine.material.GetFloat("_Cutoff") > 0)
        {
            radiousColor -= Time.deltaTime * speed;
            courtine.material.SetFloat("_Cutoff", radiousColor);
            yield return null;
        }
        courtine.material.SetFloat("_Cutoff", 0);
        canvas.gameObject.SetActive(false);
    }
    public IEnumerator ChangeScene()
    {
        while (courtine.material.GetFloat("_Cutoff") < 1)
        {
            radiousColor += Time.deltaTime * speed;
            courtine.material.SetFloat("_Cutoff", radiousColor);
            yield return null;
        }
        courtine.material.SetFloat("_Cutoff", 1);
    }
}