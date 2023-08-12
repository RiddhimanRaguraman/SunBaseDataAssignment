using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ClientListItem : MonoBehaviour, IPointerClickHandler
{
    public TextMeshProUGUI labelText; // Reference to the TextMeshPro component displaying the label
    private Client clientData; // Reference to the client data
    private UIManager uiManager; // Reference to the UIManager script

    // Initialize the client item with data and UIManager reference
    public void Initialize(Client client, UIManager manager)
    {
        clientData = client;
        uiManager = manager;

        labelText.SetText(client.label);
    }

    // Called when the client item is clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        uiManager.ShowClientDetails(clientData);
    }
}
