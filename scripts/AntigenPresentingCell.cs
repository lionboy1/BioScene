using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Bioscene
{    
    public class AntigenPresentingCell : MonoBehaviour, IAudioHandler
    {
        [SerializeField] GameObject _canvasTeethUI;
        [SerializeField] GameObject _canvasScaredUI;
        [SerializeField] AudioSource source;
        [SerializeField] AudioSource musicSource;
        [SerializeField] AudioClip bawlingClip;
        [SerializeField] AudioClip eatingClip;
        [SerializeField] AudioClip introMusicClip;
        [SerializeField] GameObject covid;
        [SerializeField] GameObject mchComplex;
        [SerializeField] int sceneIndex;

        void Start()
        {
            _canvasTeethUI.SetActive(false);
            _canvasScaredUI.SetActive(false);
            source = GetComponent<AudioSource>();
        }

        void OnTriggerEnter(Collider col)
        {
            if(col.GetComponent<Virus>())
            {
                _canvasScaredUI.SetActive(true);
                
                StartCoroutine(Eat());
            }
        }
        IEnumerator Eat()
        {
            //in this case, the virus scared sound
            PlayExplosionSound();
            yield return new WaitForSeconds(2f);
            _canvasTeethUI.SetActive(true);
            _canvasScaredUI.SetActive(false);
            
            //Play the lymphcyte eating clip
            PlayLaughingClipOneShot();
            StartCoroutine(ActivateMHC());
        }
        public void PlayExplosionSound()
        {
            if(musicSource.isPlaying) musicSource.Stop();
            source.PlayOneShot(bawlingClip, 0.2f);
        }
        public void PlayLaughingClipOneShot()
        {
            source.PlayOneShot(eatingClip, 0.3f);
        }
        IEnumerator ActivateMHC()
        {
            yield return new WaitForSeconds(0.2f);
            mchComplex.SetActive(true);
            yield return new WaitForSeconds(5f);
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
            while(!operation.isDone)
            {
                yield return null;
            }
        }
    }
}