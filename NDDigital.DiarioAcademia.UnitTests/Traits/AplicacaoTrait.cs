using Xunit;

namespace NDDigital.DiarioAcademia.UnitTests.Traits
{
    public class AplicacaoTrait : TraitAttribute
    {
        public AplicacaoTrait(string value)
            : base("Camada de Aplicação", value)
        {
        }
    }
}