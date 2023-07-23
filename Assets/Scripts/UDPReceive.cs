using UnityEngine;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class UDPReceive : MonoBehaviour
{

    Thread receiveThread;
    UdpClient client; 
    public int port = 5052;
    public bool startRecieving = true;
    public bool printToConsole = false;
    public string data;


    public void Start()
    {

        receiveThread = new Thread(
            new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();

    }


    // receive thread
    private void ReceiveData()
    {
        //port numaras�n� yazarak handtrackingteki bilgiler aktar�l�r.
        client = new UdpClient(port);
        while (startRecieving)
        {

            try
            {
                // ba�lant� noktas� olu�turulur
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] dataByte = client.Receive(ref anyIP);//veriler al�n�r 
                data = Encoding.UTF8.GetString(dataByte);//elin kordinatlar� data de�i�kenine atan�r

                if (printToConsole) { print(data); }
            }
            catch (Exception err)
            {
                print(err.ToString());
            }
        }
    }

}
