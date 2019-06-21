using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CsUIControll : MonoBehaviour
{
    public static CsUIControll instance;
    
    public GameObject mainCursor;

    public GameObject handCursor;

    public GameObject MessagePrefab;

     Text textMessage;

    bool isTextUp;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        textMessage = MessagePrefab.GetComponent<Text>();

        Color c = textMessage.color;

        c.a = 0;

        textMessage.color = c;

        isTextUp = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mainCursor.SetActive(true);

        handCursor.SetActive(false);

        
        if(Input.GetKeyDown(KeyCode.R))
        {
            if (isTextUp)
                return;

            StartCoroutine("TextUpMessage");
        }
    }

    public void RayCast()
    {
        mainCursor.SetActive(false);

        handCursor.SetActive(true);
    }

    IEnumerator TextUpMessage()
    {
        Color c = textMessage.color;

        c.a = 0;

        bool isReturn = false;

        float speed = 1f;

        isTextUp = true;

        while (isTextUp)
        {
            if(isReturn == false)
            {
                c.a += speed * Time.deltaTime;

                if (c.a >= 1)
                {
                    isReturn = true;

                    yield return new WaitForSeconds(1.0f);
                }

            }
            else
            {
                c.a -= speed * Time.deltaTime;

                    if(c.a <= 0)
                    {

                        isTextUp = false;

                    }
            }

            textMessage.color = c;

            yield return null;
        }

    }

    public void ChangeText(string _textString)
    {
        if (isTextUp)
            return;

        textMessage.text = _textString;

        StartCoroutine("TextUpMessage");

    }
}
