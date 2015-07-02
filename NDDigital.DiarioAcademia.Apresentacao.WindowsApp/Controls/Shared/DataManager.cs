using System.Windows.Forms;

namespace NDDigital.DiarioAcademia.Apresentacao.WindowsApp.Controls.Shared
{
    public abstract class DataManager
    {
        /// <summary>
        /// � respons�vel por chamar o di�logo de inser��o, caso o usu�rio confirme o cadastro clicando em ok,
        /// esta fun��o chama o m�todo na camada de servi�o respons�vel pela inser��o de um novo registro.
        /// Este m�todo � chamado no formul�rio Principal, dentro do evento btnAdd_click
        /// </summary>
        public abstract void AddData();

        /// <summary>
        /// � respons�vel por chamar o di�logo de exclus�o, caso o usu�rio confirme clicando em ok,
        /// esta fun��o chama o m�todo na camada de servi�o respons�vel pela exclus�o de um registro existente na base de dados.
        /// Este m�todo � chamado no formul�rio Principal, dentro do evento btnDelete_Click
        /// </summary>
        public abstract void DeleteData();

        /// <summary>
        /// � respons�vel por chamar o di�logo de atualiza��o, caso o usu�rio confirme clicando em ok,
        /// esta fun��o chama o m�todo na camada de servi�o respons�vel pela altera��o das informa��es de um registro
        /// existente na base de dados.
        /// Este m�todo � chamado no formul�rio Principal, dentro do evento btnEdit_Click
        /// </summary>
        public abstract void UpdateData();

        /// <summary>
        /// � respons�vel por chamar o di�logo de exclus�o, caso o usu�rio confirme clicando em ok,
        /// esta fun��o chama o m�todo na camada de servi�o respons�vel pela exclus�o de um registro existente na base de dados.
        /// Este m�todo � chamado no formul�rio Principal, dentro do evento btnDelete_Click
        /// </summary>
        public abstract UserControl GetControl();

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public abstract string GetDescription();

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public abstract ToolTipMessage GetToolTipMessage();

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public abstract StateButtons GetStateButtons();

        /// <summary>
        ///
        /// </summary>
        public virtual void RealizaChamada()
        {
        }
    }
}