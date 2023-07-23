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
        //port numarasýný yazarak handtrackingteki bilgiler aktarýlýr.
        client = new UdpClient(port);
        while (startRecieving)
        {

            try
            {
                // baðlantý noktasý oluþturulur
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] dataByte = client.Receive(ref anyIP);//veriler alýnýr 
                data = Encoding.UTF8.GetString(dataByte);//elin kordinatlarý data deðiþkenine atanýr

                if (printToConsole) { print(data); }
            }
            catch (Exception err)
            {
                print(err.ToString());
            }
        }
    }

}
