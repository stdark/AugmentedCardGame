using UnityEngine;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System;
namespace Vuforia
{
    public class NetworkAdapter : DefaultTrackableEventHandler
    {


        string ip = "192.168.43.75";
        int port = 8888;
        byte[] mId = { 0 };
        byte[] mX = { 0, 0, 0, 0};
        byte[] mY = { 0, 0, 0, 0 };
        byte[] mMove = { 0 };
        byte[] buffer;
        public Animator aKintoki;
        public Animator aGilgamesh;
        public Animator aEmiya;
        public Animator aJanneAlt;
        public Animator aScatach;
        public Animator aWaver;
        public Animator aAlex;
        public Animator aJanne;
        public Animator aArthuria;

        public GameObject gKintoki;
        public GameObject gGilgamesh;
        public GameObject gEmiya;
        public GameObject gJanneAlt;
        public GameObject gScatach;
        public GameObject gWaver;
        public GameObject gAlex;
        public GameObject gJanne;
        public GameObject gArthuria;
        public GameObject btn;
        public GameObject mainFrame;
        public GameObject A1frame;
        public GameObject B1frame;


        void Start()
        {
            Thread thead = new Thread(Connect);
            thead.Start();


        }
        void Update()
        {
            mX = fl2byte(CoordCountX(gKintoki));
            mY = fl2byte(CoordCountY(gKintoki));
            mId = id2byte(retID(gKintoki));


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
                   
                   
                    byte[] temp = new byte[10]{mId[0], mX[0], mX[1], mX[2], mX[3], mY[0], mY[1], mY[2], mY[3], mMove[0]};
                    
                    sock.Send(temp);
                    Debug.Log("sent");
                    buffer = new byte[1024];
                    
                    sock.Receive(buffer, 0, buffer.Length, SocketFlags.None);
                    
                    string ten="";

                    for (int i = 0; i < buffer.Length; i++)
                    {
                        ten += buffer[i];
                        ten += ",";
                    }
                       
                        Debug.Log(ten);
                    
                    Thread.Sleep(10);
                    
                    

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
            if(btn.tag =="attack_btn")
            {
                Debug.Log("Button");
                aKintoki.Play("punch");
                aGilgamesh.Play("punch");
                aEmiya.Play("punch");
                aJanneAlt.Play("punch");
                aScatach.Play("punch");
                aWaver.Play("punch");
                aAlex.Play("punch");
                aJanne.Play("punch");
                aArthuria.Play("punch");
            }

        }
        void PositionHandler(byte id, float x, float y)
        {

        }

        public byte retID(GameObject oj)
        {
            if (oj == gKintoki)
                return 7;
            else if (oj == gJanneAlt)
                return 9;
            else if (oj == gGilgamesh)
                return 2;
            else if (oj == gArthuria)
                return 1;
            else if (oj == gJanne)
                return 8;
            else if (oj == gWaver)
                return 5;
            else if (oj == gScatach)
                return 3;
            else if (oj == gEmiya)
                return 6;
            else if (oj == gAlex)
                return 4;
            else return 0;
        }

        byte[] fl2byte(float x)
        {
            return BitConverter.GetBytes(x);
        }
        byte[] id2byte(byte x)
        {
            return BitConverter.GetBytes(x);
        }
        float byte2float (byte[] a)
        {
            
            return BitConverter.ToSingle(a,0);
        }

        public float CoordCountX(GameObject gd)
        {
            if (z)
            {
                return (float)(((mainFrame.transform.position.x + B1frame.transform.position.x) / 2) * Math.Cos((gd.transform.position.x - B1frame.transform.position.x) / (B1frame.transform.position.x - mainFrame.transform.position.x)) + ((B1frame.transform.position.x + A1frame.transform.position.x) / 2) + ((mainFrame.transform.position.x + A1frame.transform.position.x) / 2) * Math.Cos((gd.transform.position.x - B1frame.transform.position.x) / (A1frame.transform.position.x - mainFrame.transform.position.x)));
            }
            else return 0;
        }
        public float CoordCountY(GameObject gd)
        {
            if (z)
            {
                return (float)(((mainFrame.transform.position.z + B1frame.transform.position.z) / 2) * Math.Cos((gd.transform.position.z - B1frame.transform.position.z) / (B1frame.transform.position.z - mainFrame.transform.position.z)) + ((B1frame.transform.position.z + A1frame.transform.position.z) / 2) + ((mainFrame.transform.position.z + A1frame.transform.position.z) / 2) * Math.Cos((gd.transform.position.z - B1frame.transform.position.z) / (A1frame.transform.position.z - mainFrame.transform.position.z))); return 0;
             }
            else return 0;
        }

    }

}