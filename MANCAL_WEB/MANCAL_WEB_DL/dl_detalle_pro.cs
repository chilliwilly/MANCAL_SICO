using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;

namespace MANCAL_WEB_DL
{
    public class dl_detalle_pro
    {
        private static String conStr = System.Configuration.ConfigurationManager.ConnectionStrings["ora_sico_mancal"].ConnectionString;

        #region Metodos Proyecto

        public String selectTotalEquipoIn(int tcoti, int tmoneda, String crep, String prep, String cmo, String pmo, int qty) 
        {
            String total = "";

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "PKG_MANCAL_DET_PROY.FN_CALCULA_EQUIPO_DET";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("vtotal", OracleDbType.Varchar2, 20)).Direction = ParameterDirection.ReturnValue;

                    cmd.Parameters.Add(new OracleParameter("tcoti", OracleDbType.Int32)).Value = tcoti;
                    cmd.Parameters["tcoti"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("tmoneda", OracleDbType.Int32)).Value = tmoneda;
                    cmd.Parameters["tmoneda"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("crep", OracleDbType.Varchar2)).Value = crep;
                    cmd.Parameters["crep"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("prep", OracleDbType.Varchar2)).Value = prep;
                    cmd.Parameters["prep"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("cmo", OracleDbType.Varchar2)).Value = cmo;
                    cmd.Parameters["cmo"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("pmo", OracleDbType.Varchar2)).Value = pmo;
                    cmd.Parameters["pmo"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("qty", OracleDbType.Int32)).Value = qty;
                    cmd.Parameters["qty"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();

                    total = cmd.Parameters["vtotal"].Value.ToString().Trim();
                }
                con.Close();
            }
            return total;
        }

        public void insertEquipoIn(String idusr, String nparte, String descrip, String nserie, int qty, String crep, String prep, String cmo, String pmo, String monto) 
        {
            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "PKG_MANCAL_DET_PROY.SP_INSERT_EQUIPO_DET";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("idusr", OracleDbType.Varchar2)).Value = idusr;
                    cmd.Parameters["idusr"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("nparte", OracleDbType.Varchar2)).Value = nparte;
                    cmd.Parameters["nparte"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("descrip", OracleDbType.Varchar2)).Value = descrip;
                    cmd.Parameters["descrip"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("nserie", OracleDbType.Varchar2)).Value = nserie;
                    cmd.Parameters["nserie"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("qty", OracleDbType.Int32)).Value = qty;
                    cmd.Parameters["qty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("crep", OracleDbType.Varchar2)).Value = crep;
                    cmd.Parameters["crep"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("prep", OracleDbType.Varchar2)).Value = prep;
                    cmd.Parameters["prep"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("cmo", OracleDbType.Varchar2)).Value = cmo;
                    cmd.Parameters["cmo"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("pmo", OracleDbType.Varchar2)).Value = pmo;
                    cmd.Parameters["pmo"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("monto", OracleDbType.Varchar2)).Value = monto;
                    cmd.Parameters["monto"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataSet selectDetalleProy(String usr, int moneda) 
        {
            DataSet ds = new DataSet();

            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "PKG_MANCAL_DET_PROY.FN_SELECT_EQUIPO_DET";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("cur_det_prov", OracleDbType.RefCursor)).Direction = ParameterDirection.ReturnValue;

                    cmd.Parameters.Add(new OracleParameter("idusr", OracleDbType.Varchar2)).Value = usr;
                    cmd.Parameters["idusr"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("tmoneda", OracleDbType.Int32)).Value = moneda;
                    cmd.Parameters["tmoneda"].Direction = ParameterDirection.Input;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd)) 
                    {
                        oda.Fill(ds, "cur_det_prov");
                    }
                }
                con.Close();
            }
            return ds;
        }

        public void updateDetalleProy(String idusr_, int nitem_, String nparte_, String descrip_, String nserie_, int qty_, String crep_, String prep_, String cmo_, String pmo_, String monto_)
        {
            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "PKG_MANCAL_DET_PROY.SP_UPDATE_EQUIPO_DET";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("idusr", OracleDbType.Varchar2)).Value = idusr_;
                    cmd.Parameters["idusr"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("nitem", OracleDbType.Int32)).Value = nitem_;
                    cmd.Parameters["nitem"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("nparte", OracleDbType.Varchar2)).Value = nparte_;
                    cmd.Parameters["nparte"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("descrip", OracleDbType.Varchar2)).Value = descrip_;
                    cmd.Parameters["descrip"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("nserie", OracleDbType.Varchar2)).Value = nserie_;
                    cmd.Parameters["nserie"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("qty", OracleDbType.Int32)).Value = qty_;
                    cmd.Parameters["qty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("crep", OracleDbType.Varchar2)).Value = crep_;
                    cmd.Parameters["crep"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("prep", OracleDbType.Varchar2)).Value = prep_;
                    cmd.Parameters["prep"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("cmo", OracleDbType.Varchar2)).Value = cmo_;
                    cmd.Parameters["cmo"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("pmo", OracleDbType.Varchar2)).Value = pmo_;
                    cmd.Parameters["pmo"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("monto", OracleDbType.Varchar2)).Value = monto_;
                    cmd.Parameters["monto"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void deleteDetalleProy(String idusr_, int nitem_) 
        {
            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "PKG_MANCAL_DET_PROY.SP_DELETE_EQUIPO_DET";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("idusr", OracleDbType.Varchar2)).Value = idusr_;
                    cmd.Parameters["idusr"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("nitem", OracleDbType.Int32)).Value = nitem_;
                    cmd.Parameters["nitem"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        #endregion

        #region Metodos Cotizacion

        //METODO PARA OBTENER LISTA DE EQUIPO PARA SER SELECCIONADOS
        public DataSet selectEquipoBuscar(String nom, String nparte, String nommodelo, int idmagnitud, int idfamilia, int idsys)
        {
            DataSet ds = new DataSet();

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                con.BeginTransaction();
                String qry = "FN_MANCAL_GET_LISTA_EQUIPO";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("CUR_BUSCA_EQUIPO", OracleDbType.RefCursor)).Direction = ParameterDirection.ReturnValue;

                    cmd.Parameters.Add(new OracleParameter("P_NOMBRE", OracleDbType.Varchar2)).Value = nom;//NOMBRE EQUIPO
                    cmd.Parameters["P_NOMBRE"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_NROPARTE", OracleDbType.Varchar2)).Value = nparte;
                    cmd.Parameters["P_NROPARTE"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_MODELO", OracleDbType.Varchar2)).Value = null;//NUMERO DE PARTE
                    cmd.Parameters["P_MODELO"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_NROSERIE", OracleDbType.Varchar2)).Value = nommodelo;//NOMBRE DEL MODELO
                    cmd.Parameters["P_NROSERIE"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_MAGNITUD", OracleDbType.Int32)).Value = idmagnitud;
                    cmd.Parameters["P_MAGNITUD"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_FAMILIA", OracleDbType.Int32)).Value = idfamilia;//ESTADO DEL EQUIPO
                    cmd.Parameters["P_FAMILIA"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_ID_SISTEMA", OracleDbType.Int32)).Value = idsys;//ID DE SISTEMA 2 PARA SIGEPAC
                    cmd.Parameters["P_ID_SISTEMA"].Direction = ParameterDirection.Input;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd)) 
                    {
                        oda.Fill(ds, "CUR_BUSCA_EQUIPO");
                    }
                    con.Close();
                }



                //String qry_proc = "SP_SPAC_SEARCH_PLANTILLAS";
                //using (OracleCommand cmd_proc = new OracleCommand(qry_proc, con))
                //{
                //    cmd_proc.CommandType = CommandType.StoredProcedure;

                //    cmd_proc.Parameters.Add(new OracleParameter("P_NOMBRE_PLANTILLA", OracleDbType.Varchar2)).Value = nom;//NOMBRE EQUIPO
                //    cmd_proc.Parameters["P_NOMBRE_PLANTILLA"].Direction = ParameterDirection.Input;

                //    cmd_proc.Parameters.Add(new OracleParameter("P_FAMILIA", OracleDbType.Varchar2)).Value = null;
                //    cmd_proc.Parameters["P_FAMILIA"].Direction = ParameterDirection.Input;

                //    cmd_proc.Parameters.Add(new OracleParameter("P_NUMERO_PARTE", OracleDbType.Varchar2)).Value = nparte;//NUMERO DE PARTE
                //    cmd_proc.Parameters["P_NUMERO_PARTE"].Direction = ParameterDirection.Input;

                //    cmd_proc.Parameters.Add(new OracleParameter("P_MODELO", OracleDbType.Varchar2)).Value = nommodelo;//NOMBRE DEL MODELO
                //    cmd_proc.Parameters["P_MODELO"].Direction = ParameterDirection.Input;

                //    cmd_proc.Parameters.Add(new OracleParameter("P_TIPO", OracleDbType.Varchar2)).Value = null;
                //    cmd_proc.Parameters["P_TIPO"].Direction = ParameterDirection.Input;

                //    cmd_proc.Parameters.Add(new OracleParameter("P_ESTADO", OracleDbType.Varchar2)).Value = null;//ESTADO DEL EQUIPO
                //    cmd_proc.Parameters["P_ESTADO"].Direction = ParameterDirection.Input;

                //    cmd_proc.Parameters.Add(new OracleParameter("P_ID_SISTEMA", OracleDbType.Int32)).Value = idsys;//ID DE SISTEMA 2 PARA SIGEPAC
                //    cmd_proc.Parameters["P_ID_SISTEMA"].Direction = ParameterDirection.Input;

                //    cmd_proc.ExecuteNonQuery();
                //}

                ////String qry = "SELECT NOMBRE, NVL(MODELO,'NO ESPECIFICA') MODELO, NVL(N_PARTE,'SIN NRO PARTE') N_PARTE, ID_PP_PLANTILLA FROM TBL_SPAC_SEARCH_PLANTILLAS_TMP";
                //String qry = "SELECT NOMBRE, NVL(MODELO,'NO ESPECIFICA') MODELO, NVL(N_PARTE,'SIN NRO PARTE') N_PARTE, ID_PP_PLANTILLA, NVL(PRECIO_PROMEDIO,-10) PRECIO_PROM FROM TBL_SPAC_SEARCH_PLANTILLAS_TMP"
                //           + " LEFT JOIN TBL_SBAS_DATOS_COMER_EQ ON TBL_SPAC_SEARCH_PLANTILLAS_TMP.ID_PP_PLANTILLA = TBL_SBAS_DATOS_COMER_EQ.ID_PLANTILLA_EQ";
                //using (OracleCommand cmd = new OracleCommand(qry, con))
                //{
                //    cmd.CommandType = CommandType.Text;

                //    using (OracleDataAdapter oda = new OracleDataAdapter(cmd)) 
                //    {
                //        oda.Fill(dt);
                //    }
                //}
                //con.Close();
            }

            return ds;
        }

        //METODO PARA OBTENER PRECIO DEL EQUIPO AL SELECCIONARLO
        public DataSet selectValorEquipo(int idsys, int idequ, int idtar, DateTime fcot)
        {
            DataSet ds = new DataSet();

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "FN_MANCAL_CAL_GET_VALOR_EQUIPO";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("CUR_PRECIO_EQ", OracleDbType.RefCursor)).Direction = ParameterDirection.ReturnValue;

                    cmd.Parameters.Add(new OracleParameter("P_ID_SISTEMA", OracleDbType.Int32)).Value = idsys;
                    cmd.Parameters["P_ID_SISTEMA"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_ID_EQUIPO", OracleDbType.Int32)).Value = idequ;
                    cmd.Parameters["P_ID_EQUIPO"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_ID_TARIFA", OracleDbType.Int32)).Value = idtar;
                    cmd.Parameters["P_ID_TARIFA"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_FECHA_COT", OracleDbType.Date)).Value = fcot;
                    cmd.Parameters["P_FECHA_COT"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                    {
                        oda.Fill(ds, "CUR_PRECIO_EQ");
                    }
                }
                con.Close();
            }

            return ds;
        }

        //CALIBRACION METODO PARA CALCULAR EL TOTAL DEL EQUIPO AL MOMENTO DE MODIFICAR LOS CAMPOS PRECIOS MODIFICABLES DEL EQUIPO
        public DataSet selectCalculoEquipo(int eqid, int sysid, int eqqty, String eqpmo, String eqgasto, String eqcarga, int idtarifa, DateTime fechacot)
        {
            DataSet ds = new DataSet();

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "FN_MANCAL_CAL_CALCULO_EQUIPO";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("RET_PRECIO_VENTA", OracleDbType.RefCursor)).Direction = ParameterDirection.ReturnValue;

                    cmd.Parameters.Add(new OracleParameter("P_ID_EQUIPO", OracleDbType.Int32)).Value = eqid;
                    cmd.Parameters["P_ID_EQUIPO"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_ID_SISTEMA", OracleDbType.Int32)).Value = sysid;
                    cmd.Parameters["P_ID_SISTEMA"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_CANTIDAD", OracleDbType.Int32)).Value = eqqty;
                    cmd.Parameters["P_CANTIDAD"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_PRECIOMO", OracleDbType.Varchar2)).Value = eqpmo;
                    cmd.Parameters["P_PRECIOMO"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_GASTOSEQ", OracleDbType.Varchar2)).Value = eqgasto;
                    cmd.Parameters["P_GASTOSEQ"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_PRECIOCARGA", OracleDbType.Varchar2)).Value = eqcarga;
                    cmd.Parameters["P_PRECIOCARGA"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_ID_TARIFA", OracleDbType.Int32)).Value = idtarifa;
                    cmd.Parameters["P_ID_TARIFA"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_FECHACOTI", OracleDbType.Date)).Value = fechacot;
                    cmd.Parameters["P_FECHACOTI"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                    {
                        oda.Fill(ds, "RET_PRECIO_VENTA");
                    }
                }
                con.Close();
            }
            return ds;
        }

        #endregion

        //METODO DL QUE PASA COMO XML LOS DATOS DEL EQUIPO SELECCIONADO
        public void insertDetCotCal(String dtDetCotCal) 
        {
            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "PKG_MANCAL_DMLCOT_DETEQUIPO_V2.SP_DETEQUIPO_INSERT";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("P_DATO_DET_COT", OracleDbType.Clob)).Value = dtDetCotCal;
                    cmd.Parameters["P_DATO_DET_COT"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public DataSet selectEquipoCot(String id_cot, int id_tarifa, String dcto) 
        {
            DataSet ds = new DataSet();

            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                con.BeginTransaction();
                String qry = "PKG_MANCAL_DMLCOT_DETEQUIPO_V2.FN_DETEQUIPO_SELECT";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("CUR_DET", OracleDbType.RefCursor)).Direction = ParameterDirection.ReturnValue;

                    cmd.Parameters.Add(new OracleParameter("P_ID_COTIZACION", OracleDbType.Varchar2)).Value = id_cot;
                    cmd.Parameters["P_ID_COTIZACION"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_TIPO_TARIFA", OracleDbType.Int32)).Value = id_tarifa;
                    cmd.Parameters["P_TIPO_TARIFA"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_DCTO_COTIZACION", OracleDbType.Varchar2)).Value = dcto;
                    cmd.Parameters["P_DCTO_COTIZACION"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd)) 
                    {
                        oda.Fill(ds, "CUR_DET");
                    }
                }
                con.Close();
            }
            return ds;
        }

        public void insertDatoPuntoEquipo(String cot_id, int esp_id, int fun_id, String punto_in, int id_detcot, int id_item, int equ_id, String coment) 
        {
            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "PKG_MANCAL_DMLCOT_DETPUNTO.SP_DETPUNTO_INSERT";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("P_ID_COT", OracleDbType.Varchar2)).Value = cot_id;
                    cmd.Parameters["P_ID_COT"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_ID_ESP", OracleDbType.Int32)).Value = esp_id;
                    cmd.Parameters["P_ID_ESP"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_ID_FUN", OracleDbType.Int32)).Value = fun_id;
                    cmd.Parameters["P_ID_FUN"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_PUNTOS", OracleDbType.Varchar2)).Value = punto_in;
                    cmd.Parameters["P_PUNTOS"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_ID_DC", OracleDbType.Int32)).Value = id_detcot;
                    cmd.Parameters["P_ID_DC"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_ID_ITEM", OracleDbType.Int32)).Value = id_item;
                    cmd.Parameters["P_ID_ITEM"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_ID_EQUIPO", OracleDbType.Int32)).Value = equ_id;
                    cmd.Parameters["P_ID_EQUIPO"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_COMENTARIO", OracleDbType.Varchar2)).Value = coment;
                    cmd.Parameters["P_COMENTARIO"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public DataSet selectDatoPuntoEquipo(String cot_id, int id_equ, int? id_dcc) 
        {
            DataSet ds = new DataSet();

            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                con.BeginTransaction();                
                String qry = "PKG_MANCAL_DMLCOT_DETPUNTO.FN_DETPUNTO_SELECT";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("CUR_DETPUNTO", OracleDbType.RefCursor)).Direction = ParameterDirection.ReturnValue;

                    cmd.Parameters.Add(new OracleParameter("P_IDCOT", OracleDbType.Varchar2)).Value = cot_id;
                    cmd.Parameters["P_IDCOT"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_ID_EQUIPO", OracleDbType.Int32)).Value = id_equ;
                    cmd.Parameters["P_ID_EQUIPO"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_DCC_ID", OracleDbType.Int32)).Value = id_dcc;
                    cmd.Parameters["P_DCC_ID"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd)) 
                    {
                        oda.Fill(ds, "CUR_DETPUNTO");
                    }
                }
                con.Close();
            }

            return ds;
        }

        public void updateValorEquipoDet(String idcot, int item, String nparte, String nserie, int qty, String preciomo, String gasto, String carga, String total, int ttarifa)
        {
            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "PKG_MANCAL_DMLCOT_DETEQUIPO_V2.SP_DETCALEQUIPO_UPDATE";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("P_IDCOT", OracleDbType.Varchar2)).Value = idcot;
                    cmd.Parameters["P_IDCOT"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_ITEM", OracleDbType.Int32)).Value = item;
                    cmd.Parameters["P_ITEM"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_NPARTE", OracleDbType.Varchar2)).Value = nparte;
                    cmd.Parameters["P_NPARTE"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_NSERIE", OracleDbType.Varchar2)).Value = nserie;
                    cmd.Parameters["P_NSERIE"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_QTY", OracleDbType.Int32)).Value = qty;
                    cmd.Parameters["P_QTY"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_PRECIOMO", OracleDbType.Varchar2)).Value = preciomo;
                    cmd.Parameters["P_PRECIOMO"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_GASTO", OracleDbType.Varchar2)).Value = gasto;
                    cmd.Parameters["P_GASTO"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_CARGA", OracleDbType.Varchar2)).Value = carga;
                    cmd.Parameters["P_CARGA"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_TOTAL", OracleDbType.Varchar2)).Value = total;
                    cmd.Parameters["P_TOTAL"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_TTARIFA", OracleDbType.Int32)).Value = ttarifa;
                    cmd.Parameters["P_TTARIFA"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void deleteEquipoCot(String idcot, int item, int idequ) 
        {
            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "PKG_MANCAL_DMLCOT_DETEQUIPO_V2.SP_DETEQUIPO_DELETE";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("P_ID_EQUIPO", OracleDbType.Int32)).Value = idequ;
                    cmd.Parameters["P_ID_EQUIPO"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_ID_ITEM", OracleDbType.Int32)).Value = item;
                    cmd.Parameters["P_ID_ITEM"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_ID_COTIZACION", OracleDbType.Varchar2)).Value = idcot;
                    cmd.Parameters["P_ID_COTIZACION"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void updateEquipoDetCalProd(int item, String cotiid, String np, String oc, String saot, int lp, int estado) 
        {
            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "PKG_MANCAL_DMLCOT_DETEQUIPO_V2.SP_DETCALEQUIPO_UPDATE_PROD";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("P_DETITEM", OracleDbType.Int32)).Value = item;
                    cmd.Parameters["P_DETITEM"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_IDCOTIZ", OracleDbType.Varchar2)).Value = cotiid;
                    cmd.Parameters["P_IDCOTIZ"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_NP", OracleDbType.Varchar2)).Value = np;
                    cmd.Parameters["P_NP"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_OC", OracleDbType.Varchar2)).Value = oc;
                    cmd.Parameters["P_OC"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_SAOT", OracleDbType.Varchar2)).Value = saot;
                    cmd.Parameters["P_SAOT"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_LP", OracleDbType.Int32)).Value = lp;
                    cmd.Parameters["P_LP"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_ESTADO", OracleDbType.Int32)).Value = estado;
                    cmd.Parameters["P_ESTADO"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }
        
        public void updatePuntoDetFila(int nitem, String idcot, String puntos, int indcc, String coment) 
        {
            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "PKG_MANCAL_DMLCOT_DETPUNTO.SP_DETPUNTO_UPDATE_PTO";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("P_ITEM", OracleDbType.Int32)).Value = nitem;
                    cmd.Parameters["P_ITEM"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_IDCOT", OracleDbType.Varchar2)).Value = idcot;
                    cmd.Parameters["P_IDCOT"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_PUNTO", OracleDbType.Varchar2)).Value = puntos;
                    cmd.Parameters["P_PUNTO"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_DCC_ID", OracleDbType.Varchar2)).Value = indcc;
                    cmd.Parameters["P_DCC_ID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_COMENTARIO", OracleDbType.Varchar2)).Value = coment;
                    cmd.Parameters["P_COMENTARIO"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void deletePuntoDetFila(int nitem, String idcot, int nequipo, int indcc) 
        {
            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "PKG_MANCAL_DMLCOT_DETPUNTO.SP_DETPUNTO_DELETE";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("P_IDCOT", OracleDbType.Varchar2)).Value = idcot;
                    cmd.Parameters["P_IDCOT"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_PDCC_ID", OracleDbType.Int32)).Value = nitem;
                    cmd.Parameters["P_PDCC_ID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_EQUI_ID", OracleDbType.Int32)).Value = nequipo;
                    cmd.Parameters["P_EQUI_ID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_DCC_ID", OracleDbType.Int32)).Value = indcc;
                    cmd.Parameters["P_DCC_ID"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }
    }
}
