using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
{
    void Start()
    {
        data = JsonData.Instance.enemyData.enemy[1];
        Init();
    }

}
