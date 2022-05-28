using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [Header("Остальные объекты")]
    [SerializeField] private Image loadingImage;
    [SerializeField] private Text progressText;
    [SerializeField] private GameObject main;
    public static int NumberCurrentScene { get; private set; }
    private void Awake()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
            StartCoroutine(AsyncLoad(1));

        NumberCurrentScene = SceneManager.GetActiveScene().buildIndex;
        EventManager.LoadGameSceneEvent += LoadChosenScene;
    }
    public void LoadChosenScene(int idFloor)
    {
        main.SetActive(true);
        StartCoroutine(AsyncLoad(idFloor));
    }
    private IEnumerator AsyncLoad(int idFloor)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(idFloor);
        while (!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            loadingImage.fillAmount = progress;
            progressText.text = string.Format("{0:0}%", progress * 100);
            yield return null;        
        }
    }
    private void OnDestroy()
    {
        EventManager.LoadGameSceneEvent -= LoadChosenScene;
    }
}
