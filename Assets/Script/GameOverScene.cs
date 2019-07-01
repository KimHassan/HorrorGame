﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("GoTitleScene");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }

    IEnumerator GoTitleScene()
    {

        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene("TitleScene");
    }
}
