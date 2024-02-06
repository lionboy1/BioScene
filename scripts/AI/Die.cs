using UnityEngine;
namespace Bioscene
{
    public class Die : MonoBehaviour
    {
        void OnTriggerEnter(Collider detected)
        {
            if(detected.GetComponent<Virus>())
            {
                detected.gameObject.SetActive(false);
                //play vfx
            }
            if(detected.GetComponent<PlayerMovement>())
            {
                Health health = detected.GetComponent<Health>();
                if(health.Dead())
                {
                    //disable detected and play vfx
                }
            }
        }
    }
}