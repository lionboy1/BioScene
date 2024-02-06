using System;
using UnityEngine;

namespace Bioscene
{
    public class SpawnTimer : MonoBehaviour
    {
        public static Action spawnNotifier;
        [SerializeField] float spawnTime;
        [SerializeField] int numberOfRounds;
        float elapsedTime;
        int roundCount;
        void Start()
        {
            roundCount = 0;
        }

        void Update()
        {
            elapsedTime += Time.deltaTime;
            if(elapsedTime >= spawnTime)
            {
                roundCount++;
                spawnNotifier?.Invoke();
                elapsedTime = 0;
                
                Debug.Log($"Spawning round {roundCount}.");
            }
            if(roundCount >= numberOfRounds)
            {
                Invoke("ResetEvent", 1f);
            }
        }
        void ResetEvent()
        {
            spawnNotifier = null;
            roundCount = 0;
        }
    }
}