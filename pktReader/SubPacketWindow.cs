using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pktReader
{
    public partial class SubPacketWindow : Form
    {

        private List<SubPacket> pkts;
        public SubPacketWindow(String[] input)
        {
            pkts = new List<SubPacket>();
            var counter = 1;
            foreach (String str in input)
            {
                pkts.Add(new SubPacket(str, counter.ToString()));
                counter++;
            }
            InitializeComponent();
            subTextBox.ReadOnly = true;
            subPacketList.BeginUpdate();
            subPacketList.DataSource = pkts;
            subPacketList.DisplayMember = "Title";
            subPacketList.ValueMember = "Data";
            subPacketList.EndUpdate();
        }

        internal List<SubPacket> Pkts { get => pkts; set => pkts = value; }

        public void updateListing(object sender, EventArgs e)
        {
            subPacketList.BeginUpdate();
            subPacketList.DataSource = pkts;
            subPacketList.DisplayMember = "Title";
            subPacketList.ValueMember = "Data";
            subPacketList.EndUpdate();
        }

        private void subPacketList_SelectedIndexChanged(object sender, EventArgs e)
        {
            subPacketCodeLabel.Text = pkts[subPacketList.SelectedIndex].determineOpCode(pkts[subPacketList.SelectedIndex].determineSize(pkts[subPacketList.SelectedIndex].Data));
            subTextBox.Text = pkts[subPacketList.SelectedIndex].Data;
        }
    }
}
