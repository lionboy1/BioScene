using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bioscene
{
    [RequireComponent(typeof(AnimationHandler))]
    public class OriginalPhageMovement : MonoBehaviour
    {
        
        public static Action movementComplete;
        AnimationHandler _animationHandler;
        public Transform phage;
        public Transform bacteriumSurfacereceptor;
        Vector3 endPos => bacteriumSurfacereceptor.position;
        public float timeToCompletion;
        Vector3 startPos;
        bool done;
        float time;
        float timer;
        // Start is called before the first frame update
        void Awake()
        {
            _animationHandler = GetComponent<AnimationHandler>();
        }
        void Start()
        {
            time = 0f;
            //cache the initial position or else lerping will update the start position
            //each frame, resulting in accelerated movement.
            startPos = transform.position;
        }
        void Update()
        {
            _animationHandler.PlayAnimation();
            CheckDone();
            phage.position = Vector3.Lerp(startPos, endPos, time/timeToCompletion );
            time += Time.deltaTime;
            if(time >= timeToCompletion)
            {
                done = true;
            }
        }
        void CheckDone()
        {
            if(done)
            {
                movementComplete?.Invoke();
                _animationHandler.StopAnimation();
                timer += Time.deltaTime;
            }
            if(timer > 1f)
            {
                done = false;
                movementComplete = null;
            }
        }
    }
}
