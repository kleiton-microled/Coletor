using System;
using System.IO;
using System.Web.Services;
using WsFotosColetor.Extensions;

namespace WsFotosColetor
{
    /// <summary>
    /// Summary description for Upload
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class Upload : System.Web.Services.WebService
    {
        private readonly Banco _banco = new Banco();

        [WebMethod]
        public string GravarFoto(
            string idWorkflowFoto, 
            string autonumCntrBl, 
            string autonumPatio, 
            string autonumCsOp, 
            string bl,
            string autonumCsrdx,
            string autonumPatiordx,
            string imagemBase64)
        {
            if (string.IsNullOrWhiteSpace(idWorkflowFoto))
                return $"ERRO - Parâmetro {nameof(idWorkflowFoto)} não informado";

            if (string.IsNullOrWhiteSpace(autonumCntrBl))
                return $"ERRO - Parâmetro {nameof(autonumCntrBl)} não informado";

            if (string.IsNullOrWhiteSpace(autonumPatio))
                return $"ERRO - Parâmetro {nameof(autonumPatio)} não informado";

            if (string.IsNullOrWhiteSpace(autonumCsOp))
                return $"ERRO - Parâmetro {nameof(autonumCsOp)} não informado";

            if (string.IsNullOrWhiteSpace(bl))
                return $"ERRO - Parâmetro {nameof(bl)} não informado";

            if (string.IsNullOrWhiteSpace(imagemBase64))
                return $"ERRO - Parâmetro {nameof(imagemBase64)} não informado";

            var diretorio_padrao = _banco.ObterDiretorioImagens();
            var nome_imagem = Guid.NewGuid().ToString().RemoverCaracteresEspeciais();
            var diretorio_arquivos = Path.Combine(diretorio_padrao, bl);
            var caminhoImagem = Path.Combine(diretorio_arquivos, $"{nome_imagem}.png");
            var imagemEmBytes = Convert.FromBase64String(imagemBase64);

            var foto = new Foto(
                idWorkflowFoto, 
                autonumCntrBl, 
                autonumPatio, 
                autonumCsOp,
                bl,
                autonumPatiordx,
                autonumCsrdx,
                nome_imagem);

            try
            {
                GravarNoDiretorio(diretorio_arquivos, caminhoImagem, imagemEmBytes);
                _banco.GravarFoto(foto);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }            

            return "OK";
        }

        public void GravarNoDiretorio(string diretorio_arquivos, string caminhoImagem, byte[] imagemEmBytes)
        {          
            try
            {
                if (!Directory.Exists(diretorio_arquivos))
                {
                    DirectoryInfo directory = Directory.CreateDirectory(diretorio_arquivos);
                }

                using (var Stream = new FileStream(caminhoImagem, FileMode.Create))
                {
                    Stream.Write(imagemEmBytes, 0, imagemEmBytes.Length);
                }
            }
            catch (DirectoryNotFoundException ex)
            {               
                throw new Exception("Arquivo não encontrado");
            }
            catch (UnauthorizedAccessException)
            {
                FileAttributes attr = (new FileInfo(diretorio_arquivos)).Attributes;
                
                var mensagem = "ERRo - Não foi possível acessar o arquivo.";

                if ((attr & FileAttributes.ReadOnly) > 0)
                    mensagem += " O arquivo é somente leitura";

                throw new Exception(mensagem);
            }
            catch (Exception ex)
            {                
                throw new Exception($"ERRo - Ocorreu um erro ao obter o arquivo. Erro: {ex.Message}");
            }
        }

        [WebMethod]
        public string ObterFoto(string imagem_id)
        {
            string etapa = "0";
            try
            {
                var dadosImagem = _banco.ObterFotoPorId(imagem_id);

                if (dadosImagem == null)
                    throw new Exception($"ERRO - Imagem {imagem_id} não encontrada!");
                etapa="0";
                var diretorio_padrao = _banco.ObterDiretorioImagens();
                etapa = "1-" + diretorio_padrao.ToString();
                var diretorio_arquivos = Path.Combine(diretorio_padrao, dadosImagem.BL);
                etapa = "2-" + diretorio_arquivos.ToString();
                var caminhoImagem = Path.Combine(diretorio_arquivos, $"{imagem_id}.png");
                etapa = "3-" + caminhoImagem.ToString();
                var imagemEmBytes = File.ReadAllBytes(caminhoImagem);
                etapa = "4- obter bytes ";

                return Convert.ToBase64String(imagemEmBytes);
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new Exception($"ERRO " + etapa + " - Ocorreu um erro ao obter o arquivo. Erro: {ex.ToString()}");             
            }
            catch (Exception ex)
            {
                throw new Exception($"ERRO " + etapa + "  - Ocorreu um erro ao obter o arquivo. Erro: {ex.ToString()}");
            }
        }

        [WebMethod]
        public string ExcluirFoto(string imagem_id)
        {
            try
            {
                var dadosImagem = _banco.ObterFotoPorId(imagem_id);

                if (dadosImagem == null)
                    throw new Exception($"ERRO - Imagem {imagem_id} não encontrada!");

                var diretorio_padrao = _banco.ObterDiretorioImagens();
                var diretorio_arquivos = Path.Combine(diretorio_padrao, dadosImagem.BL);
                var caminhoImagem = Path.Combine(diretorio_arquivos, $"{imagem_id}.png");
                
                File.Delete(caminhoImagem);
                _banco.ExcluirFoto(imagem_id);

                return "OK";
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new Exception($"ERRO - Ocorreu um erro ao obter o arquivo. Erro: {ex.ToString()}");
            }
            catch (Exception ex)
            {
                throw new Exception($"ERRO - Ocorreu um erro ao obter o arquivo. Erro: {ex.ToString()}");
            }
        }
    }
}
