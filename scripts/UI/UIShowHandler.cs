using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bioscene
{    
    public class UIShowHandler : MonoBehaviour
    {
        [SerializeField] GameObject uiObj;
        void Start()
        {
            uiObj.SetActive(false);
        }

        void OnTriggerEnter(Collider col)
        {
            if(col.GetComponent<TcCell>())
            {
                uiObj.SetActive(true);
                Debug.Log("WBC contact");
            }
        }
        void Update()
        {
            if(Input.GetKey(KeyCode.I))
            {
                uiObj.SetActive(true);
            }
        }
    }
}
