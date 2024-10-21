
using System.Drawing;

namespace JomaVoting
{
    public partial class AdminHomari : Form
    {
        public AdminHomari()
        {
            InitializeComponent();
        }

        private void LoadPage(UserControl page)
        {
            pnlMain.Controls.Clear(); 
            page.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(page);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadPage(new JomaVoting.Dashboard());
        }

        private void btnVotes_Click(object sender, EventArgs e)
        {
            LoadPage(new JomaVoting.Votes());
        }

        private void btnVoters_Click(object sender, EventArgs e)
        {
            LoadPage(new JomaVoting.Voters());
        }

        private void btnPositions_Click(object sender, EventArgs e)
        {
            LoadPage(new JomaVoting.Positions());
        }

        private void btnCandidates_Click(object sender, EventArgs e)
        {
            LoadPage(new JomaVoting.Candidates());
        }

        private void formsPlot1_Load(object sender, EventArgs e)
        {

        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadPage(new JomaVoting.Dashboard());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
