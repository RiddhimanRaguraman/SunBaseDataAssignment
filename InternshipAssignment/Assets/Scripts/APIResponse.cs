using System.Collections.Generic;
[System.Serializable]
public class APIResponse
{
    public Client[] clients;
    public Dictionary<int, ClientData> data;

    [System.Serializable]
    public class ClientData
    {
        public string address;
        public string name;
        public int points;
    }
}