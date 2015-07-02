using Xunit;

namespace NDDigital.DiarioAcademia.IntegrationTests.Traits
{
    public class RepositorioTrait : TraitAttribute
    {
        public RepositorioTrait(string name = "")
            : base("Camada de Infraestrutura de Dados", "")
        {
        }
    }
}