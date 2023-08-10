using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonSpawn : MonoBehaviour
{
    [SerializeField] private Cannon[] cannons;
    [SerializeField] private CannonBlock[] cannonBlocks;

    const int Y = 2;
    const int X = 6;
    bool[,] blocks = new bool[Y, X];
    //Å×½ºÆ®
    int spawnCount = 1;
    int addValue = 10;
    private void Start()
    {
        UI.Instance.BuyPrice = spawnCount * addValue;
    }
    public void OnCreatCannon()
    {
        
        if(true)
        {
            for (int i = 0; i < cannonBlocks.Length; i++)
            {
                if(cannonBlocks[i].cannon == null)
                {
                    if (UI.Instance.Gold >= spawnCount * addValue)
                    {
                        int rand = Random.Range(0, cannons.Length);
                        Vector3 createPos = cannonBlocks[i].transform.position;
                        cannonBlocks[i].cannon = Instantiate(cannons[rand], createPos, Quaternion.identity);

                        UI.Instance.Gold -= spawnCount * addValue;
                        spawnCount++;
                        UI.Instance.BuyPrice = spawnCount * addValue;
                        break;

                    }  
                }
            }      
        }
    }
}
