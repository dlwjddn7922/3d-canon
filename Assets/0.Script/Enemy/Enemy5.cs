using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5 : Enemy
{
    void Start()
    {
        data = JsonData.Instance.enemyData.enemy[5];
        Init();
    }

}
