﻿using System;
using System.ComponentModel;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading;
using System.IO;
using System.Threading.Tasks;
using WebSocket4Net;
using System.Text;

namespace Union
{
    public partial class ClientManager : Component
    {
        private static TextWriter LogFile = File.AppendText("union-log.txt");
        public static WebSocket ws;

        public static Form1 login;
        public static Main client;
        
        private static string self = "";

        public static void CreateLogin(String errorMessage = "")
        {
            new Thread(() =>
            {
                login = new Form1();
                login.Show();
                login.ErrorReason.Text = errorMessage;
                Application.Run(login);
            }).Start();
        }

        public static void CreateClient()
        {
            new Thread(() =>
            {
                client = new Main();
                client.Show();
                Application.Run(client);
            }).Start();
        }

        #region Functions

        public static void Connect(String name, String password)
        {
            string b64Encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{name}:{password}"));
            List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("authorization", $"Basic {b64Encoded}")
            };

            ws = new WebSocket("ws://union.serux.pro:2082", customHeaderItems: headers);
            ws.Closed += OnClose;
            ws.Error += OnError;
            ws.MessageReceived += OnMessage;
            ws.Open();
            self = name;
        }

        public static void GetMembersFor(int server)
        {
            IWSMessage wsm = new IWSMessage()
            {
                op = (int)OPCODES.SyncMembers,
                d = server
            };

            string compiled = JsonConvert.SerializeObject(wsm);
            ws.Send(compiled);
        }

        static void Log(LogLevel level, Object content, params Object[] extra)
        {
            String log = content.ToString() + "\n\t";
            foreach (Object o in extra)
            {
                log += o.ToString() + "\n\t";
            }
            Console.WriteLine($"[{level.ToString()}] {log.Trim()}");
            LogFile.WriteLine($"[{level.ToString()}] {log.Trim()}");
        }

        public static void WriteLog()
        {
            LogFile.Flush();
            LogFile.Close();
        }

        #endregion

        #region Events

        async static void OnMessage(Object sender,  EventArgs eventArgs)
        {
            MessageReceivedEventArgs e = (MessageReceivedEventArgs)eventArgs;
            try
            {
                JObject data = JObject.Parse(e.Message);
                int op = (int)data.Property("op").Value;

                OPCODES code = (OPCODES)Enum.Parse(typeof(OPCODES), op.ToString());
                Log(LogLevel.DEBUG, $"Received message", $"opcode {op} ({code})", e.Message);

                switch (code)
                {
                    case OPCODES.Hello:
                        CreateClient();
                        JArray d = (JArray)data.Property("d").Value;

                        await Task.Delay(300);
                        client?.AddServers(d);
                        break;

                    case OPCODES.DispatchMessage:
                        JObject message = (JObject)data.Property("d").Value;

                        int server = (int)message.Property("server").Value;
                        string id = message.Property("id").Value.ToString();
                        string content = message.Property("content").Value.ToString();
                        string author = message.Property("author").Value.ToString();
                        long time = (long)message.Property("createdAt").Value;

                        Message m = new Message(author, content, author == self, id, time);
                        client?.CacheMessage(server, m);
                        break;

                    case OPCODES.DispatchPresence:
                        JObject presenceData = (JObject)data.Property("d").Value;
                        string userId = presenceData.Property("id").Value.ToString();
                        bool online = (bool)presenceData.Property("status").Value;

                        client?.UpdatePresence(userId, online);
                        break;

                    case OPCODES.DispatchMembers:
                        JArray members = (JArray)data.Property("d").Value;
                        client?.AddMembers(members);
                        break;

                    case OPCODES.Error:
                        string error = data.Property("d").Value.ToString();
                        //MessageBox.Show(error);
                        break;

                    case OPCODES.DispatchDeleteMessage:
                        client?.DeleteMessage(data.Property("d").Value.ToString());
                        break;
                }
            }
            catch (Exception err)
            {
                Log(LogLevel.ERROR, "Websocket encountered an error while receiving", err);
            }
        }

        static void OnError(Object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {
            Log(LogLevel.ERROR, $"Websocket encountered an exception", e.Exception);
        }

        static void OnClose(Object sender, EventArgs eventArgs)
        {
            ws.MessageReceived -= OnMessage;
            ws.Error -= OnError;
            ws.Closed -= OnClose;

            string closeReason = "";

            if (eventArgs.GetType().Equals(typeof(ClosedEventArgs)))
            {
                ClosedEventArgs e = (ClosedEventArgs)eventArgs;
                Log(LogLevel.INFO, $"Websocket closed - code: {e.Code}, reason: {e.Reason}");
                closeReason = e.Reason;
            } else
            {
                Log(LogLevel.INFO, "Websocket closed");
            }

            if (!client.Disposing && !client.IsDisposed)
                client?.Invoke(new Action(() => client.Dispose()));

            CreateLogin(closeReason);

        }

        #endregion

        #region Enums

        enum LogLevel
        {
            DEBUG,
            INFO,
            ERROR
        }

        public enum OPCODES
        {
            Hello = 1,
            DispatchMemberAdd,
            DispatchMessage,
            DispatchPresence,
            DispatchMembers,
            DispatchDeleteMessage,
            SyncMembers,
            Message,
            MemberAdd,
            DeleteMessage,
            Error,
        }

        #endregion
    }
}
