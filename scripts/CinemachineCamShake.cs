using UnityEngine;
using Cinemachine;

public class CinemachineCamShake : MonoBehaviour
{
    [SerializeField] CinemachineImpulseSource impulseSource;

    public void CallShake()
    {
        Invoke("ShakeTheCam", 0.2f);
    }
    void ShakeTheCam()
    {
        impulseSource.GenerateImpulse(10f);
    }
}