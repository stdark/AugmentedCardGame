using UnityEngine;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Threading;
public class NetworkAdapter : MonoBehaviour {
    string ip="192.168.43.75";
    int port=8888;
	void Start()
    {
        Thread thead = new Thread(Connect);
        thead.Start();
        
        
    }
    void Connect()
    {
        TcpClient client = new TcpClient();
        Socket sock;
        try
        {
            client.Connect(ip, port);
            Debug.Log("Connected");
            sock = client.Client;
            while (true)
            {
                byte[] mass = {};
                sock.Send(mass);
            }
            sock.Close();
            client.Close();

        }
        catch
        {
            Debug.Log("Can't connect");
           
        }        
        
    }
}
