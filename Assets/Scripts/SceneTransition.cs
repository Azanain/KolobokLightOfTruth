using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [Header("����������� �����")]
    public int sceneID;
    [Header("��������� �������")]
    [SerializeField] private Image loadingImage;
    [SerializeField] private Text progressText;

    private void Start()
    {
        StartCoroutine(AsyncLoad());
    }
    public void LoadChosenScene()
    {
        StartCoroutine(AsyncLoad());
    }
    private IEnumerator AsyncLoad()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);
        while (!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            loadingImage.fillAmount = progress;
            progressText.text = string.Format("{0:0}%", progress * 100);
            yield return null;        
        }
    }
}
