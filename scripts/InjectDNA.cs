using UnityEngine;

namespace Bioscene
{
    [RequireComponent(typeof(VFXHandler))]
    public class InjectDNA : MonoBehaviour, IActivate
    {
        public GameObject viralDNA;
        public VFXHandler _vfxHandler;
      
        void OnEnable()
        {
            OriginalPhageMovement.movementComplete += Inject;
        }
        void OnDisable()
        {
            OriginalPhageMovement.movementComplete -= Inject;
        }
        void Inject()
        {
            SetVisibility();
        }
        public void SetVisibility()
        {
            if(_vfxHandler.injectEffects.isStopped)
            {
                _vfxHandler.injectEffects.Play();
            } 
            viralDNA.SetActive(true);
        }
    }
}

