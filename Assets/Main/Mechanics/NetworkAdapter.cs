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


        public Animator anim;
        public Animator anim2;

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

                    mId[0] = retID();
                    mX = fl2byte(ReturnX());
                    mY = fl2byte(ReturnY());

                    sock.Send(mId);
                    sock.Send(mX);
                    sock.Send(mY);

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
            
            anim.Play("punch");
            anim2.Play("punch");

        }

        public byte retID()
        {
            if (anim.name == CardsList.Arthuria)
                return (byte)CardsList.Cards.Arthuria;
            else if (anim.name == CardsList.Arthuria)
                return (byte)CardsList.Cards.Arthuria;
            else if (anim.name == CardsList.Gilgamesh)
                return (byte)CardsList.Cards.Gilgamesh;
            else if (anim.name == CardsList.Scatach)
                return (byte)CardsList.Cards.Scatach;
            else if (anim.name == CardsList.Alex)
                return (byte)CardsList.Cards.Alex;
            else if (anim.name == CardsList.Waver)
                return (byte)CardsList.Cards.Waver;
            else if (anim.name == CardsList.Emiya)
                return (byte)CardsList.Cards.Emiya;
            else if (anim.name == CardsList.Kintoki)
                return (byte)CardsList.Cards.Kintoki;
            else if (anim.name == CardsList.Janne)
                return (byte)CardsList.Cards.Janne;
            else if (anim.name == CardsList.JanneAlt)
                return (byte)CardsList.Cards.JanneAlt;
            else return 0;
        }

        byte[] fl2byte(float x)
        {
            return BitConverter.GetBytes(x);
        }


    }

}