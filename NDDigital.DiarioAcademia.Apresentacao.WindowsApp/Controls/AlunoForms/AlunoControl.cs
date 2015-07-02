using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using NDDigital.DiarioAcademia.Aplicacao.Services;
using System.Windows.Forms;

namespace NDDigital.DiarioAcademia.Apresentacao.WindowsApp.Controls.AlunoForms
{
    public partial class AlunoControl : UserControl
    {
        private IAlunoService _alunoService;

        public AlunoControl()
        {
            InitializeComponent();
        }

        public AlunoControl(IAlunoService _service)
            : this()
        {
            this._alunoService = _service;
        }

        public AlunoDTO GetAluno()
        {
            AlunoDTO alunoSelecionado = listAlunos.SelectedItem as AlunoDTO;

            alunoSelecionado = _alunoService.GetById(alunoSelecionado.Id);

            return alunoSelecionado;
        }

        public void RefreshGrid()
        {
            int anoTurma = Principal.Instance.AnoTurmaSelecionado;

            var alunos = _alunoService.GetAllByTurma(anoTurma);

            listAlunos.Items.Clear();

            foreach (var aluno in alunos)
            {
                listAlunos.Items.Add(aluno);
            }
        }
    }
}