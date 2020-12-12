using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Notice : MonoBehaviour
{
    public float waitTime;
    void Start()
    {
        StartCoroutine(ShowNotice());
    }

    IEnumerator ShowNotice()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
