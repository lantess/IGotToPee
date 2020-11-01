using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStartAnimacja : MonoBehaviour
{
    public Animator animator;
    public GameObject buttony;
    


    public void StartAnim(){
        animator.SetTrigger("StartTrigger");
        buttony.SetActive(false);
    
    }

    public void StartGame()
    {
        SceneManager.LoadScene("AdamTestScene");
    }
}
