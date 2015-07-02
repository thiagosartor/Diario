﻿using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Apresentacao.WindowsApp.Controls.AlunoForms;
using NDDigital.DiarioAcademia.Apresentacao.WindowsApp.Controls.AulaForms;
using NDDigital.DiarioAcademia.Apresentacao.WindowsApp.Controls.Shared;
using NDDigital.DiarioAcademia.Apresentacao.WindowsApp.Controls.TurmaForms;
using NDDigital.DiarioAcademia.Apresentacao.WindowsApp.Properties;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NDDigital.DiarioAcademia.Apresentacao.WindowsApp
{
    public partial class Principal : Form
    {
        private static Principal _instance;
        private DataManager _dataManager;
        private UserControl _control;

        private ITurmaService _turmaService; 
        private IAlunoService _alunoService;

        private IEnumerable<TurmaDTO> turmas;

        public Principal()
        {
            InitializeComponent();

            _instance = this;

            var factory = new DatabaseFactory();

            var unitOfWork = new UnitOfWork(factory);

            var turmaRepository = new TurmaRepository(factory);

            var alunoRepository = new AlunoRepository(factory);

            _turmaService = new TurmaService(turmaRepository, unitOfWork);

            _alunoService = new AlunoService(alunoRepository, turmaRepository, unitOfWork);

            AtualizaListaTurmas();

            SelecionaTurmaAnoAtual();
        }

        private void SelecionaTurmaAnoAtual()
        {
            TurmaDTO turmaSelecionada = turmas.FirstOrDefault(x => x.Ano == DateTime.Now.Year);

            if (turmaSelecionada != null)
                cmbTurmas.SelectedItem = turmaSelecionada;
        }

        public static Principal Instance
        {
            get
            {
                return _instance;
            }
        }

        public int AnoTurmaSelecionado
        {
            get
            {
                var turmaSelecionada = cmbTurmas.SelectedItem as TurmaDTO;

                if (turmaSelecionada == null) return 0;

                return turmaSelecionada.Ano;
            }
        }

        public void ShowErrorInFooter(string message)
        {
            statusMessage.Text = message;
            statusImage.Image = Resources.Symbol_Error_3;
        }

        public void ShowSucessInFooter(string message)
        {
            statusMessage.Text = message;
            statusImage.Image = Resources.Symbol_Check;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _dataManager.AddData();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                _dataManager.DeleteData();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                _dataManager.UpdateData();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnRegistraPresenca_Click(object sender, EventArgs e)
        {
            try
            {
                _dataManager.RealizaChamada();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        /// <summary>
        /// O Método LoadDataManager() é responsável por definir o contexto de cadastro da tela principal,
        /// ou seja, quando o usuário seleciona uma opção da barra de menu, esta operação carrega o UserControl
        /// correspondente, atualiza o título da janela e também os Tooltips dos botões.
        /// </summary>
        /// <param name="manager"></param>
        private void LoadDataManager(DataManager manager)
        {
            try
            {
                if (_dataManager != null && _dataManager.GetType() == manager.GetType())
                    return;

                if (_control != null)
                {
                    panelPrincipal.Controls.Clear();
                }

                statusImage.Image = null;
                statusMessage.Text = "";

                _dataManager = manager;

                _control = _dataManager.GetControl();

                _control.Dock = DockStyle.Fill;

                panelPrincipal.Controls.Add(_control);

                labelTipoCadastro.Text = "Operação selecionada: " + _dataManager.GetDescription();

                btnAdd.ToolTipText = _dataManager.GetToolTipMessage().Add;
                btnRegistraPresenca.ToolTipText = _dataManager.GetToolTipMessage().RegistraPresenca;
                btnUpdate.ToolTipText = _dataManager.GetToolTipMessage().Edit;
                btnRelatorio.ToolTipText = _dataManager.GetToolTipMessage().Report;

                btnAdd.Enabled = _dataManager.GetStateButtons().Add;
                btnRegistraPresenca.Enabled = _dataManager.GetStateButtons().RegistraPresenca;
                btnUpdate.Enabled = _dataManager.GetStateButtons().Update;
                btnRelatorio.Enabled = _dataManager.GetStateButtons().Report;

                toolbar.Enabled = _dataManager != null;
            }
            catch (Exception be)
            {
                MessageBox.Show(be.Message);
            }
        }

        private void alunosMenuItem_Click(object sender, EventArgs e)
        {
            LoadDataManager(new AlunoDataManager());
        }

        private void turmasMenuItem_Click(object sender, EventArgs e)
        {
            LoadDataManager(new TurmaDataManager());
        }

        private void aulasMenuItem_Click(object sender, EventArgs e)
        {
            LoadDataManager(new AulaDataManager());
        }

        public void AtualizaListaTurmas()
        {
            turmas = _turmaService.GetAll();

            cmbTurmas.Items.Clear();

            foreach (var turma in turmas)
            {
                cmbTurmas.Items.Add(turma);
            }
        }

        private void cmbTurmas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_control == null)
            {
                return;
            }

            panelPrincipal.Controls.Clear();

            _control = _dataManager.GetControl();

            _control.Dock = DockStyle.Fill;

            panelPrincipal.Controls.Add(_control);
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            var turmaSelecionada = cmbTurmas.SelectedItem as TurmaDTO;
            var ano = turmaSelecionada.Ano;

            DialogResult dialogResult = MessageBox.Show("Você gostaria de gerar um novo relatório da " +
                                                        "Academia do Programador "+ ano +"?", "Atenção", MessageBoxButtons.YesNo);
            
            if (dialogResult == DialogResult.Yes)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Filter = "PDF|*.pdf";
                saveFileDialog.Title = "Salvando relatório";
                saveFileDialog.FileName = "Relatório Academia do Programador " + ano;
                saveFileDialog.ShowDialog();

                _alunoService.GerarRelatorioAlunosPdf(turmaSelecionada.Ano, saveFileDialog.FileName);
            }
        }
    }
}