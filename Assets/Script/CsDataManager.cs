using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CsDataManager : MonoBehaviour
{
    public static CsDataManager instance = null;

    public bool isDie = false;

    // Start is called before the first frame update

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        isDie = false;
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "GameOverScene")
        {
            isDie = true; 
        }
        if (SceneManager.GetActiveScene().name == "GameEndingScene")
        {
            isDie = false;
        }
    }
}
