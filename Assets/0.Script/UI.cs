using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : Singleton<UI>
{
    [SerializeField] private TMP_Text goldTxt;
    [SerializeField] private TMP_Text lifeTxt;
    [SerializeField] private TMP_Text buyTxt;
    [SerializeField] private TMP_Text stageTxt;
    [SerializeField] private TMP_Text timer;
    [SerializeField] private Image timeImage;
    [SerializeField] private Image Image;


    float setTime = 3f;
    float fillTime = 1f;
    public bool isStart = false;


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
        Gold = 50;
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
            timeImage.gameObject.SetActive(true);
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
            }
        }  
        else
        {
            setTime = 3f;
        }
    }
}
