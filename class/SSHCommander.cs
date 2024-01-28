﻿using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamelistManager
{
    internal class SSHCommander
    {
        public static string ExecuteSSHCommand(string hostName,string userID, string userPassword, string command)
        {
            string output = string.Empty;
            using (var client = new SshClient(hostName, userID, userPassword))
            {
                try
                {
                    client.Connect();
                }
                catch
                {
                    return "connectfailed";
                }

                using (var commandRunner = client.RunCommand(command))
                {
                    // Show the server output in a message box
                    output = commandRunner.Result;
                }
                client.Disconnect();
                userPassword = null;
                return output;
            }
        }
    }
}
