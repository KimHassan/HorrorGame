using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CsUIControll : MonoBehaviour
{
    public GameObject playerText;

    Text ActiveText;

    [HideInInspector]public Text ItemText;

    public CsGameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        ItemText = GameObject.Find("ItemText").GetComponent<Text>();

        ActiveText = playerText.GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        playerText.SetActive(false);

    }

    public void TextUp(bool _isOver = false, string _string = "")
    {
        playerText.SetActive(_isOver);

        Debug.Log(_isOver);

        ActiveText.text = _string;
    }

    
}
