using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bioscene
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] int numSpawn;
        [SerializeField] int currentSpawnedAmount;
        [SerializeField] GameObject virus;
        [SerializeField] Transform spawnLoc;
        [SerializeField] float spawnRate;

        void Start()
        {
            SpawnFirstWave();
        }
        
        void OnEnable()
        {
            SpawnTimer.spawnNotifier += SpawnMore;
        }
        void OnDisable()
        {
            SpawnTimer.spawnNotifier -= SpawnMore;
        }
        public void SpawnFirstWave()
        {
            StartCoroutine(InitialSpawn());
        }
        IEnumerator InitialSpawn()
        {
            for(int i = 0; i < 5; i++)
            {
                GameObject spawned = Instantiate(virus, spawnLoc.position, spawnLoc.rotation);
                currentSpawnedAmount++;
                yield return new WaitForSeconds(spawnRate);
            }
        }
        void SpawnMore()
        {
            StartCoroutine(SpawnEnumerator());
        }
        IEnumerator SpawnEnumerator()
        {
            for(int i = 0; i < currentSpawnedAmount; i++)
            {
                GameObject spawned = Instantiate(virus, transform.position, spawnLoc.rotation);
                numSpawn++;
                yield return new WaitForSeconds(spawnRate);
            }
            currentSpawnedAmount  += numSpawn;
        }
    }
}
