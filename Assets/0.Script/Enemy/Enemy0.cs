using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy0 : Enemy
{
    void Start()
    {
        data = JsonData.Instance.enemyData.enemy[0];
        Init();
    }

}
