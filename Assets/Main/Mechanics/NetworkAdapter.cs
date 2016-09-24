using UnityEngine;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Threading;
public class NetworkAdapter : MonoBehaviour
{


    string ip = "192.168.43.75";
    int port = 8888;
    byte[] mass = { 0, 0, 0, 0, 0, 0 };
    public Animator obj;

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
                sock.Send(mass);
                mass = null;
            }
            sock.Close();
            client.Close();

        }
        catch
        {
            Debug.Log("Can't connect");

        }

    }

    public void Click()
    {
        Debug.Log("Button");
        obj.Play("bers_punch");

        mass = new byte[] { 255, 135, 168, 68, 97, 15};
    }



}

