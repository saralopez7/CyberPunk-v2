using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class ClientManager : NetworkManager
    {

        // Create a local client and connect to the local server
        public void SetupLocalClient()
        {
                singleton.networkAddress = GetLocalIpAddress();
            singleton.networkPort = 7777;
            singleton.StartClient();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
        }

        
        public void SetupHost()
        {
            singleton.networkPort = 7777;
            
            singleton.StartHost();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                

        }

        public static string GetLocalIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public void QuitGame()
        {
            Debug.Log("Quit game");
            Application.Quit();
        }

    }
}