using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScenes : MonoBehaviour
{
    private Animator animator;
    private static LoadScenes instance;
    public static void LoadScene(string nameScene)
    {
        instance.animator.SetTrigger("SceneClosing");
        SceneManager.LoadScene(nameScene);
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("Loading");
    }
}
