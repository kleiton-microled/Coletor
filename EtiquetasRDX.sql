--DROP TABLE REDEX.TB_MARCANTES_RDX;

CREATE TABLE REDEX.TB_MARCANTES_RDX
(
  AUTONUM          NUMBER(12)                   NOT NULL,
  DT_IMPRESSAO     DATE,
  DT_ASSOCIACAO    DATE,
  AUTONUM_PCS      NUMBER(10)                   DEFAULT 0                     NOT NULL,
  VOLUMES          NUMBER(6)                    DEFAULT 0                     NOT NULL,
  AUTONUM_CS_YARD  NUMBER(8)                    DEFAULT 0                     NOT NULL,
  REFERENCE        VARCHAR2(20) ,
  ETQ_PRATELEIRA   VARCHAR2(9 BYTE),
  ARMAZEM          NUMBER(4)                    DEFAULT 0                     NOT NULL,
  YARD             VARCHAR2(15 BYTE),
  PLACA_C          VARCHAR2(8 BYTE),
  STR_CODE128      VARCHAR2(30 BYTE),
  AUTONUM_BOO      NUMBER(10) DEFAULT 0 NOT NULL,
  AUTONUM_REGCS    NUMBER(10) DEFAULT 0 NOT NULL,
  FLAG_REGISTRO	   NUMBER(1) DEFAULT 0 NOT NULL,
  AUTONUM_TALIE    NUMERIC(8) DEFAULT 0 NOT NULL,
  AUTONUM_TI NUMBER(10) DEFAULT 0 NOT NULL
);


grant select on redex.tb_marcantes_rdx to operador with grant option;


CREATE OR REPLACE VIEW operador.vw_invent_armazem_carga_rdx (autonum_armazem,
                                                                   descr_armazem,
                                                                   id_patio,
                                                                   flag_ct,
                                                                   qtde,
                                                                   marca,
                                                                   data_entrada,
                                                                   peso,
                                                                   volume,
                                                                   posicao,
                                                                   id_gravacao,
                                                                   imo,
                                                                   qtde_captada,
                                                                   autonumcs,
                                                                   tipo,
                                                                   autonum_boo,
                                                                   autonum_pro,
                                                                   autonum_emb,
                                                                   marcante,
                                                                   autonum_cs_yard
                                                                  )
