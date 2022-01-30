using System;
using UnityEngine;
using UnityEngine.InputSystem;

//NE MARCHE PAS


public class ResetAllBindings : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActions;

    public void ResetBindings()
    {
        GetComponent<RebindSaveLoad>().Load();
        foreach (InputActionMap map in inputActions.actionMaps)
        {
            //Debug.Log("Reset");
            map.RemoveAllBindingOverrides();
            GetComponent<RebindSaveLoad>().Save();
        }
        PlayerPrefs.DeleteKey("rebinds");
    }
}
