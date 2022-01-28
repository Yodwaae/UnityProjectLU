using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RebindSaveLoad : MonoBehaviour
{

/// <summary>
/// Very crude implementation of a rebind save/load system.
/// The important part here are the `InputActionMap.bindings`,`InputBindings.overridePath`,
/// and `InputActionMap.ApplyBindingOverride()` APIs.
/// </summary>

    [SerializeField] private InputActionAsset _inputActionAsset;

    private void Awake()
    {
        Load();
    }

    public void Save()
    {
        // We loop through our action maps and save all the rebinds if there are any
        foreach (var actionMap in _inputActionAsset.actionMaps)
        {
            foreach (var binding in actionMap.bindings)
            {
                if (!string.IsNullOrEmpty(binding.overridePath))
                {
                    string key = binding.id.ToString();
                    string val = binding.overridePath;
                    PlayerPrefs.SetString(key, val);
                }
            }
        }
    }

    public void Load()
    {
        // We loop through each action map and apply rebinds if they exist in our player prefs
        foreach (var actionMap in _inputActionAsset.actionMaps)
        {
            var bindings = actionMap.bindings;
            for (int i = 0; i < bindings.Count; i++)
            {
                var binding = bindings[i];
                string key = binding.id.ToString();
                string val = PlayerPrefs.GetString(key, null);
                if (string.IsNullOrEmpty(val)) continue;
                actionMap.ApplyBindingOverride(i, new InputBinding { overridePath = val });
            }
        }
    }

}