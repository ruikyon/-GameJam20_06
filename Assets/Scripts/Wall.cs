using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Wall : MonoBehaviour
{
    public static bool gameOver;

    private int count;
    private int hp;
    [SerializeField] private int maxHp;
    [SerializeField] private TextMeshProUGUI countText, timeText;
    [SerializeField] private Slider hpBar;
    [SerializeField] private GameObject caution;
    [SerializeField] private Result result;
    private static Wall instance;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        gameOver = false;
        instance = this;
        count = 0;
        hp = maxHp;
    }

    private void Update()
    {
        if (!gameOver)
        {
            countText.text = count.ToString();
            timeText.text = GetTime((int)(Time.time - startTime));
            hpBar.value = (float)hp / maxHp;

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if((Time.time - startTime) > 5 && !gameOver && count < 3) 
        {
            hp--;
            caution.SetActive(true);
            if (hp <= 0) 
            {
                gameOver = true;
                var grade = (Time.time - startTime) < 30 ? 2 : ((Time.time - startTime) < 60 ? 1 : 0);
                result.ShowResult(GetTime((int)(Time.time - startTime)), grade);
            }
        }
        else 
        {
            caution.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy") 
        {
            count++;
        }    
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            count--;
        }
    }

    private string GetTime(int time)
    {
        return string.Format("{0:00}", time / 60) + ":" + string.Format("{0:00}", time % 60);
    }

    public static void DecCount() 
    {
        instance.count--;
    }
}
