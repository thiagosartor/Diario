using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using System.Windows.Forms;

namespace NDDigital.DiarioAcademia.Apresentacao.WindowsApp.Controls.AulaForms
{
    public partial class AulaControl : UserControl
    {
        private Aplicacao.Services.IAulaService _aulaService;

        public AulaControl()
        {
            InitializeComponent();
        }

        public AulaControl(Aplicacao.Services.IAulaService aulaService)
            : this()
        {
            this._aulaService = aulaService;
        }

        internal void RefreshGrid()
        {
            int anoTurma = Principal.Instance.AnoTurmaSelecionado;

            var aulas = _aulaService.GetAllByTurma(anoTurma);

            listAulas.Items.Clear();

            foreach (var aula in aulas)
            {
                listAulas.Items.Add(aula);
            }
        }

        internal Aplicacao.DTOs.AulaDTO GetAulaSelecionada()
        {
            AulaDTO aulaSelecionada = listAulas.SelectedItem as AulaDTO;

            return aulaSelecionada;
        }
    }
}