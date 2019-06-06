using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CsItemManager : MonoBehaviour
{
    GameObject[] itemPosition;

    public GameObject drugItem;

    

    //public GameObject[] keyItem;

    int max;

    int[] arrRandPosition; // 아이템을 배치할 랜덤의 수

    List<int> arrRand = new List<int>();


    int itemMax = 5;

    // Start is called before the first frame update
    void Start()
    {
       itemPosition = GameObject.FindGameObjectsWithTag("ItemPosition");

        max = itemPosition.Length;

        
        arrRandPosition = new int[itemMax];

        setItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setItems()
    {
        for (int i = 0; i < itemMax; i++)
        {
            arrRandPosition[i] = Random.Range(0, max);
        }
        for (int i = 0; i < itemMax; i++)
        {
            arrRand.Add(Random.Range(0, max));
        }
     

        arrRand.Sort();


        Debug.Log(arrRand.Count);


        for (int i = 0; i < itemPosition.Length; i++)
        {
            if(arrRand.Count != 0)
            {
                if (i == arrRand[0])
                {

                    GameObject drug = Instantiate(drugItem, itemPosition[i].transform.position, Quaternion.identity);

                    drug.transform.localRotation = drugItem.transform.localRotation;

                    drug.transform.parent = itemPosition[i].transform.parent;

                    arrRand.RemoveAt(0);

                }
            }
            

            Destroy(itemPosition[i]);
            
        }


    }
}
