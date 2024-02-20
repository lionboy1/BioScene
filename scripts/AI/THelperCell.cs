using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Bioscene
{
    public class THelperCell : MonoBehaviour
    {
        [SerializeField] GameObject wantedPoster;
        [SerializeField] GameObject vCam1;
        [SerializeField] GameObject vCam2;
        [SerializeField] int sceneIndex;
        void Start()
        {
            wantedPoster.SetActive(false);
           
        }
        void Update()
        {
           
        }
        void OnTriggerEnter(Collider other)
        {
            if(other.GetComponent<MastCell>())
            {
                wantedPoster.SetActive(true);
                vCam1.SetActive(false);
                vCam2.SetActive(true);
                StartCoroutine(LoadSceneAsync());
            }
        }
        IEnumerator LoadSceneAsync()
        {
            yield return new WaitForSeconds(3f);
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneIndex);
            while(!loadOperation.isDone)
            {
                yield return null;
            }
        }
    }
}