using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine;

public class FadeImagesUI : MonoBehaviour
{
    [SerializeField] Image girlImage;
    [SerializeField] Image lungImage;
    [SerializeField] float fadeTime;
    Color c;
    [SerializeField] float time;
    [SerializeField] Camera cam;
    float elapsedTime;
    [SerializeField] CinemachineVirtualCamera vcam;


    void Start()
    {
        c = lungImage.color;
        c.a = 0;
        lungImage.color = c;
    }

    void Update()
    {
        girlImage.CrossFadeAlpha(0, fadeTime, false);
        c.a = Mathf.Lerp(0, 1, elapsedTime/time);
        elapsedTime += Time.deltaTime;
        lungImage.color = c;
        // Camera.main.fieldOfView = 30;
        vcam.m_Lens.FieldOfView = 20;
    }
}
