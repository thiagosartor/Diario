using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Contexts;

namespace NDDigital.DiarioAcademia.Apresentacao.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DiarioAcademiaContext context = new DiarioAcademiaContext();

            context.Turmas.Add(new Turma(2100));

            context.SaveChanges();
        }
    }
}