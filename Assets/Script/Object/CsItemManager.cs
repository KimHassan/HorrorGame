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
