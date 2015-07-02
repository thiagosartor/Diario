﻿using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NDDigital.DiarioAcademia.Apresentacao.WindowsApp.Controls.AulaForms
{
    public partial class AulaDialog : Form
    {
        private AulaDTO _aula;

        public AulaDialog(IEnumerable<TurmaDTO> turmas)
        {
            InitializeComponent();

            cmbTurmas.Items.Clear();

            foreach (var turma in turmas)
            {
                cmbTurmas.Items.Add(turma);
            }
        }

        public Aplicacao.DTOs.AulaDTO Aula
        {
            get
            {
                return _aula;
            }
            set
            {
                _aula = value;

                txtId.Text = _aula.Id.ToString();

                cmbTurmas.SelectedItem = new TurmaDTO(_aula.AnoTurma);

                cmbData.Value = _aula.DataAula;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                _aula.Id = int.Parse(txtId.Text);

                _aula.DataAula = cmbData.Value;

                _aula.AnoTurma = ((TurmaDTO)cmbTurmas.SelectedItem).Id;
            }
            catch (Exception exc)
            {
                Principal.Instance.ShowErrorInFooter(exc.Message);

                DialogResult = DialogResult.None;
            }
        }
    }
}