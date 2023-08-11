using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : Enemy
{
    void Start()
    {
        data = JsonData.Instance.enemyData.enemy[3];
        Init();
    }

}
