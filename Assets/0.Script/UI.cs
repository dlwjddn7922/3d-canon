using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UI : Singleton<UI>
{
    [SerializeField] private TMP_Text goldTxt;
    [SerializeField] private TMP_Text lifeTxt;
    [SerializeField] private TMP_Text buyTxt;
    [SerializeField] private TMP_Text stageTxt;
    [SerializeField] private TMP_Text timer;
    [SerializeField] private TMP_Text speedTxt;
    [SerializeField] private Image timeImage;
    [SerializeField] private Image Image;
    [SerializeField] private Image pauseImage;


    float setTime = 3f;
    float fillTime = 1f;
    public bool isStart = false;
    public bool isPause = false;


    private int gold;
    public int Gold
    {
        get
        {
            return gold;
        }
        set
        {
            gold = value;
            goldTxt.text = $"Gold : {gold}";
        }
    }
    private int life;
    public int Life
    {
        get
        {
            return life;
        }
        set
        {
            life = value;
            lifeTxt.text = $"Life : {life}";
        }
    }
    private int buyPrice;
    public int BuyPrice
    {
        get
        {
            return buyPrice;
        }
        set
        {
            buyPrice = value;
            buyTxt.text = $"{buyPrice}";
        }
    }
    private int stage;
    public int Stage 
    {
        get
        {
            return stage;
        }
        set
        {
            stage = value;
            stageTxt.text = $"Stage : {stage}";
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Stage = 1;
        Life = 20;
        Gold = 200;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Timer()
    {
        if(isStart == true)
        {
            Image.gameObject.SetActive(true);
            //timeImage.gameObject.SetActive(true);
            float value = setTime - (fillTime * Time.deltaTime);
            timeImage.fillAmount -= (setTime - value) / 3;
            setTime -= Time.deltaTime;
            if (setTime > 0)
            {
                timer.text = setTime.ToString("0");
            }
            else if (setTime == 0)
            {
                timer.text = "Start";
            }
            else
            {
                Image.gameObject.SetActive(false);
                isStart = false;
                timeImage.fillAmount = 1;
            }
        }  
        else
        {
            setTime = 3f;
        }
    }
    public void OnPause()
    {
        isPause = true;
        if(isPause == true)
        {
            Time.timeScale = 0;
            pauseImage.gameObject.SetActive(true);
            return;
        }   
    }
    public void OnStart()
    {
        isPause = false;
        if(isPause == false)
        {
            Time.timeScale = 1;
            pauseImage.gameObject.SetActive(false);
            return;
        }
    }
    public void OnRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnUpSpeed()
    {
        Time.timeScale = 2;
        speedTxt.text = "2X";
        return;
    }
    public void OnDownSpeed()
    {
        Time.timeScale = 1;
        speedTxt.text = "1X";
        return;
    }
}
