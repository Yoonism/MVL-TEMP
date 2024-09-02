using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TEST_SCENE_MANAGER : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(ChangeScene(1));
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(ChangeScene(2));
        }
    }

    private IEnumerator ChangeScene(int sceneIndex)
    {
        float loadTime = 0f;
        AsyncOperation sceneLoader = SceneManager.LoadSceneAsync(sceneIndex);

        while (!sceneLoader.isDone)
        {
            loadTime += Time.deltaTime;
            yield return null;
        }

        Debug.Log("Scene loaded in // " + loadTime + "s");
    }
}
