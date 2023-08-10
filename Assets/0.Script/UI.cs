using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : Singleton<UI>
{
    [SerializeField] private TMP_Text goldTxt;
    [SerializeField] private TMP_Text lifeTxt;
    [SerializeField] private TMP_Text buyTxt;
    [SerializeField] private TMP_Text stageTxt;


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
}