AS
  SELECT armazem, descr, patio, flag_ct, quantidade, marca,
         dt_entrada, peso_bruto, volume, posicao, id_gravacao, imo,
         qtde_captada, autonumcs, tipo, autonum_boo, autonum_pro, autonum_emb, marcante, autonum_cs_yard
    FROM (SELECT i.autonum AS armazem, i.descr, a.patio, i.flag_ct,
                   a.qtde_entrada
                 - NVL ((SELECT SUM (qtde_saida)
                           FROM redex.tb_saida_carga w
                          WHERE w.autonum_pcs = a.autonum_pcs), 0)
                 - NVL ((SELECT SUM (quantidade)
                           FROM redex.tb_carga_solta_yard kk
                          WHERE kk.autonum_patiocs = a.autonum_pcs), 0)
                 
                          
                                                                     AS quantidade,
                 a.marca, a.dt_prim_entrada AS dt_entrada,
                 a.bruto AS peso_bruto, a.volume_declarado AS volume,
                 '-' AS posicao,
                 'C' || LTRIM (TO_CHAR (a.autonum_pcs)) AS id_gravacao, a.imo,
                 a.qtde_entrada AS qtde_captada, a.autonum_pcs AS autonumcs,
                 'SEM MC SEM POSICAO' AS tipo, d.autonum_boo, d.autonum_pro,
                 a.autonum_emb,'000000000000' as marcante,0 as autonum_cs_yard 
            FROM redex.tb_patio_cs a INNER JOIN sgipa.tb_armazens_ipa i
                 ON a.patio = i.patio
                 INNER JOIN redex.tb_booking_carga d
                 ON a.autonum_bcg = d.autonum_bcg
           WHERE d.flag_cs = 1
             AND i.flag_padrao_patio_redex = 1
             AND a.flag_historico = 0 and d.autonum_boo not in (select autonum_boo from redex.tb_marcantes_rdx)  )
             
             where  quantidade>0 
             
   
  UNION
  -- REDEX SEM MARCANTE COM POSICAO ANTIGA
  SELECT armazem, descr, patio, flag_ct, quantidade, marca, dt_entrada,
         peso_bruto, volume, posicao, id_gravacao, imo, qtde_captada,
         autonumcs, tipo, autonum_boo, autonum_pro, autonum_emb,marcante,autonum_cs_yard  
    FROM (SELECT i.autonum AS armazem, i.descr, a.patio, i.flag_ct,
                 y.quantidade,
                  
                 a.marca, a.dt_prim_entrada AS dt_entrada,
                 a.bruto AS peso_bruto, a.volume_declarado AS volume,
                 y.yard AS posicao,
                 'Y' || LTRIM (TO_CHAR (y.autonum)) AS id_gravacao, a.imo,
                 a.qtde_entrada AS qtde_captada, a.autonum_pcs AS autonumcs,
                 'SEM MC POS ANTIGA' AS tipo, d.autonum_boo, d.autonum_pro,
                 a.autonum_emb,'000000000000' as marcante,y.autonum as autonum_cs_yard  
            FROM redex.tb_patio_cs a INNER JOIN redex.tb_carga_solta_yard y
                 ON a.autonum_pcs = y.autonum_patiocs
                 left join redex.tb_marcantes_rdx rdx on y.autonum=rdx.autonum_cs_yard
                 INNER JOIN sgipa.tb_armazens_ipa i ON y.armazem = i.autonum
                 INNER JOIN redex.tb_booking_carga d
                 ON a.autonum_bcg = d.autonum_bcg
           WHERE d.flag_cs = 1 AND a.flag_historico = 0 and nvl(rdx.autonum,0)=0 and d.autonum_boo not in (select autonum_boo from redex.tb_marcantes_rdx) ) 
           WHERE QUANTIDADE>0
           -- REDEX COM MARCANTE 
  union
  SELECT armazem, descr, patio, flag_ct, quantidade, marca, dt_entrada,
         peso_bruto, volume, posicao, id_gravacao, imo, qtde_captada,
         autonumcs, tipo, autonum_boo, autonum_pro, autonum_emb,marcante,autonum_cs_yard 
    FROM (SELECT i.autonum AS armazem, i.descr, a.patio, i.flag_ct,
                 y.quantidade as quantidade ,
                 y.quantidade as saldo,
                 a.marca, a.dt_prim_entrada AS dt_entrada,
                 a.bruto AS peso_bruto, a.volume_declarado AS volume,
                 y.yard AS posicao,
                 'Y' || LTRIM (TO_CHAR (y.autonum)) AS id_gravacao, a.imo,
                 a.qtde_entrada AS qtde_captada, a.autonum_pcs AS autonumcs,
                 'COM MC ' AS tipo, d.autonum_boo, d.autonum_pro,
                 a.autonum_emb,LPAD (TRIM (TO_CHAR (NVL (m.autonum, 0))), 12, 0) as marcante,y.autonum as autonum_cs_yard 
            FROM redex.tb_patio_cs a INNER JOIN redex.tb_MARCANTES_RDX m
                 ON a.autonum_pcs = m.autonum_pcs inner join redex.tb_carga_solta_yard y on m.AUTONUM_CS_YARD=y.AUTONUM
                 LEFT JOIN sgipa.tb_armazens_ipa i ON y.armazem = i.autonum
                 INNER JOIN redex.tb_booking_carga d
                 ON a.autonum_bcg = d.autonum_bcg
           WHERE d.flag_cs = 1 AND a.flag_historico = 0) WHERE QUANTIDADE>0;
		   
		   
