using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : Singleton<EnemySpawnManager>
{
    [SerializeField] private Transform finish;
    [SerializeField] private Enemy[] enemies;
    [SerializeField] private BoxCollider boxColl;

    public int SpawnCount { get; set; }
    public int CatchCount { get; set; }
    float spawnTimer = float.MaxValue;
    float spawnCount = 0;
    float spawnTime = 3f;
    int nextDelayTime = 5;
    // Start is called before the first frame update
    void Start()
    {
        UI.Instance.isStart = true;
    }

    // Update is called once per frame
    void Update()
    {

        spawnTimer += Time.deltaTime;
        spawnTime -= Time.deltaTime;
        UI.Instance.Timer();
        if (spawnTime <= 0)
        {
            if (spawnTimer > 2.5f && SpawnCount < JsonData.Instance.stageData.stage[UI.Instance.Stage - 1].count)
            {
                int stage = UI.Instance.Stage;
                JsonData.StageMainData data = JsonData.Instance.stageData.stage[stage - 1];
                if (CatchCount == 0)
                {
                    CatchCount = data.count;
                }
                spawnTimer = 0;
                int rand = Random.Range(data.min, data.max + 1);
                Enemy e = Instantiate(enemies[rand], RandomPosition(), Quaternion.identity);
                e.SetTarget(finish);
                SpawnCount++;
            }
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
    public void ReSpawn()
    {
        UI.Instance.isStart = true;
        UI.Instance.Timer();
        SpawnCount = 0;
        CatchCount = 0;
        spawnTime = 3f;
        UI.Instance.Stage++;
    }
}
