using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PcapDotNet.Core;
using PcapDotNet.Core.Extensions;
using PcapDotNet.Packets;
using PcapDotNet.Packets.IpV4;

namespace pktReader
{
    public partial class Form1 : Form
    {
        private OfflinePacketDevice _device;
        private List<DataPacket> _lobbyPackets;
        private const int _lineLength = 64;
        private string _buffer;
        private int _pktCount, _counter;
        private String[] arr;
        private SubPacketWindow win;

        public Form1()
        {
            InitializeComponent();
            tabControl.Visible = false;
            _buffer = "";
            _lobbyPackets = new List<DataPacket>();
            tabControl.VisibleChanged += new EventHandler(this.tabControlVisibilityChanged);
            pktDataBox.ReadOnly = true;
            progressBar1.Maximum = 1000;
            progressBar1.Minimum = 0;
            _pktCount = 0;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openCaptureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "PCAP files (*.pcap)|*.pcap";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openDialog.FileName;
                //Console.WriteLine(filePath);
                _device = new OfflinePacketDevice(filePath);
                PacketCommunicator com = _device.Open(65536, PacketDeviceOpenAttributes.Promiscuous, 1000);
                do
                {
                    com.ReceiveSomePackets(out _counter, 1, PacketHandler);
                }
                while (_pktCount <= 50);
                progressBar1.Value = progressBar1.Maximum;
                tabControl.Visible = true;
            }
        }

        private void PacketHandler(Packet packet)
        {
            this.Text = "GITS:FA Packet Reader      Packets Read: " + _pktCount;
            Application.DoEvents();
            IpV4Datagram ip = packet.Ethernet.IpV4;
            if (ip.Tcp != null)
            {
                var lobbyPort = false;
                var client = 0;
                if (ip.Tcp.SourcePort.Equals(27380))
                {
                    lobbyPort = true;
                }
                else if (ip.Tcp.DestinationPort.Equals(27380))
                {
                    lobbyPort = true;
                    client = 1;
                }
                if (lobbyPort && ip.Tcp.PayloadLength > 0)
                { 
                    for (int i = 0; i != ip.Tcp.Payload.Length; ++i)
                    {
                        _buffer += ip.Tcp.Payload[i].ToString("X2");
                    }
                        var header = _buffer.Substring(0, 4);
                        if (header.Equals(DataPacket._PKTHEADER))
                        {
                            var time = packet.Timestamp.ToLongDateString() + " " + packet.Timestamp.ToLongTimeString();
                            _lobbyPackets.Add(new DataPacket(ip.Source.ToString(), ip.Destination.ToString(), _buffer, ip.Tcp.PayloadLength, time, _pktCount));
                            _buffer = "";
                            _lobbyPackets[_pktCount].setIfClient(client);
                            _pktCount++;
                            
                            progressBar1.Value = _pktCount;
                        }
                        else
                        {
                            var count = _pktCount - 1;
                            if (count < 0)
                                count = 0;

                            _lobbyPackets[count]._data += _buffer;
                            _lobbyPackets[count]._pktSize += ip.Tcp.PayloadLength;
                            _buffer = "";
                        }
                }
            }
            

        }

        private void tabControlVisibilityChanged(object sender, EventArgs e)
        {
            if (tabControl.Visible)
            {
                lobbyPacketList.BeginUpdate();
                progressBar1.Maximum = _lobbyPackets.Count;
                progressBar1.Value = progressBar1.Maximum / 2;
                lobbyPacketList.DataSource = _lobbyPackets;
                lobbyPacketList.DisplayMember = "Timestamp";
                lobbyPacketList.ValueMember = "PacketNumber";
                lobbyPacketList.EndUpdate();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            String[] sep = { "1357" };

            arr = _lobbyPackets[lobbyPacketList.SelectedIndex]._data.Split(sep, StringSplitOptions.RemoveEmptyEntries);
           
            win = new SubPacketWindow(arr);
            win.FormClosed += otherWindowClosed;
            win.Show();
        }

        private void otherWindowClosed(object sender, EventArgs e)
        {
            win.Dispose();
            win = null;
        }

        private void lobbyPacketList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lobbyPacketList.SelectedIndex != -1)
            {
                sourceLabel.Text = _lobbyPackets[lobbyPacketList.SelectedIndex]._sourceIp;
                destLabel.Text = _lobbyPackets[lobbyPacketList.SelectedIndex]._destIp;
                sizeLabel.Text = _lobbyPackets[lobbyPacketList.SelectedIndex]._pktSize.ToString();
                pktDataBox.Text = _lobbyPackets[lobbyPacketList.SelectedIndex]._data;
            }
        }
    }
}