CREATE INDEX REDEX.IDX_MARCANTE_RDX ON REDEX.TB_MARCANTES_RDX
(AUTONUM_BOO, AUTONUM)
LOGGING
NOPARALLEL;

ALTER TABLE REDEX.TB_MARCANTES_RDX ADD 
CONSTRAINT TB_MARCANTES_RDX_PK
 PRIMARY KEY (AUTONUM)

 ENABLE
 VALIDATE;
 


CREATE OR REPLACE FORCE VIEW redex.vw_marcante_rdx (marcante,
                                                    REFERENCE,
                                                    lote,
                                                    autonum_pcs,
                                                    autonum_boo,
                                                    autonum_regcs,
                                                    exportador,
                                                    str_marcante,
                                                    classe_anvisa,
                                                    temperatura_anvisa,
                                                    dt_impressao,
                                                    str_code128
                                                   )
AS
  SELECT m.autonum, b.REFERENCE, b.os, m.autonum_pcs, m.autonum_boo,m.autonum_regcs, p.razao, LPAD (TRIM (TO_CHAR (m.autonum)), 12, 0),
         '', '', m.dt_impressao,m.str_code128
    FROM redex.tb_marcantes_rdx m
        INNER JOIN redex.tb_booking b ON m.autonum_boo = b.autonum_boo 
         INNER JOIN redex.tb_cad_parceiros p ON b.autonum_exportador =
                                                                     p.autonum;
         
         
         
         
         CREATE OR REPLACE FORCE VIEW operador.vw_invent_armazem (autonum_armazem,
                                                         descr_armazem,
                                                         id_patio,
                                                         flag_ct,
                                                         bl,
                                                         lote,
                                                         qtde,
                                                         embalagem,
                                                         mercadoria,
                                                         marca,
                                                         importador,
                                                         navio,
                                                         viagem,
                                                         data_entrada,
                                                         data_desova,
                                                         cntr_desova,
                                                         peso,
                                                         volume,
                                                         posicao,
                                                         finality,
                                                         tipo_doc,
                                                         canal_alf,
                                                         dias_arm_faixa,
                                                         flag_fma,
                                                         flag_tg,
                                                         motivo_prox_mvto,
                                                         horas_prox_mvto,
                                                         sistema,
                                                         id_gravacao,
                                                         imo,
                                                         nvocc,
                                                         qtde_captada,
                                                         marcante,
                                                         autonum_cs_yard,
                                                         autonumcs,
                                                         item,
                                                         tipo,
                                                         pdf_mercadoria,
                                                         indicador,
                                                         anvisa,
                                                         flag_anvisa,
                                                         lote_str
                                                        )
