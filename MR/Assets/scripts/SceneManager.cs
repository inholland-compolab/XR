using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneObjectManager4 : MonoBehaviour
{
    [System.Serializable]
    public class SceneState
    {
        public string sceneName;
        public List<bool> objectVisibility = new List<bool>();
    }

    public List<GameObject> allObjects = new List<GameObject>();
    public List<SceneState> sceneStates = new List<SceneState>();

    private void Awake()
    {
        ValidateObjectCount();
    }

    private void Start()
    {
        SwitchScene(0);
    }

    private void OnValidate()
    {
        ValidateObjectCount();
    }

    // Validate that the number of objects matches the number of visibility states
    private void ValidateObjectCount()
    {
        foreach (SceneState sceneState in sceneStates)
        {
            if (sceneState.objectVisibility.Count != allObjects.Count)
            {
                Debug.LogError("Object count mismatch in scene: " + sceneState.sceneName);
                return;
            }
        }
    }

    public void SwitchScene(int sceneIdx)
    {
        if (sceneIdx >= 0 && sceneIdx < sceneStates.Count)
        {
            SwitchScene(sceneStates[sceneIdx]);
        }
        else
        {
            Debug.LogWarning("Invalid scene index while SwitchScene!");
        }
    }

    public void SwitchScene(string sceneName)
    {
        SceneState foundScene = sceneStates.Find(scene => scene.sceneName == sceneName);
        if (foundScene != null)
        {
            SwitchScene(foundScene);
        }
        else
        {
            Debug.LogWarning("Scene name not found while SwitchScene!");
        }
    }

    public void switchSceneSwitchOnDelay(string sceneName)
    {
        float delay = 4f;
        int repeatCount = 4; // Change this value to the desired repeat count
        float repeatDelay = 1.5f; // Change this value to the desired delay between repeats

        string delayedSceneName = PlayerPrefs.GetString("DelayedSceneName");

        if (string.IsNullOrEmpty(delayedSceneName))
        {
            StartCoroutine(RepeatRevokeWithDelay(delay, repeatCount, repeatDelay, sceneName));
            // Save the sceneName for the delayed switch
            PlayerPrefs.SetString("DelayedSceneName", sceneName);
        }
        else
        {
            Debug.LogWarning("Delayed scene switch already scheduled. Ignoring new request.");

            StopAllCoroutines();
            StartCoroutine(RepeatRevokeWithDelay(delay, repeatCount, repeatDelay, sceneName));
            PlayerPrefs.SetString("DelayedSceneName", sceneName);
        }
    }

    private IEnumerator RepeatRevokeWithDelay(float delay, int repeatCount, float repeatDelay, string sceneName)
    {
        for (int i = 0; i < repeatCount; i++)
        {
            yield return new WaitForSeconds(delay + i * repeatDelay);
            StartCoroutine(SwitchSceneWithDelay(delay, sceneName));
        }
    }

    private IEnumerator SwitchSceneWithDelay(float delay, string sceneName)
    {
        yield return new WaitForSeconds(delay);

        // Check if the sceneName matches the PlayerPrefs stored sceneName before switching
        string delayedSceneName = PlayerPrefs.GetString("DelayedSceneName");

        if (sceneName == delayedSceneName)
        {
            SwitchScene(sceneName);

            // Clear PlayerPrefs after switching
            PlayerPrefs.DeleteKey("DelayedSceneName");
        }
    }

    private void SwitchScene(SceneState sceneState)
    {
        for (int i = 0; i < allObjects.Count; i++)
        {
            allObjects[i].SetActive(sceneState.objectVisibility[i]);
        }
    }
}
