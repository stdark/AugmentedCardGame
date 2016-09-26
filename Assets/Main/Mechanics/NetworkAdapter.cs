using UnityEngine;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System;
namespace Vuforia
{
    public class NetworkAdapter : DefaultTrackableEventHandler
    {

        
        
       
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
        public GameObject btn2;
        public GameObject mainFrame;
        public GameObject A1frame;
        public GameObject B1frame;
        int i = 0;
        string ip = "192.168.43.75";
        int port = 8888;

        void Start()
        { 
            

        }
        void Update()
        {
           


        }

        public void Click()
        {
            if (btn.tag == "attack_btn")
            {
                
                if (i == 0) { aKintoki.Play("punch"); aGilgamesh.Play("damage"); }
                if (i == 1) { aGilgamesh.Play("punch"); aWaver.Play("damage"); }
                if (i == 2) { aJanneAlt.Play("punch"); aJanne.Play("damage");}
                if (i == 3) { aJanne.Play("punch"); aKintoki.Play("damage"); }
                if (i == 4) { aWaver.Play("punch");  aGilgamesh.Play("damage"); }
                if (i == 5) { aAlex.Play("punch"); aWaver.Play("damage"); };
                if (i == 6) { aKintoki.Play("punch"); aJanne.Play("damage"); }
                if (i == 7) { aGilgamesh.Play("punch"); aWaver.Play("die"); }
                if (i == 8) { aJanneAlt.Play("punch"); aAlex.Play("die");}
                if (i == 9) { aJanne.Play("punch"); aJanneAlt.Play("damage"); }
                if (i == 10) { aKintoki.Play("punch"); aJanne.Play("die");}
                if (i == 11) { aGilgamesh.Play("punch"); aKintoki.Play("damage"); }
                if (i == 12) { aJanneAlt.Play("punch"); aGilgamesh.Play("die"); i = -2; }
                i++;
            }
            if (btn2.name == "Attack_1s")
            {
                aKintoki.Play("punch");
                aGilgamesh.Play("punch");
                aJanneAlt.Play("punch");
                aJanne.Play("punch");
                aWaver.Play("punch");
                aAlex.Play("punch");
            }

            }

        }
       
    }


