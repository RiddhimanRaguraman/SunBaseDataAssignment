using System.Collections.Generic;
[System.Serializable]
public class Client
{
    public bool isManager;
    public int id;
    public string label;
    public ClientData data;
}

[System.Serializable]
public class ClientData
{
    public string address;
    public string name;
    public int points;
}