AS
  SELECT c.autonum_armazem, c.descr_armazem, TO_NUMBER (c.id_patio),
         c.flag_ct, b.numero AS bl, b.autonum AS lote, NVL (c.qtde,
                                                            0) AS qtde,
         e.descr AS embalagem, c.mercadoria, c.marca, p.razao AS importador,
         v.nomenavio AS navio, v.viagem,
         DECODE (cntr.dt_entrada, NULL, c.dt_entrada, cntr.dt_entrada),
         cntr.dt_inicio_desova AS dt_desova, cntr.id_conteiner AS cntr_desova,
         NVL (c.peso, 0), NVL (c.volume, 0) AS volume, c.posicao,
         'IPA-CS' AS finality, NVL (td.descr, 'NOT DEFINED YET') AS tipo_doc,
         NVL (b.canal_siscomex, 9) AS canal_alf,
         CASE
           WHEN (  SYSDATE
                 - DECODE (cntr.dt_entrada,
                           NULL, c.dt_entrada,
                           cntr.dt_entrada
                          )
                ) < 2
             THEN '00-02 days'
           WHEN (  SYSDATE
                 - DECODE (cntr.dt_entrada,
                           NULL, c.dt_entrada,
                           cntr.dt_entrada
                          )
                ) >= 2
           AND (  SYSDATE
                - DECODE (cntr.dt_entrada,
                          NULL, c.dt_entrada,
                          cntr.dt_entrada
                         )
               ) < 4
             THEN '02-04 days'
           WHEN (  SYSDATE
                 - DECODE (cntr.dt_entrada,
                           NULL, c.dt_entrada,
                           cntr.dt_entrada
                          )
                ) >= 4
           AND (  SYSDATE
                - DECODE (cntr.dt_entrada,
                          NULL, c.dt_entrada,
                          cntr.dt_entrada
                         )
               ) < 6
             THEN '04-06 days'
           WHEN (  SYSDATE
                 - DECODE (cntr.dt_entrada,
                           NULL, c.dt_entrada,
                           cntr.dt_entrada
                          )
                ) >= 6
           AND (  SYSDATE
                - DECODE (cntr.dt_entrada,
                          NULL, c.dt_entrada,
                          cntr.dt_entrada
                         )
               ) < 8
             THEN '06-08 days'
           WHEN (  SYSDATE
                 - DECODE (cntr.dt_entrada,
                           NULL, c.dt_entrada,
                           cntr.dt_entrada
                          )
                ) >= 8
           AND (  SYSDATE
                - DECODE (cntr.dt_entrada,
                          NULL, c.dt_entrada,
                          cntr.dt_entrada
                         )
               ) < 12
             THEN '08-12 days'
           WHEN (  SYSDATE
                 - DECODE (cntr.dt_entrada,
                           NULL, c.dt_entrada,
                           cntr.dt_entrada
                          )
                ) >= 12
           AND (  SYSDATE
                - DECODE (cntr.dt_entrada,
                          NULL, c.dt_entrada,
                          cntr.dt_entrada
                         )
               ) < 20
             THEN '12-20 days'
           WHEN (  SYSDATE
                 - DECODE (cntr.dt_entrada,
                           NULL, c.dt_entrada,
                           cntr.dt_entrada
                          )
                ) >= 20
           AND (  SYSDATE
                - DECODE (cntr.dt_entrada,
                          NULL, c.dt_entrada,
                          cntr.dt_entrada
                         )
               ) < 30
             THEN '20-30 days'
           WHEN (  SYSDATE
                 - DECODE (cntr.dt_entrada,
                           NULL, c.dt_entrada,
                           cntr.dt_entrada
                          )
                ) >= 30
           AND (  SYSDATE
                - DECODE (cntr.dt_entrada,
                          NULL, c.dt_entrada,
                          cntr.dt_entrada
                         )
               ) < 45
             THEN '30-45 days'
           WHEN (  SYSDATE
                 - DECODE (cntr.dt_entrada,
                           NULL, c.dt_entrada,
                           cntr.dt_entrada
                          )
                ) >= 45
           AND (  SYSDATE
                - DECODE (cntr.dt_entrada,
                          NULL, c.dt_entrada,
                          cntr.dt_entrada
                         )
               ) < 60
             THEN '45-60 days'
           WHEN (  SYSDATE
                 - DECODE (cntr.dt_entrada,
                           NULL, c.dt_entrada,
                           cntr.dt_entrada
                          )
                ) >= 60
             THEN '60 or + days'
         END,
         DECODE (NVL (b.seq_fma, 0), 0, 0, 1) AS flag_fma,
         DECODE (b.tg, NULL, 0, 1) AS flag_tg, vw3.motivo AS motivo_prox_mvto,
         vw3.dt_prevista AS horas_prox_mvto, 'I' AS sistema,
         'Y' || LTRIM (TO_CHAR (c.autonum_cs_yard)),
         DECODE (c.imo, '0', '', c.imo), ind.razao AS nvocc, c.quantidade,
         LPAD (TRIM (TO_CHAR (NVL (c.id_marcante, 0))), 12, 0),
         NVL (c.autonum_cs_yard, 0) AS autonum_cs_yard, c.autonumcs, c.item,
         c.tipo, '', ind.fantasia, NVL (anv.descr, '-'),
         NVL (b.flag_anvisa, 0), TO_CHAR (b.autonum) AS lote_str
    FROM operador.vw_invent_armazem_carga c INNER JOIN sgipa.tb_bl b
         ON c.bl = b.autonum
         INNER JOIN sgipa.dte_tb_embalagens e ON c.embalagem = e.code
         INNER JOIN sgipa.tb_cad_parceiros p ON b.importador = p.autonum
         INNER JOIN sgipa.dte_tb_viagens v ON b.viagem = v.viagem
         LEFT JOIN sgipa.tb_cntr_bl cntr ON c.cntr = cntr.autonum
         LEFT JOIN sgipa.tb_tipos_documentos td ON b.tipo_documento = td.code
         LEFT JOIN sgipa.vw_prox_mov_cs_un vw3 ON b.autonum = vw3.lote
         INNER JOIN sgipa.tb_cad_parceiros ind ON b.captador = ind.autonum
         LEFT JOIN sgipa.tb_bl_anvisa banv ON c.bl = banv.lote
         LEFT JOIN sgipa.tb_cad_anvisa anv ON banv.cod_anvisa = anv.autonum
   WHERE b.flag_ativo = 1 AND b.ultima_saida IS NULL
  UNION
  SELECT a.autonum_armazem, a.descr_armazem, a.id_patio patio, a.flag_ct,
         c.REFERENCE AS bl, 0 AS lote, a.qtde AS quantidade,
         g.descricao_emb AS embalagem, b.desc_produto AS mercadoria, a.marca,
         h.fantasia AS importador, f.descricao_nav AS navio,
         e.num_viagem AS viagem, a.data_entrada AS dt_entrada,
         NULL AS dt_desova, '' AS cntr_desova, a.peso, a.volume,
         a.posicao AS posicao, 'RDX' AS finality,
         NVL (sdboo.doc_exp, '-') AS tipo_doc, 0 AS canal_alf,
         CASE
           WHEN (SYSDATE - a.data_entrada) < 2
             THEN '00-02 days'
           WHEN (SYSDATE - a.data_entrada) >= 2
           AND (SYSDATE - a.data_entrada) < 4
             THEN '02-04 days'
           WHEN (SYSDATE - a.data_entrada) >= 4
           AND (SYSDATE - a.data_entrada) < 6
             THEN '04-06 days'
           WHEN (SYSDATE - a.data_entrada) >= 6
           AND (SYSDATE - a.data_entrada) < 8
             THEN '06-08 days'
           WHEN (SYSDATE - a.data_entrada) >= 8
           AND (SYSDATE - a.data_entrada) < 12
             THEN '08-12 days'
           WHEN (SYSDATE - a.data_entrada) >= 12
           AND (SYSDATE - a.data_entrada) < 20
             THEN '12-20 days'
           WHEN (SYSDATE - a.data_entrada) >= 20
           AND (SYSDATE - a.data_entrada) < 30
             THEN '20-30 days'
           WHEN (SYSDATE - a.data_entrada) >= 30
           AND (SYSDATE - a.data_entrada) < 45
             THEN '30-45 days'
           WHEN (SYSDATE - a.data_entrada) >= 45
           AND (SYSDATE - a.data_entrada) < 60
             THEN '45-60 days'
           WHEN (SYSDATE - a.data_entrada) >= 60
             THEN '60 or + days'
         END AS dias_arm_faixa,
         0 AS flag_fma, 0 AS flag_tg,
         DECODE (e.dt_dead_line, NULL, '', 'EMBARQUE') AS prox_movimento,
         e.dt_dead_line, 'R' AS sistema, a.id_gravacao, a.imo, '' AS nvocc,
         a.qtde_captada, a.marcante, a.autonum_cs_yard,
         a.autonumcs, 1 AS item, a.tipo, '' AS pdf_mercadoria,
         '' AS indicador, '-' AS anvisa, 0 AS flag_anvisa, c.os AS lote_str
    FROM operador.vw_invent_armazem_carga_rdx a INNER JOIN redex.tb_booking c
         ON a.autonum_boo = c.autonum_boo
         LEFT JOIN redex.tb_cad_produtos b ON a.autonum_pro = b.autonum_pro
         LEFT JOIN redex.tb_viagens e ON c.autonum_via = e.autonum_via
         LEFT JOIN redex.tb_cad_navios f ON e.autonum_nav = f.autonum_nav
         LEFT JOIN redex.tb_cad_embalagens g ON a.autonum_emb = g.autonum_emb
         LEFT JOIN redex.tb_cad_parceiros h ON c.autonum_parceiro = h.autonum
         LEFT JOIN redex.tb_booking bm ON c.reserva_master = bm.autonum_boo
         LEFT JOIN redex.tb_booking bs ON c.reserva_pai = bs.autonum_boo
         LEFT JOIN
         (SELECT   MIN (td.descricao) AS doc_exp, sdb.autonum_boo
              FROM redex.tb_cad_sd sd INNER JOIN redex.tb_cad_tipo_documento td
                   ON sd.autonum_tipo_doc = td.autonum
                   INNER JOIN redex.tb_cad_sd_boo sdb
                   ON sd.autonum_sd = sdb.autonum_sd
             WHERE sd.data_validade < SYSDATE - 60
          GROUP BY sdb.autonum_boo) sdboo ON a.autonum_boo = sdboo.autonum_boo
   WHERE c.data_registro > SYSDATE - 360;
         
   
   DROP VIEW OPERADOR.VW_INVENT_ARMAZEM_ITEM;

