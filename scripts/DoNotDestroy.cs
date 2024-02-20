using UnityEngine;

namespace Bioscene
{
    public class DoNotDestroy : MonoBehaviour
    {
        void Start()
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}