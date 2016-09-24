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


        public Animator Kintoki;
        public Animator Gilgamesh;
        public Animator Emiya;
        public Animator JanneAlt;
        public Animator Scatach;

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
            mX = fl2byte(CoordCountX(Kintoki));
            mY = fl2byte(CoordCountY(Kintoki));
            mId[0] = retID();
            
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
                    

                    byte[] temp = {mId[0], mX[0], mX[1], mX[2], mX[3], mY[0], mY[1], mY[2], mY[3], mMove[0]};
                    sock.Send(temp);
                    
                    

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
                Kintoki.Play("punch");
                Gilgamesh.Play("punch");
                Emiya.Play("punch");
                JanneAlt.Play("punch");
                Scatach.Play("punch");
            }

        }

        public byte retID()
        {
            if (Kintoki.name == CardsList.Arthuria)
                return (byte)CardsList.Cards.Arthuria;
            else if (Kintoki.name == CardsList.Arthuria)
                return (byte)CardsList.Cards.Arthuria;
            else if (Kintoki.name == CardsList.Gilgamesh)
                return (byte)CardsList.Cards.Gilgamesh;
            else if (Kintoki.name == CardsList.Scatach)
                return (byte)CardsList.Cards.Scatach;
            else if (Kintoki.name == CardsList.Alex)
                return (byte)CardsList.Cards.Alex;
            else if (Kintoki.name == CardsList.Waver)
                return (byte)CardsList.Cards.Waver;
            else if (Kintoki.name == CardsList.Emiya)
                return (byte)CardsList.Cards.Emiya;
            else if (Kintoki.name == CardsList.Kintoki)
                return (byte)CardsList.Cards.Kintoki;
            else if (Kintoki.name == CardsList.Janne)
                return (byte)CardsList.Cards.Janne;
            else if (Kintoki.name == CardsList.JanneAlt)
                return (byte)CardsList.Cards.JanneAlt;
            else return 0;
        }

        byte[] fl2byte(float x)
        {
            return BitConverter.GetBytes(x);
        }


        public float CoordCountX(Animator ani)
        {
            if (z)
            {
                return (float)(((mainFrame.transform.position.x + B1frame.transform.position.x) / 2) * Math.Cos((ani.transform.position.x - B1frame.transform.position.x) / (B1frame.transform.position.x - mainFrame.transform.position.x)) + ((B1frame.transform.position.x + A1frame.transform.position.x) / 2) + ((mainFrame.transform.position.x + A1frame.transform.position.x) / 2) * Math.Cos((ani.transform.position.x - B1frame.transform.position.x) / (A1frame.transform.position.x - mainFrame.transform.position.x)));
            }
            return 0;
        }
        public float CoordCountY(Animator ani)
        {
            if (z)
            {
                return (float)(((mainFrame.transform.position.z + B1frame.transform.position.z) / 2) * Math.Cos((ani.transform.position.z - B1frame.transform.position.z) / (B1frame.transform.position.z - mainFrame.transform.position.z)) + ((B1frame.transform.position.z + A1frame.transform.position.z) / 2) + ((mainFrame.transform.position.z + A1frame.transform.position.z) / 2) * Math.Cos((ani.transform.position.z - B1frame.transform.position.z) / (A1frame.transform.position.z - mainFrame.transform.position.z))); return 0;
        }
            return 0;
        }

    }

}