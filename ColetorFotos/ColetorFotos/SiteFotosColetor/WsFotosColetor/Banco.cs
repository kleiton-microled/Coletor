using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Linq;

namespace WsFotosColetor
{
    public class Banco
    {
        public string ObterDiretorioImagens()
        {
            using (OracleConnection con = new OracleConnection(Configs.StringConexao()))
            {                
                return con.Query<string>("SELECT DIR_COLETOR_FOTOS FROM SGIPA.TB_PARAMETROS_SISTEMA").FirstOrDefault();
            }
        }
        public void GravarFoto(Foto foto)
        {
            using (OracleConnection con = new OracleConnection(Configs.StringConexao()))
            {
                var parametros = new DynamicParameters();

                parametros.Add("ID_WORKFLOW_FOTO", value: foto.ID_WORKFLOW_FOTO, direction: ParameterDirection.Input);
                parametros.Add("AUTONUM_CNTR_BL", value: foto.AUTONUM_CNTR_BL, direction: ParameterDirection.Input);
                parametros.Add("AUTONUM_PATIO", value: foto.AUTONUM_PATIO, direction: ParameterDirection.Input);
                parametros.Add("AUTONUM_CS_OP", value: foto.AUTONUM_CS_OP, direction: ParameterDirection.Input);                
                parametros.Add("BL", value: foto.BL, direction: ParameterDirection.Input);
                parametros.Add("AUTONUM_PATIO_RDX", value: foto.AUTONUM_PATIO_RDX, direction: ParameterDirection.Input);
                parametros.Add("AUTONUM_CS_RDX", value: foto.AUTONUM_CS_RDX, direction: ParameterDirection.Input);
                parametros.Add("IMAGEM_ID", value: foto.IMAGEM_ID, direction: ParameterDirection.Input);

                con.Execute(@"INSERT INTO SGIPA.TB_FOTO_PROCESSO (ID, ID_WORKFLOW_FOTO, AUTONUM_CNTR_BL, AUTONUM_PATIO, AUTONUM_CS_OP, BL, AUTONUM_PATIO_RDX, AUTONUM_CS_RDX,DT_UPLOAD, IMAGEM_ID) 
                    VALUES (SGIPA.SEQ_FOTO_PROCESSO.NEXTVAL, :ID_WORKFLOW_FOTO, :AUTONUM_CNTR_BL, :AUTONUM_PATIO, :AUTONUM_CS_OP, :BL, :AUTONUM_PATIO_RDX, :AUTONUM_CS_RDX, SYSDATE, :IMAGEM_ID)", parametros);
            }
        }

        public Foto ObterFotoPorId(string imagem_id)
        {
            using (OracleConnection con = new OracleConnection(Configs.StringConexao()))
            {
                var parametros = new DynamicParameters();
                parametros.Add("imagem_id", value: imagem_id, direction: ParameterDirection.Input);

                return con.Query<Foto>(@"SELECT ID, ID_WORKFLOW_FOTO, AUTONUM_CNTR_BL, AUTONUM_PATIO, AUTONUM_CS_OP, BL, AUTONUM_PATIO_RDX, AUTONUM_CS_RDX, ID_FOTO_SHAREPOINT, DT_UPLOAD, IMAGEM_ID FROM SGIPA.TB_FOTO_PROCESSO WHERE IMAGEM_ID = :imagem_id", parametros).FirstOrDefault();
            }
        }
        public void ExcluirFoto(string imagem_id)
        {
            using (OracleConnection con = new OracleConnection(Configs.StringConexao()))
            {
                var parametros = new DynamicParameters();
                parametros.Add("imagem_id", value: imagem_id, direction: ParameterDirection.Input);

                con.Execute(@"DELETE FROM SGIPA.TB_FOTO_PROCESSO WHERE IMAGEM_ID = :imagem_id", parametros);
            }
        }
    }
}