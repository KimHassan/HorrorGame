using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ItemObject : MonoBehaviour
{
    List<GameObject> allPosition = new List<GameObject>(); // 인게임에 위치한 모든 아이템의 포지션

    GameObject obj; // 배치할 아이템

    public void Init(string _tagName, GameObject _obj, int _max) // 초반 배치
    {
        
        allPosition.AddRange(GameObject.FindGameObjectsWithTag(_tagName));

        obj = _obj;

        for (int i = 0; i < _max; i++)
        {
            int temp = Random.Range(0, allPosition.Count);

            SetItem(temp);
        }

    }

   public void SetItem(int pos)
    {

        GameObject temp = Instantiate(obj, allPosition[pos].transform.position, Quaternion.identity);

        temp.transform.parent = allPosition[pos].transform.parent;


        temp.transform.rotation = allPosition[pos].transform.rotation;


        allPosition.RemoveAt(pos);

    }

    public void SetItem()
    {
        int pos = Random.Range(0, allPosition.Count);

        GameObject temp = Instantiate(obj, allPosition[pos].transform.position, Quaternion.identity);

        temp.transform.parent = allPosition[pos].transform.parent;


        temp.transform.rotation = allPosition[pos].transform.rotation;


        allPosition.RemoveAt(pos);

    }


}

public class CsItemManager : MonoBehaviour
{
    
    public GameObject drugPrefab; // drug의 프리펩

    public GameObject batteryPrefab;

    public GameObject clockPrefab;

    ItemObject DrugItems = new ItemObject();

    ItemObject BatteryItems = new ItemObject();

    ItemObject ClockItems = new ItemObject();

    // Start is called before the first frame update
    void Start()
    {
        
       BatteryItems.Init("ItemPosition", batteryPrefab, 3);

       DrugItems.Init("DrugPosition", drugPrefab, 5);

    }

    public void AddDrugItems()
    {
        DrugItems.SetItem();
    }

    public void AddBatteryItems()
    {
        BatteryItems.SetItem();
    }

    public GameObject AddDigitalClock(int time = 0)
    {
        GameObject clock = clockPrefab;

        CsDigitalClock digitalClock = clock.GetComponent<CsDigitalClock>();

        digitalClock.ClockTime = time;

        ClockItems.Init("ClockPosition", clockPrefab, 1);

        return clock;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
