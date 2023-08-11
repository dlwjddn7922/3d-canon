using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy
{
    void Start()
    {
        data = JsonData.Instance.enemyData.enemy[2];
        Init();
    }

}
