using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.AddressableAssets;

public class AddressablesSpawner : MonoBehaviour
{
    [SerializeField] AssetReferenceGameObject objToLoad;
    GameObject _instanceReference;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            //Specifically for gameobjects
            objToLoad.InstantiateAsync().Completed += SomeAddressableLoadMethod;

            //Otherwise, use a call back for general instantiation, which still includes game objects 
            // objToLoad.LoadAssetAsync() += SomeAddressableLoadMethod;
        }
        else if(Input.GetKey(KeyCode.U))
        {
            objToLoad.ReleaseInstance(_instanceReference);
        }

        void SomeAddressableLoadMethod(AsyncOperationHandle<GameObject> objHandle)
        {
            if(objHandle.Status == AsyncOperationStatus.Succeeded)
            {
                _instanceReference = objHandle.Result;
            }
            
        }
    }
}