/* Formatted on 2018/07/20 14:11 (Formatter Plus v4.8.8) */
CREATE OR REPLACE FORCE VIEW operador.vw_invent_armazem_item (descr_armazem,
                                                              qtde,
                                                              embalagem,
                                                              posicao,
                                                              sistema,
                                                              id_gravacao,
                                                              qtde_captada,
                                                              marcante,
                                                              lote_str,
                                                              bl,
                                                              autonum_armazem
                                                             )
AS
  SELECT c.descr_armazem, NVL (c.qtde, 0) AS qtde, e.descr AS embalagem,
         c.posicao, 'I' AS sistema,
         'Y' || LTRIM (TO_CHAR (c.autonum_cs_yard)), c.quantidade,
         LPAD (TRIM (TO_CHAR (NVL (c.id_marcante, 0))), 12, 0),
         TO_CHAR (b.autonum) AS lote_str, b.numero, c.autonum_armazem
    FROM operador.vw_invent_armazem_carga c INNER JOIN sgipa.tb_bl b
         ON c.bl = b.autonum
         LEFT JOIN sgipa.dte_tb_embalagens e ON c.embalagem = e.code
   WHERE b.flag_ativo = 1 AND b.ultima_saida IS NULL
  UNION
  SELECT a.descr_armazem, a.qtde AS quantidade, g.descricao_emb AS embalagem,
         a.posicao, 'R' AS sistema, a.id_gravacao, a.qtde_captada,
         A.MARCANTE AS marcante, c.os AS lote_str, c.REFERENCE AS bl,
         a.autonum_armazem
    FROM operador.vw_invent_armazem_carga_rdx a INNER JOIN redex.tb_booking c
         ON a.autonum_boo = c.autonum_boo
         LEFT JOIN redex.tb_cad_embalagens g ON a.autonum_emb = g.autonum_emb
   WHERE c.flag_cs = 1 AND c.data_registro > SYSDATE - 360;


