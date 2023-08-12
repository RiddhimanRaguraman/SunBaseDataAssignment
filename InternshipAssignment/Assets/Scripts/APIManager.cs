using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
// using Client;

public class APIManager : MonoBehaviour
{
     private const string API_URL = "https://qa2.sunbasedata.com/sunbase/portal/api/assignment.jsp?cmd=client_data";
    private Client[] clients; // An array to store client data
    public UIManager uiManager; // Reference to the UIManager script

    // Call this method to initiate API request
    public void FetchClientsFromAPI()
    {
        StartCoroutine(FetchClients());
    }

    private IEnumerator FetchClients()
    {
        UnityWebRequest request = UnityWebRequest.Get(API_URL);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("API request failed: " + request.error);
            yield break;
        }

        string jsonResponse = request.downloadHandler.text;

        // Deserialize the entire JSON response into an APIResponse object
        APIResponse apiResponse = JsonUtility.FromJson<APIResponse>(jsonResponse);

        clients = apiResponse.clients;

        // Notify UIManager to populate the list with fetched clients
        uiManager.PopulateClientList(clients);
    }
}
