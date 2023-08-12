using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Other public variables you might have
    public GameObject clientListItemPrefab;
    public Transform clientListParent;
    public TMP_Text popupNameText;
    public TMP_Text popupPointsText;
    public TMP_Text popupAddressText;
    public GameObject clientPopup;
    public TMP_Dropdown filterDropdown;
    public APIManager ApiManager;

    private List<ClientListItem> instantiatedItems = new List<ClientListItem>(); // Keep track of instantiated items
    private List<Client> allClients = new List<Client>();
    private List<Client> filteredClients = new List<Client>();

    private void Start()
    {
        // Initialize filter dropdown options and listeners
        filterDropdown.ClearOptions();
        filterDropdown.AddOptions(new List<string> { "All", "Managers", "Non-Managers" });
        filterDropdown.onValueChanged.AddListener(FilterDropdownValueChanged);

        // Fetch clients from the API
        ApiManager.FetchClientsFromAPI();
    }

    public void PopulateClientList(Client[] clients)
    {
        allClients = new List<Client>(clients);
        filteredClients = allClients;
        RefreshClientListContent();
    }

    private void RefreshClientListContent()
    {
        // Clear previous instantiated items
        ClearClientList();

        foreach (Client client in filteredClients)
        {
            // Instantiate the prefab
            GameObject listItemGO = Instantiate(clientListItemPrefab, clientListParent);
            ClientListItem listItemScript = listItemGO.GetComponent<ClientListItem>();

            // Initialize the item with data and UIManager reference
            listItemScript.Initialize(client, this);
            
            // Add the instantiated item to the list
            instantiatedItems.Add(listItemScript);
        }
    }

    private void ClearClientList()
    {
        // Destroy all instantiated items and clear the list
        foreach (var item in instantiatedItems)
        {
            Destroy(item.gameObject);
        }
        instantiatedItems.Clear();
    }
    
    public void FilterDropdownValueChanged(int value)
    {
        // Clear the existing list
        ClearClientList();

        switch (value)
        {
            case 0: // All
                filteredClients = allClients;
                break;
            case 1: // Managers
                filteredClients = allClients.FindAll(client => client.isManager);
                break;
            case 2: // Non-Managers
                filteredClients = allClients.FindAll(client => !client.isManager);
                break;
        }

        // Populate the list with sorted data
        RefreshClientListContent();
    }

    public void ShowClientDetails(Client client)
    {
        popupNameText.text = client.label;

        if (client.data != null)
        {
            popupPointsText.text = "Points: " + client.data.points;
            popupAddressText.text = "Address: " + client.data.address;
        }
        else
        {
            popupPointsText.text = "Points: N/A";
            popupAddressText.text = "Address: N/A";
        }

        clientPopup.SetActive(true);
    }


    public void closePopup()
    {
        clientPopup.SetActive(false);
    }
}
