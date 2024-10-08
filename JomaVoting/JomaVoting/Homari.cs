using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JomaVote
{
    public partial class Homari : Form
    {
        public Homari()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            LoadPage(new JomaVoting.Home());
        }

        private void Homari_Load(object sender, EventArgs e)
        {
            LoadPage(new JomaVoting.Home());
        }
        private void LoadPage(UserControl page)
        {
            pnlMain.Controls.Clear(); // Clear the panel
            page.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(page);
        }

        private void btnParty_Click(object sender, EventArgs e)
        {
            LoadPage(new JomaVoting.Party());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVoting_Click(object sender, EventArgs e)
        {
            LoadPage(new JomaVoting.Voting());
        }
    }
}
