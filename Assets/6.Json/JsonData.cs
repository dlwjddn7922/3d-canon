using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonData : MonoBehaviour
{
    public static JsonData Instance;
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
    [SerializeField] private TextAsset cannonJsonTxt;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;

        cannonData = JsonUtility.FromJson<CannonData>(cannonJsonTxt.ToString());
    }
}
