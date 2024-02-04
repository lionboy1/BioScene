using UnityEngine;

namespace Bioscene
{
    public class VFXHandler : MonoBehaviour
    {
        public ParticleSystem injectEffects;
        public ParticleSystem dnaBurstEffects;
        int effectsCount;

        void Start()
        {
            injectEffects.Stop();
            dnaBurstEffects.Stop();
        }
        void Update()
        {

        }
        public void PlayInjectParticles()
        {
           injectEffects.Play();
        }
        public void StopInjectParticles()
        {
            injectEffects.Stop();
        }
        public void PlayDNABurstParticles()
        {
            if(dnaBurstEffects.isStopped)
            {
                dnaBurstEffects.Play();
            }
        }
        public void StopDNABurstParticles()
        {
            dnaBurstEffects.Stop();
        }
        public bool EffectsCountGreaterThanZero()
        {
            return effectsCount > 0;
        }
        public void SetEffectsCount()
        {
            effectsCount++;
        }
    }
}