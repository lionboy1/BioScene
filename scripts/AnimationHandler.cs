using UnityEngine;

namespace Bioscene
{
    public class AnimationHandler : MonoBehaviour, IAnimate    
    {
        [SerializeField] Animator _anim;
        void Awake()
        {
            _anim = GetComponentInChildren<Animator>();
        }
        public void PlayAnimation()
        {
            _anim.SetTrigger("move");
        }
        public void StopAnimation()
        {
            _anim.ResetTrigger("move");
        }
    }
}