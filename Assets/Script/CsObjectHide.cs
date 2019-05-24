using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsObjectHide : MonoBehaviour
{
    // tag를 hideojbect로 변경
    // 스크립트 추가
    // hidePosition 프리펩을 자식으로 넣기
    public int id;

    GameObject player;

    GameObject tempObject;

    GameObject pastPlayerPosition;
    // Start is called before the first frame update
    void Start()
    {
        
       tempObject =  gameObject.transform.Find("HidePosition").gameObject;
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Active(GameObject _player)
    {
        pastPlayerPosition = _player;

        _player.transform.position = tempObject.transform.position;

        _player.transform.rotation = tempObject.transform.rotation;
    }
}
