using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Bioscene
{    
    public class BiosceneLoader : MonoBehaviour
    {
        [SerializeField] int sceneIndex;
        [SerializeField] float waitTime;
        void Start()
        {
            StartCoroutine(LoadBioscene());
        }
        IEnumerator LoadBioscene()
        {
            yield return new WaitForSeconds(waitTime);
            {
                AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
                while(!operation.isDone)
                {
                    yield return null;
                }
            }
        }
    }
}
