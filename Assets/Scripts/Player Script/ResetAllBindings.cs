using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ResetAllBindings : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActions;

    public void ResetBindings()
    {
        foreach (InputActionMap map in inputActions.actionMaps)
        {
            map.RemoveAllBindingOverrides();
            GetComponent<RebindSaveLoad>().Save();
        }
        PlayerPrefs.DeleteKey("rebinds");
        GetComponent<RebindSaveLoad>().Save();
    }
}
