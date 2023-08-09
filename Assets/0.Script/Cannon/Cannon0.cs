using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon0 : Cannon
{
    // Start is called before the first frame update
    void Start()
    {
        
        data = JsonData.Instance.cannonData.cannon[0];
        AttDistance = data.attdistance;
        AttDelay = data.attdelay;
        //AttPower = data.power;
    }

    // Update is called once per frame

}
