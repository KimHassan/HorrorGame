using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CsStageClear : MonoBehaviour
{
    public GameObject Bokdo;

    public Image blackAlpha;

    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine("GoEnding");
        }
    }

    IEnumerator GoEnding()
    {
        Bokdo.SetActive(false);

        Player.transform.rotation.SetEulerRotation(0, 270, 0);
      
            while (blackAlpha.color.a < 1)
            {
                Color c = blackAlpha.color;
                c.a += 0.005f;
            blackAlpha.color = c;
                yield return null;
            }

            SceneManager.LoadScene("GameEndingScene");

    }
}
