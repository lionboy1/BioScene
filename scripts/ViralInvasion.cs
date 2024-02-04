using System;
using UnityEngine;
using Cinemachine;

namespace Bioscene
{
    public class ViralInvasion : MonoBehaviour
    {
        public static Action switchCameraBackToMainVirus;
        public static Action timeToReplicate;
        Vector3 virusStartPos;
        Vector3 startPos;
        [SerializeField] Transform bacterialDNA;
        Vector3 endPos => bacterialDNA.position;
        [SerializeField] float moveTime;
        float time;
        float particlePlayTimer;
        float camSwitchEventTimer;
        
        [SerializeField] GameObject[] newViruses;
        [SerializeField] GameObject parentVirus;
        [SerializeField] GameObject burstCytoplasm;
        [SerializeField] GameObject haha;
        [SerializeField] GameObject originalPhage;
        [SerializeField] CinemachineCamShake camShakeHandler;
        PlaySoundEffects  soundEffects;
        VFXHandler vfx;

        void Awake()
        {
            soundEffects = FindObjectOfType<PlaySoundEffects>();
            vfx = FindObjectOfType<VFXHandler>();
        }
        void Start()
        {
            startPos = transform.position;
            time = 0f;
        }
        void Update()
        {
            this.transform.position = Vector3.Lerp(startPos, endPos, time/moveTime);
            time += Time.deltaTime;
            HandleMovementEnd();
            virusStartPos = originalPhage.transform.position;
        }
        public virtual void HandleMovementEnd()
        {
            if(time >= moveTime )
            {
                /*if(vfx.injectEffects.isStopped)*/ vfx.PlayInjectParticles();
                timeToReplicate?.Invoke();
                particlePlayTimer += Time.deltaTime;
            }
            if(particlePlayTimer > 1)
            {
                vfx.StopInjectParticles();
                timeToReplicate = null;
                EnableNewPhage();
            }
        }
        void EnableNewPhage()
        {
            for(int i = 0; i < newViruses.Length; i++)
            {
                newViruses[i].SetActive(true);
            }
            BreachCellMembrane();
            vfx.SetEffectsCount();
        }
        void BreachCellMembrane()
        {
            burstCytoplasm.SetActive(true);
            bacterialDNA.gameObject.SetActive(false);
            if(vfx.dnaBurstEffects.isStopped && !vfx.EffectsCountGreaterThanZero()) 
            {
                vfx.PlayDNABurstParticles();
                //cell apoptosis
                PlayExplosionSound();

                CinemachineCameraHandler camHandler = new CinemachineCameraHandler();
                camShakeHandler.CallShake();
                //Show the laughing UI
                haha.SetActive(true);

                //laughing 
                PlayLaughingClipOneShot();

                //camera
                CamerWork();
                switchCameraBackToMainVirus?.Invoke();
            }
        }
        void CamerWork()
        {
            camSwitchEventTimer += Time.deltaTime;
            if(camSwitchEventTimer > 5)
            {
               switchCameraBackToMainVirus = null;
               CinemachineCameraHandler.usingCineCam1 = true;
            }   
        }
        public void PlayLaughingClipOneShot()
        {
            soundEffects.PlayLaughingClipOneShot();
        }
        void PlayExplosionSound()
        {
            soundEffects.PlayExplosionSound();
        }
    }
}