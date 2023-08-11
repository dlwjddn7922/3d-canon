using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : Enemy
{
    void Start()
    {
        data = JsonData.Instance.enemyData.enemy[4];
        Init();
    }

}
