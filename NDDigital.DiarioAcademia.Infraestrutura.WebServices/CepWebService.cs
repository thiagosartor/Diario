﻿using NDDigital.DiarioAcademia.Dominio;
using System.Xml.Linq;

namespace NDDigital.DiarioAcademia.Infraestrutura.WebServices
{
    public class CepWebService
    {
        private const string WebserviceUrl = "http://viacep.com.br/ws/@cep/@format/";

        public Endereco PreencheEndereco(string cep, string format = "xml")
        {
            var url = WebserviceUrl
                            .Replace("@cep", cep)
                            .Replace("@format", format);
            var xml = XElement.Load(url);

            var endereco = new Endereco();

            endereco.Cep = xml.Element("cep").Value;
            endereco.Bairro = xml.Element("bairro").Value;
            endereco.Localidade = xml.Element("localidade").Value;
            endereco.Uf = xml.Element("uf").Value;

            return endereco;
        }
    }
}