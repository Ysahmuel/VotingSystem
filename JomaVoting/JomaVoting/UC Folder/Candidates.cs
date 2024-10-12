using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JomaVoting
{
    public partial class Candidates : UserControl
    {
        public Candidates()
        {
            InitializeComponent();
        }

        private void btnAddCandidate_Click(object sender, EventArgs e)
        {
            AddCandidate addCandidate = new AddCandidate();
            addCandidate.Show();
        }
    }
}
