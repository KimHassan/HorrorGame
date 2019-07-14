using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CsCreditScene : MonoBehaviour
{

    public GameObject Credit;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("UpCredit");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GoTitle();
        }


    }

    void GoTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }

    IEnumerator UpCredit()
    {
        while(Credit.transform.position.y < 1800)
        {
            Credit.transform.position += new Vector3(0, 2, 0);
            yield return null;
        }

        GoTitle();
    }
}
