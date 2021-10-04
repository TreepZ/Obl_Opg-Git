using C_Sharp_Unit_Test;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading.Tasks;

namespace TCPServer
{
    internal class Program
    {
        private static StreamReader reader;
        private static StreamWriter writer;
        static List<Footballplayer> footballplayers = new List<Footballplayer>
        {
            new Footballplayer() { ID = 1, Name = "Emil", Price = 34, ShirtNum = 4 },
            new Footballplayer() { ID = 2, Name = "Oliver", Price = 35, ShirtNum = 5 }
        };
        private static void Main(string[] args)
        {
            Console.WriteLine("Server Ready!");

            TcpListener listener = new TcpListener(IPAddress.Any, 2121);
            listener.Start();

            while (true)
            {
                TcpClient socket = listener.AcceptTcpClient();
                listener.Start();
                Console.WriteLine("New Client!");

                Task.Run(() =>
                {
                    HandleClient(socket);
                });
            }
        }

        

        private static void HandleClient(TcpClient socket)
        {
            NetworkStream ns = socket.GetStream();
            reader = new StreamReader(ns);
            writer = new StreamWriter(ns);
            string message = "";

            while (true) 
            {
                message = reader.ReadLine().ToLower();

                switch (message)
                {
                    case "getall":
                    case "GetAll":
                    case "GETALL":
                    case "Get All":
                        GetAll();
                        break;

                    case "get":
                    case "Get":
                    case "GET":
                        Get();
                        break;

                    case "save":
                    case "Save":
                    case "SAVE":
                        Save();
                        break;
                    case "end": 
                        return;
                    default:
                        break;
                }
            }
            Footballplayer fromJson = JsonSerializer.Deserialize<Footballplayer>(message);
            Console.WriteLine("Footballplayer: " + fromJson.Name);
            writer.WriteLine("Footballplayer Recieved");
            writer.Flush();
            writer.Close();
        }

        private static void GetAll()
        {
            Console.WriteLine("Getting players");
            foreach (Footballplayer player in footballplayers)
            {
                writer.WriteLine(JsonSerializer.Serialize(player));
            }
            writer.Flush();
        }

        private static void Get()
        {
            
            int id = Int32.Parse(reader.ReadLine());
            var player = footballplayers.Find(p => p.ID == id);
            Console.WriteLine($"Getting player with ID: {player.ID}");
            writer.WriteLine(JsonSerializer.Serialize(player));
            writer.Flush();
        }

        private static void Save()
        {
            Footballplayer footballplayer = new Footballplayer();
            string msg = reader.ReadLine();
            footballplayer = JsonSerializer.Deserialize<Footballplayer>(msg);
            footballplayers.Add(footballplayer);
            writer.WriteLine("Footballplayer Added");
            writer.Flush();
        }
    }
}