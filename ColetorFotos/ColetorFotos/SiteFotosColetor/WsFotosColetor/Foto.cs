namespace WsFotosColetor
{
    public class Foto
    {
        public Foto()
        {

        }

        public Foto(string id_workflow_foto, string autonum_cntr_bl, string autonum_patio, string autonum_cs_op, string bl, string autonum_patio_rdx, string autonum_cs_rdx, string imagem_id)
        {
            ID_WORKFLOW_FOTO = id_workflow_foto;
            AUTONUM_CNTR_BL = autonum_cntr_bl;
            AUTONUM_PATIO = autonum_patio;
            AUTONUM_CS_OP = autonum_cs_op;
            BL = bl;
            AUTONUM_PATIO_RDX = autonum_patio_rdx;
            AUTONUM_CS_RDX = autonum_cs_rdx;
            IMAGEM_ID = imagem_id;
        }

        public string ID { get; set; }

        public string ID_WORKFLOW_FOTO { get; set; }

        public string AUTONUM_CNTR_BL { get; set; }

        public string AUTONUM_PATIO { get; set; }

        public string AUTONUM_CS_OP { get; set; }

        public string BL { get; set; }
        public string AUTONUM_PATIO_RDX { get; set; }

        public string AUTONUM_CS_RDX { get; set; }

        public string IMAGEM_ID { get; set; }

        public string IMAGEM_BASE_64 { get; set; }        
    }
}