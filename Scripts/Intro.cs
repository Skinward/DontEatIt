using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    private Animator anim;
    
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.999f && !anim.IsInTransition(0))
        {
            Debug.Log("anim update if");
            return;
        }
        else
        {
            Debug.Log("anim else");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
