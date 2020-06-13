using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Result : MonoBehaviour
{
    private readonly string[] comment =
    {
        "Great!",
        "Good",
        "Soso",
    };

    private readonly Color[] color = {
        Color.green,
        Color.yellow,
        Color.blue,
    };

    [SerializeField] private TextMeshProUGUI timeText, gradeText;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Start");
        }   
    }

    public void ShowResult(string time, int grade) 
    {
        timeText.text = time;
        gradeText.text = comment[grade];
        gradeText.color = color[grade];
        gameObject.SetActive(true);
    }
}
