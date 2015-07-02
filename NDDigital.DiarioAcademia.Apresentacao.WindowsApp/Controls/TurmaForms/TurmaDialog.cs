using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using System;
using System.Windows.Forms;

namespace NDDigital.DiarioAcademia.Apresentacao.WindowsApp.Controls.TurmaForms
{
    public partial class TurmaDialog : Form
    {
        private TurmaDTO _turma;

        public TurmaDialog()
        {
            InitializeComponent();
        }

        public TurmaDTO Turma
        {
            get
            {
                return _turma;
            }
            set
            {
                _turma = value;

                txtId.Text = _turma.Id.ToString();

                cmbTurmas.Text = _turma.Ano.ToString();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                _turma.Id = int.Parse(txtId.Text);

                _turma.Ano = int.Parse(cmbTurmas.Text);
            }
            catch (Exception exc)
            {
                Principal.Instance.ShowErrorInFooter(exc.Message);

                DialogResult = DialogResult.None;
            }
        }
    }
}