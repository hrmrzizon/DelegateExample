namespace Example.Delegate.DefinedUsage
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class VariousSceneBehvaviour : MonoBehaviour
    {
        int prevScene = - 1;
        AsyncOperation loadOperation, unloadOperation;

        private void Awake()
        {
            SceneManager.sceneLoaded    += (scene, loadMode) =>     Debug.LogFormat("Loaded Scene : {0}, Mode : {1}", scene.name, loadMode)     ;
            SceneManager.sceneUnloaded  += (scene) =>           {   Debug.LogFormat("Unloaded Scene : {0}", scene.name);                       };
        }

        private void Update()
        {
            if (unloadOperation != null && loadOperation != null)
                if (!unloadOperation.isDone || !loadOperation.isDone)
                    return;

            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                if(prevScene >= 0)
                    unloadOperation = SceneManager.UnloadSceneAsync(prevScene);
                loadOperation = SceneManager.LoadSceneAsync(prevScene = 0, LoadSceneMode.Additive);
            }    
            else if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                if (prevScene >= 0)
                    unloadOperation = SceneManager.UnloadSceneAsync(prevScene);
                loadOperation = SceneManager.LoadSceneAsync(prevScene = 1, LoadSceneMode.Additive);
            }
            else if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                if (prevScene >= 0)
                    unloadOperation = SceneManager.UnloadSceneAsync(prevScene);
                loadOperation = SceneManager.LoadSceneAsync(prevScene = 2, LoadSceneMode.Additive);
            }
            else if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                if (prevScene >= 0)
                    unloadOperation = SceneManager.UnloadSceneAsync(prevScene);
                loadOperation = SceneManager.LoadSceneAsync(prevScene = 3, LoadSceneMode.Additive);
            }
            else if (Input.GetKeyDown(KeyCode.Keypad5))
            {
                if (prevScene >= 0)
                    unloadOperation = SceneManager.UnloadSceneAsync(prevScene);
                loadOperation = SceneManager.LoadSceneAsync(prevScene = 4, LoadSceneMode.Additive);
            }
        }
    }
}