﻿using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Repositories
{
    public class AlunoRepository : RepositoryBase<Aluno>, IAlunoRepository
    {
        public AlunoRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }

        public IEnumerable<Aluno> GetAllByTurma(int ano)
        {
            return GetQueryable()
                .Include(x => x.Turma)
                .Include(x => x.Presencas)
                .Where(x => x.Turma.Ano == ano)
                .ToList();
        }

        public override IEnumerable<Aluno> GetAll()
        {
            return GetQueryable()
                .Include(x => x.Turma)
                .Include(x => x.Presencas)
                .ToList();
        }

        public override Aluno GetById(int id)
        {
            var aluno = GetQueryable()
               .Include(x => x.Turma)
               .Include(x => x.Presencas)
               .FirstOrDefault(x => x.Id == id);

            return aluno;
        }

        public IEnumerable<Aluno> GetAllByTurmaId(int id)
        {
            return GetQueryable()
                    .Include(x => x.Turma)
                    .Include(x => x.Presencas)
                    .Where(x => x.Turma.Id == id)
                    .ToList();
        }
    }
}