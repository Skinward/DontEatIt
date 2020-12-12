using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompanyIntro : MonoBehaviour
{
    public float companyDispTime;

    private void Update()
    {
        companyDispTime -= Time.deltaTime;

        if (companyDispTime <= 0.0f && companyDispTime >= -0.4f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}
