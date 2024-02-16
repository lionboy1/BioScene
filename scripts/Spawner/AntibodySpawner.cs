using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntibodySpawner : MonoBehaviour
{
    [SerializeField] GameObject antibody;
    void Start()
    {
        antibody.SetActive(false);
    }
    public void PlayAntibodyEffect()
    {
        antibody.SetActive(true);
    }

}
