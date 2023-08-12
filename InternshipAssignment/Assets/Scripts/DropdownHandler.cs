using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropdownHandler : MonoBehaviour
{
    public UIManager uiManager; // Reference to the UIManager script

    private TMP_Dropdown dropdown; // Use TMP_Dropdown for TextMeshPro dropdown

    private void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>(); // Change to TMP_Dropdown
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    private void OnDropdownValueChanged(int value)
    {
        uiManager.FilterDropdownValueChanged(value);
    }
}
