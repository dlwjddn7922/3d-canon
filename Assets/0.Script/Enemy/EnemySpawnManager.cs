using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private Enemy[] enemies;
    [SerializeField] private BoxCollider boxColl;

    float spawnTimer = 0;
    float spawnCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer > 0.2f && spawnCount < 20)
        {
            spawnTimer = 0;
            int rand = Random.Range(0, enemies.Length);
            Instantiate(enemies[rand], RandomPosition(),Quaternion.identity);
            spawnCount++;
        }
    }
    Vector3 RandomPosition()
    {
        Vector3 posVec = boxColl.transform.position;

        float rangeX = boxColl.bounds.size.x;
        float rangeY = boxColl.bounds.size.y;

        rangeX = Random.Range((rangeX / 2) * -1, rangeX / 2);
        rangeY = Random.Range((rangeY / 2) * -1, rangeY / 2);

        return posVec + new Vector3(rangeX, 0f,rangeY);
    }
}
