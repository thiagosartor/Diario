using Xunit;

namespace NDDigital.DiarioAcademia.UnitTests.Traits
{
    public class DominioTrait : TraitAttribute
    {
        public DominioTrait(string value)
            : base("Camada do Domínio", value)
        {
        }
    }
}