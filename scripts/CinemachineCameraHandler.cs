using UnityEngine;
using Cinemachine;

namespace Bioscene
{
    public class CinemachineCameraHandler : MonoBehaviour
    {
        [SerializeField]
        CinemachineVirtualCamera cineCam1;
        [SerializeField]
        CinemachineVirtualCamera cineCam2;
        public static bool usingCineCam1;
        float time;
        [SerializeField] float intensityTime;
       
        void Start()
        {
            cineCam1.Priority = 1;
            cineCam1.Priority = 0;
            usingCineCam1 = cineCam1.Priority > 0 ? true : false;
        }
        void OnEnable()
        {
            ViralInvasion.switchCameraBackToMainVirus += SwitchCameras;
        }
        void OnDisable()
        {
            ViralInvasion.switchCameraBackToMainVirus -= SwitchCameras;
        }
        void Update()
        {
            if(usingCineCam1)
            {
                time += Time.deltaTime;
            } 
        }
        void SwitchCameras()
        {
            if(usingCineCam1)
            {
                cineCam1.Priority = 0;
                cineCam2.Priority = 1;
            }
        }
    }
}