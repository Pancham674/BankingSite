using System.Data;
using System.Windows.Forms;

namespace BankingSite
{
    public partial class AssociatedDataTables : Form
    {
        public AssociatedDataTables(DataTable data)
        {
            InitializeComponent();

            dgvAssosiatedDataTable.DataSource = data;
            dgvAssosiatedDataTable.Refresh();
        }

		private void AssociatedDataTables_Load(object sender, System.EventArgs e)
		{
			CenterToParent();
		}
	}
}