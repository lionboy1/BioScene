using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bioscene
{
    public class THelperCell : MonoBehaviour
    {
        [SerializeField] GameObject wantedPoster;
        [SerializeField] Vector3 apcPos;
        bool toToAPC;
        float elapsedTime;
        float time;
        void Start()
        {
            wantedPoster.SetActive(false);
            time = 0;
        }
        void Update()
        {
            if(toToAPC)
            {
                transform.Translate(Vector3.Lerp(transform.position, apcPos, time/elapsedTime));
                elapsedTime += Time.deltaTime;
            }
        }
        void OnTriggerEnter(Collider other)
        {
            if(other.GetComponent<MastCell>())
            {
                wantedPoster.SetActive(true);
            }
        }
        void OnEnable()
        {
            AntigenPresentingCell.alertThCell += GoToAPC;
        }
        void OnDisable()
        {
            AntigenPresentingCell.alertThCell -= GoToAPC;
        }
        void GoToAPC()
        {
            toToAPC = true;
        }
    }
}