using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;
using System.Threading;


namespace DCore_Websocket_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Select_Click(object sender, EventArgs e)
        {
            DialogResult dResult = openFileDialog1.ShowDialog();
            if (dResult == DialogResult.OK)
            {
                textBox_walletFile.Text = openFileDialog1.FileName;
            }
            else
            {
                textBox_walletFile.Text = "";
            }

        }

        private void button_Show_Click(object sender, EventArgs e)
        {
            if (button_Show.Text == "Show")
            {
                button_Show.Text = "Hide";
                textBox_Password.PasswordChar = '\0';
            }
            else
            {
                button_Show.Text = "Show";
                textBox_Password.PasswordChar = '*';
            }
        }

        int usernumber;
        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox_Status.HideSelection = false;
            richTextBox_Status.Focus();
            richTextBox_Status.AppendText("Please select a wallet.json file.");

            Random rnd = new Random();
            usernumber = rnd.Next(100, 1000);
        }

        public void updateTextbox(string text)
        {
            richTextBox_Status.HideSelection = false;
            richTextBox_Status.Focus();
            richTextBox_Status.AppendText(System.Environment.NewLine);
            richTextBox_Status.AppendText(text);
        }

        public void updateInvokedTextbox(string text)
        {
            richTextBox_Status.Invoke(new Action(() => richTextBox_Status.HideSelection = false));
            richTextBox_Status.Invoke(new Action(() => richTextBox_Status.Focus()));
            richTextBox_Status.Invoke(new Action(() => richTextBox_Status.AppendText(System.Environment.NewLine)));
            richTextBox_Status.Invoke(new Action(() => richTextBox_Status.AppendText(text)));
        }

        private void button_Send_Click(object sender, EventArgs e)
        {
            bool error = false;
            if (string.IsNullOrWhiteSpace(textBox_walletFile.Text))
            {
                error = true;
                updateTextbox("Error! Please select a wallet.json file.");
            }
            else if (File.Exists(textBox_walletFile.Text))
            {
                updateTextbox("Found wallet file.");
                if (Path.GetExtension(textBox_walletFile.Text) != ".json")
                {
                    error = true;
                    updateTextbox("Error! Invalid file type.");
                }
            }
            else
            {
                error = true;
                updateTextbox("Error! Can not locate wallet file.");
            }

            if (!error)
            {
                if (string.IsNullOrWhiteSpace(textBox_Password.Text))
                {
                    error = true;
                    updateTextbox("Error! Please enter the wallet file password.");
                }
                else if (string.IsNullOrWhiteSpace(textBox_sendTo.Text))
                {
                    error = true;
                    updateTextbox("Error! Please enter an account address.");
                }
                else if (string.IsNullOrWhiteSpace(textBox_Amount.Text))
                {
                    error = true;
                    updateTextbox("Error! Please enter an amount.");
                }
                else
                {
                    try
                    {
                        double amount = Convert.ToDouble(textBox_Amount.Text.Trim());
                    }
                    catch
                    {
                        error = true;
                        updateTextbox("Error! Invalid amount text.");
                    }
                }
            }

            if (!error)
            {
                loadWalletFile(textBox_walletFile.Text);
            }
        }

        public void loadWalletFile(string walletFile)
        {
            string wscatIP = @"ws://45.32.224.108:9050";
            using (var ws = new WebSocket(wscatIP))
            {
                ws.EnableRedirection = true;
                ws.OnOpen += (sender, e) =>
                {
                    updateInvokedTextbox("Connected to " + wscatIP);
                };

                ws.OnMessage += (sender, e) =>
                {
                    if (e.Data == "Successfully Written to File.")
                    {
                        updateInvokedTextbox("Successfully written wallet file on server");
                        CheckWalletPassword();
                    }
                };

                ws.OnError += (sender, e) => MessageBox.Show(e.Message, "Error recieved");

                string jsonText = "";
                bool error = false;
                try
                {
                    var fileStream = new FileStream(walletFile, FileMode.Open, FileAccess.Read);
                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                    {
                        jsonText = streamReader.ReadToEnd();
                    }
                }
                catch
                {
                    error = true;
                    updateInvokedTextbox("Error! Could not read wallet file.");
                }

                if (!jsonText.Contains("key_auths"))
                {
                    error = true;
                    updateInvokedTextbox("Error! Invalid wallet file.");
                }

                if (!error)
                {
                    ws.Connect();
                    Thread.Sleep(1000);
                    string message1 = "NEW-W-info?&?&?&" + jsonText + "?&?&?&" + usernumber;
                    ws.Send(message1);
                    Thread.Sleep(2000);
                }
            }
        }

        public void CheckWalletPassword()
        {
            string cli_IP = @"ws://45.32.224.108:8091";
            bool result = false;
            int iterate = 0;
            using (var ws = new WebSocket(cli_IP))
            {
                ws.EnableRedirection = true;
                ws.OnOpen += (sender, e) =>
                {
                    updateInvokedTextbox("Connected to " + cli_IP);
                };

                ws.OnMessage += (sender, e) =>
                {
                    iterate++;
                    if (iterate == 1)
                    {
                        if (e.Data.Contains("true"))
                        {
                            result = true;
                        }
                        else
                        {
                            updateInvokedTextbox(e.Data);
                        }
                    }
                    if (iterate == 2)
                    {
                        if (e.Data.Contains("true"))
                        {
                            result = true;
                        }
                        else
                        {
                            updateInvokedTextbox(e.Data);
                        }

                    }
                    if (iterate == 3)
                    {
                        if (e.Data.Contains("null"))
                        {
                            result = true;
                        }
                        else
                        {
                            updateInvokedTextbox(e.Data);
                        }
                    }
                };

                ws.Connect();
                Thread.Sleep(1000);
                string message = "{\"jsonrpc\":\"2.0\",\"id\":1,\"method\":\"is_locked\",\"params\":[]}";
                ws.Send(message);
                Thread.Sleep(2000);
                if (result)
                {
                    result = false;
                    string message1 = "{\"jsonrpc\":\"2.0\",\"id\":1,\"method\":\"load_wallet_file\",\"";
                    message1 = message1 + "params\":[\"/usr/local/bin/downloads/" + usernumber + "-wallet.json\"]}";
                    ws.Send(message1);
                    Thread.Sleep(2000);
                }
                else
                {
                    iterate--;
                    result = false;
                    string lock_message = "{\"jsonrpc\":\"2.0\",\"id\":1,\"method\":\"lock\",\"params\":[]}";
                    ws.Send(lock_message);
                    Thread.Sleep(2000);

                    result = false;
                    string message1 = "{\"jsonrpc\":\"2.0\",\"id\":1,\"method\":\"load_wallet_file\",\"";
                    message1 = message1 + "params\":[\"/usr/local/bin/downloads/" + usernumber + "-wallet.json\"]}";
                    ws.Send(message1);
                    Thread.Sleep(2000);
                }
                if (result)
                {
                    result = false;
                    string message2 = "{\"jsonrpc\":\"2.0\",\"id\":1,\"method\":\"unlock\",\"";
                    message2 = message2 + "params\":[\"" + textBox_Password.Text.Trim() + "\"]}";
                    ws.Send(message2);
                    Thread.Sleep(2000);
                }
                if (result)
                {
                    updateInvokedTextbox("Wallet successfully loaded.");
                    GetBalance();
                }
            }
        }

        public void GetBalance()
        {
            string cli_IP = @"ws://45.32.224.108:8091";

            using (var ws = new WebSocket(cli_IP))
            {
                ws.EnableRedirection = true;
                ws.OnOpen += (sender, e) =>
                {
                    updateInvokedTextbox("Connected to " + cli_IP);
                };

                ws.OnMessage += (sender, e) =>
                {
                    if (e.Data == "{\"id\":1,\"result\":[]}")
                    {
                        updateInvokedTextbox("Wallet Balance = 0 DCT");
                    }
                    else if (e.Data.Contains("pretty_amount"))
                    {
                        string[] parse = e.Data.Split(',');
                        List<string> balances = new List<string>();
                        foreach (string s in parse)
                        {
                            if (s.Contains("pretty_amount"))
                            {
                                string cleanup = s.Remove(0, 17);
                                cleanup = cleanup.Replace("\"", "");
                                cleanup = cleanup.Replace("}", "");
                                cleanup = cleanup.Replace("]", "");
                                balances.Add(cleanup);
                            }
                            foreach (string st in balances)
                            {
                                updateInvokedTextbox("Wallet Balance = " + st);
                            }
                            if (balances.Count != 0)
                            {
                                SendTransaction();
                            }
                        }
                    }
                    else
                    {
                        updateInvokedTextbox(e.Data);
                    }
                };

                string jsonText = "";
                try
                {
                    var fileStream = new FileStream(textBox_walletFile.Text, FileMode.Open, FileAccess.Read);
                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                    {
                        jsonText = streamReader.ReadToEnd();
                    }

                    string[] jsonSplit = jsonText.Split(',');
                    string name = "";
                    foreach (string s in jsonSplit)
                    {
                        if (s.Contains("\"name\":"))
                        {
                            string[] temp = s.Split(':');
                            name = temp[1].Replace("\"", "");
                        }
                    }
                    ws.Connect();
                    Thread.Sleep(1000);
                    string message = "{\"jsonrpc\":\"2.0\",\"id\":1,\"method\":\"list_account_balances\",\"params\":[\"" + name + "\"]}";
                    ws.Send(message);
                    Thread.Sleep(2000);
                }
                catch
                {
                    updateInvokedTextbox("Error! Could not read wallet file.");
                }
            }
        }

        public void SendTransaction()
        {
            string cli_IP = @"ws://45.32.224.108:8091";

            int iterate = 0;
            using (var ws = new WebSocket(cli_IP))
            {
                ws.EnableRedirection = true;
                ws.OnOpen += (sender, e) =>
                {
                    updateInvokedTextbox("Connected to " + cli_IP);
                };

                ws.OnMessage += (sender, e) =>
                {
                    iterate++;
                    if (iterate == 1)
                    {
                        updateInvokedTextbox(e.Data);
                    }
                };

                string jsonText = "";
                try
                {
                    var fileStream = new FileStream(textBox_walletFile.Text, FileMode.Open, FileAccess.Read);
                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                    {
                        jsonText = streamReader.ReadToEnd();
                    }

                    string[] jsonSplit = jsonText.Split(',');
                    string name = "";
                    foreach (string s in jsonSplit)
                    {
                        if (s.Contains("\"name\":"))
                        {
                            string[] temp = s.Split(':');
                            name = temp[1].Replace("\"", "");
                        }
                    }
                    string buildTransaction = "\"" + name + "\",\"" + textBox_sendTo.Text.Trim() + "\",\"";
                    buildTransaction = buildTransaction + textBox_Amount.Text.Trim() + "\",\"DCT\",\"";
                    buildTransaction = buildTransaction + textBox_Memo.Text.Trim() + "\",true";
                    ws.Connect();
                    Thread.Sleep(1000);
                    string message = "{\"jsonrpc\":\"2.0\",\"id\":1,\"method\":\"transfer\",\"params\":[" + buildTransaction + "]}";
                    ws.Send(message);
                    Thread.Sleep(2000);
                    updateInvokedTextbox("Transaction Complete");
                }
                catch
                {
                    updateInvokedTextbox("Error! Could not read wallet file.");
                }

                string message1 = "{\"jsonrpc\":\"2.0\",\"id\":1,\"method\":\"lock\",\"params\":[]}";
                ws.Send(message1);
                Thread.Sleep(2000);
                DeleteServerWallet();
            }
        }

        public void DeleteServerWallet()
        {
            string wscatIP = @"ws://45.32.224.108:9050";
            using (var ws = new WebSocket(wscatIP))
            {
                ws.EnableRedirection = true;
                ws.OnOpen += (sender, e) =>
                {
                    updateInvokedTextbox("Connected to " + wscatIP);
                };

                ws.OnMessage += (sender, e) =>
                {
                    updateInvokedTextbox(e.Data);
                };

                ws.OnError += (sender, e) => MessageBox.Show(e.Message, "Error recieved");

                ws.Connect();
                Thread.Sleep(1000);
                string message = "DELETE-W-info?&?&?&" + usernumber;
                ws.Send(message);
                Thread.Sleep(2000);
            }
        }
    }
}






















