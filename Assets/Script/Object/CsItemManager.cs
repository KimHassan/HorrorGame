using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ItemObject : MonoBehaviour
{
    GameObject[] allPosition;

    GameObject obj;

    int allPosMax;

    int[] tempPos;

    List<int> arrPos = new List<int>();

    int max;

    public void Init(string _tagName, GameObject _obj, int _max)
    {
        Debug.Log(_tagName);

        allPosition = GameObject.FindGameObjectsWithTag(_tagName);

        allPosMax = allPosition.Length;

        max = _max;

        obj = _obj;

        for (int i=0;i<max;i++)
        {
            SetList();
        }

        arrPos.Sort();

        SetItem();

    }

    void SetList()
    {
        int temp = Random.Range(0, allPosMax);

        //while(arrPos.Contains(temp) == false)
        //{
        //    temp = Random.Range(0, allPosMax);
        //}

        arrPos.Add(temp);
    }

   public void SetItem()
    {
        
        foreach(int pos in arrPos)
        {
            GameObject temp = Instantiate(obj, allPosition[pos].transform.position, Quaternion.identity);

            temp.transform.parent = allPosition[pos].transform.parent;

            temp.transform.rotation = obj.transform.rotation;

        }
    }


}

public class CsItemManager : MonoBehaviour
{

    public GameObject drugItem; // drug의 프리펩

    public GameObject keyItem;

    ItemObject DrugItems = new ItemObject();

    ItemObject KeyItems = new ItemObject();


    // Start is called before the first frame update
    void Start()
    {
        
       KeyItems.Init("ItemPosition", keyItem, 5);

       DrugItems.Init("DrugPosition", drugItem, 5);

     


    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
