﻿using FluentAssertions;
using NDDigital.DiarioAcademia.Dominio;
using System;
using NDDigital.DiarioAcademia.UnitTests.Traits;
using Xunit;

namespace NDDigital.DiarioAcademia.UnitTests.Dominio
{
    [DominioTrait("")]
    public class PresencaTests
    {
        private Presenca presenca;

        public PresencaTests()
        {
            Aula aula = ObjectMother.CriaUmaAula();
            aula.Data = new DateTime(2000, 10, 5);

            Turma turma = new Turma(2012);

            presenca = new Presenca(aula, new Aluno("Marco Antônio", turma), "F");
        }

        [Fact(DisplayName = "Deveria retornar a data, nome do aluno e status da presença")]
        public void Test_1()
        {
            presenca.ToString().Should().Contain("05/10/2000: Marco Antônio -> Faltou");
        }
    }
}