﻿using NDDigital.DiarioAcademia.Dominio.Common;
using System.Collections.Generic;
using System.Linq;

namespace NDDigital.DiarioAcademia.Dominio
{
    public class Aluno : Entity
    {
        private Aluno()
        {
            Presencas = new List<Presenca>();
            Endereco = new Endereco();
        }

        public Aluno(string nome, Turma turma)
            : this()
        {
            this.Nome = nome;
            this.Turma = turma;
        }

        public Endereco Endereco { get; set; }

        public string Nome { get; set; }

        public virtual Turma Turma { get; set; }

        public virtual List<Presenca> Presencas { get; set; }

        public int ObtemQuantidadePresencas()
        {
            return Presencas.Count(x => x.StatusPresenca == "C");
        }

        public int ObtemQuantidadeAusencias()
        {
            return Presencas.Count(x => x.StatusPresenca == "F");
        }

        public void RegistraPresenca(Aula aula, string statusPresenca)
        {
            Presenca presenca = null;

            if (TemPresencaRegistrada(aula, out presenca))
            {
                presenca.StatusPresenca = statusPresenca;
            }
            else
            {
                presenca = new Presenca(aula, this, statusPresenca);

                Presencas.Add(presenca);
            }
        }

        private bool TemPresencaRegistrada(Aula aula, out Presenca presenca)
        {
            presenca = Presencas.FirstOrDefault(x => x.Aula.Equals(aula));

            return presenca != null;
        }

        public override string ToString()
        {
            return string.Format("{0}: Presenças: {1}, Faltas: {2}", Nome, ObtemQuantidadePresencas(), ObtemQuantidadeAusencias());
        }
    }

    public interface IAlunoRepository : IRepository<Aluno>
    {
        IEnumerable<Aluno> GetAllByTurma(int ano);
        IEnumerable<Aluno> GetAllByTurmaId(int id);
    }
}