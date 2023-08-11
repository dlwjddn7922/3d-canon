using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonData : Singleton<JsonData>
{
    [SerializeField] private TextAsset cannonJsonTxt;
    [SerializeField] private TextAsset enemyJsonTxt;
    [SerializeField] private TextAsset stageJsonTxt;

    #region Cannon Data
    [System.Serializable]
    public class CannonMainData
    {
        public string name;
        public float attdistance;
        public float attdelay;
        public int power;
        public int price;
    }
    [System.Serializable]
    public class CannonData
    {
        public List<CannonMainData> cannon = new List<CannonMainData>();
    }

    public CannonData cannonData = new CannonData();
    #endregion
  
    #region Enemy Data
    [System.Serializable]
    public class EnemyMainData
    {
        public string name;
        public int gold;
        public int hp;
        public float speed;
    }
    [System.Serializable]
    public class EnemyData
    {
        public List<EnemyMainData> enemy = new List<EnemyMainData>();
    }

    public EnemyData enemyData = new EnemyData();
    #endregion
    
    #region Stage Data
    [System.Serializable]
    public class StageMainData
    {
        public int min;
        public int max;
        public int count;
    }
    [System.Serializable]
    public class StageData
    {
        public List<StageMainData> stage = new List<StageMainData>();
    }

    public StageData stageData = new StageData();
    #endregion
    // Start is called before the first frame update
    private void Awake()
    {
        cannonData = JsonUtility.FromJson<CannonData>(cannonJsonTxt.ToString());
        enemyData = JsonUtility.FromJson<EnemyData>(enemyJsonTxt.ToString());
        stageData = JsonUtility.FromJson<StageData>(stageJsonTxt.ToString());
    }
}
