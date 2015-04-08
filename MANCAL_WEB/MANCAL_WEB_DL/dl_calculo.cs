using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;

namespace MANCAL_WEB_DL
{
    public class dl_calculo
    {
        private static String conStr = System.Configuration.ConfigurationManager.ConnectionStrings["ora_sico_mancal"].ConnectionString;

        #region Metodos Proyecto

        public DataSet selectTotalDetalle(int tmoneda, String descto, int idiva, String idcotiz, String idun) 
        {
            DataSet ds = new DataSet();

            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "FN_MANCAL_CALCULO_TOTAL";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("cur_ret_total", OracleDbType.RefCursor)).Direction = ParameterDirection.ReturnValue;

                    cmd.Parameters.Add(new OracleParameter("tipomoneda", OracleDbType.Int32)).Value = tmoneda;
                    cmd.Parameters["tipomoneda"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("descto", OracleDbType.Varchar2)).Value = descto;
                    cmd.Parameters["descto"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("tniva", OracleDbType.Int32)).Value = idiva;
                    cmd.Parameters["tniva"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("idusr", OracleDbType.Varchar2)).Value = idcotiz;
                    cmd.Parameters["idusr"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("tipoun", OracleDbType.Varchar2)).Value = idun;
                    cmd.Parameters["tipoun"].Direction = ParameterDirection.Input;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd)) 
                    {
                        oda.Fill(ds, "cur_ret_total");
                    }
                }
                con.Close();
            }
            return ds;
        }

        public DataSet selectTotalExceder(String idcotiz) 
        {
            DataSet ds = new DataSet();

            return ds;
        }

        public DataSet selectTotalMargenes(String idcotiz, int idmoneda, int idtcoti, String fechcot, String idun) 
        {
            DataSet ds = new DataSet();

            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "FN_MANCAL_MARGENES_REPMO";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("cur_total_margen", OracleDbType.RefCursor)).Direction = ParameterDirection.ReturnValue;

                    cmd.Parameters.Add(new OracleParameter("IDCOTIZ", OracleDbType.Varchar2)).Value = idcotiz;
                    cmd.Parameters["IDCOTIZ"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("IDMONEDA", OracleDbType.Int32)).Value = idmoneda;
                    cmd.Parameters["IDMONEDA"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("IDTCOTIZ", OracleDbType.Int32)).Value = idtcoti;
                    cmd.Parameters["IDTCOTIZ"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("FECCOTIZ", OracleDbType.Varchar2)).Value = fechcot;
                    cmd.Parameters["FECCOTIZ"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("IDUNNEG", OracleDbType.Varchar2)).Value = idun;
                    cmd.Parameters["IDUNNEG"].Direction = ParameterDirection.Input;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd)) 
                    {
                        oda.Fill(ds, "cur_total_margen");
                    }
                }
                con.Close();
            }

            return ds;
        }

        #endregion

        public String selectTotalTransporte(String idcot, int ttras, int rtras, int ttari, DateTime fcot) 
        {
            String total_trans = "";

            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "FN_MANCAL_CALCULO_TRANSPORTE";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("V_VALOR_TRASLADO", OracleDbType.Int32)).Direction = ParameterDirection.ReturnValue;

                    cmd.Parameters.Add(new OracleParameter("P_ID_COTIZACION", OracleDbType.Varchar2)).Value = idcot;
                    cmd.Parameters["P_ID_COTIZACION"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_TIPO_TRASLADO", OracleDbType.Int32)).Value = ttras;
                    cmd.Parameters["P_TIPO_TRASLADO"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_REGION_TRASLADO", OracleDbType.Int32)).Value = rtras;
                    cmd.Parameters["P_REGION_TRASLADO"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_TIPO_TARIFA", OracleDbType.Int32)).Value = ttari;
                    cmd.Parameters["P_TIPO_TARIFA"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_FECHA_COTIZACION", OracleDbType.Date)).Value = fcot;
                    cmd.Parameters["P_FECHA_COTIZACION"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();

                    total_trans = cmd.Parameters["V_VALOR_TRASLADO"].Value.ToString();
                }
                con.Close();
            }

            return total_trans;
        }

        public void selectTotalSinTransporte(String idcot) 
        {
            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "SP_MANCAL_CALCULO_TRANS_SIN";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("P_ID_COTIZACION", OracleDbType.Varchar2)).Value = idcot;
                    cmd.Parameters["P_ID_COTIZACION"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void selectSinCostoComision(int idlugar, int qtypersona, int qtycommes, int qtyveh, int qtydia, int eqdoct, int eqdoca, int fondoren, int gastorep, String idcoti, int ttarifa, DateTime fcoti) 
        {
            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "SP_MANCAL_CALCULO_COMIS_SIN";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("P_ID_LUGAR", OracleDbType.Int32)).Value = idlugar;
                    cmd.Parameters["P_ID_LUGAR"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_QTY_PERSONA", OracleDbType.Int32)).Value = qtypersona;
                    cmd.Parameters["P_QTY_PERSONA"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_QTY_COM_MES", OracleDbType.Int32)).Value = qtycommes;
                    cmd.Parameters["P_QTY_COM_MES"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_QTY_VEHICULO", OracleDbType.Int32)).Value = qtyveh;
                    cmd.Parameters["P_QTY_VEHICULO"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_QTY_DIA", OracleDbType.Int32)).Value = qtydia;
                    cmd.Parameters["P_QTY_DIA"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_TRAS_EQDOC_T", OracleDbType.Int32)).Value = eqdoct;
                    cmd.Parameters["P_TRAS_EQDOC_T"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_TRAS_EQDOC_A", OracleDbType.Int32)).Value = eqdoca;
                    cmd.Parameters["P_TRAS_EQDOC_A"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_FONDO_RENDIR", OracleDbType.Int32)).Value = fondoren;
                    cmd.Parameters["P_FONDO_RENDIR"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_GASTOS_REPRE", OracleDbType.Int32)).Value = gastorep;
                    cmd.Parameters["P_GASTOS_REPRE"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_ID_COTIZACION", OracleDbType.Varchar2)).Value = idcoti;
                    cmd.Parameters["P_ID_COTIZACION"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_TIPO_TARIFA", OracleDbType.Int32)).Value = ttarifa;
                    cmd.Parameters["P_TIPO_TARIFA"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_FECHA_COTIZACION", OracleDbType.Date)).Value = fcoti;
                    cmd.Parameters["P_FECHA_COTIZACION"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public DataSet selectCostoComision(int idlugar, int qtypersona, int qtycommes, int qtyveh, int qtydia, int eqdoct, int eqdoca, int fondoren, int gastorep, String idcoti, int ttarifa, DateTime fcoti) 
        {
            DataSet ds = new DataSet();

            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "FN_MANCAL_CALCULO_COMISION";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("CUR_COMISION", OracleDbType.RefCursor)).Direction = ParameterDirection.ReturnValue;

                    cmd.Parameters.Add(new OracleParameter("P_ID_LUGAR", OracleDbType.Int32)).Value = idlugar;
                    cmd.Parameters["P_ID_LUGAR"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_QTY_PERSONA", OracleDbType.Int32)).Value = qtypersona;
                    cmd.Parameters["P_QTY_PERSONA"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_QTY_COM_MES", OracleDbType.Int32)).Value = qtycommes;
                    cmd.Parameters["P_QTY_COM_MES"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_QTY_VEHICULO", OracleDbType.Int32)).Value = qtyveh;
                    cmd.Parameters["P_QTY_VEHICULO"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_QTY_DIA", OracleDbType.Int32)).Value = qtydia;
                    cmd.Parameters["P_QTY_DIA"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_TRAS_EQDOC_T", OracleDbType.Int32)).Value = eqdoct;
                    cmd.Parameters["P_TRAS_EQDOC_T"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_TRAS_EQDOC_A", OracleDbType.Int32)).Value = eqdoca;
                    cmd.Parameters["P_TRAS_EQDOC_A"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_FONDO_RENDIR", OracleDbType.Int32)).Value = fondoren;
                    cmd.Parameters["P_FONDO_RENDIR"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_GASTOS_REPRE", OracleDbType.Int32)).Value = gastorep;
                    cmd.Parameters["P_GASTOS_REPRE"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_ID_COTIZACION", OracleDbType.Varchar2)).Value = idcoti;
                    cmd.Parameters["P_ID_COTIZACION"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_TIPO_TARIFA", OracleDbType.Int32)).Value = ttarifa;
                    cmd.Parameters["P_TIPO_TARIFA"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_FECHA_COTIZACION", OracleDbType.Date)).Value = fcoti;
                    cmd.Parameters["P_FECHA_COTIZACION"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd)) 
                    {
                        oda.Fill(ds, "CUR_COMISION");
                    }
                }
                con.Close();
            }

            return ds;
        }
    }
}
