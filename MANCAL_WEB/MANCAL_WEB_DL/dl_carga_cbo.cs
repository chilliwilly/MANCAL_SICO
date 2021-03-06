﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;

namespace MANCAL_WEB_DL
{
    public class dl_carga_cbo
    {
        private static String conStr = System.Configuration.ConfigurationManager.ConnectionStrings["ora_sico_mancal"].ConnectionString;

        public DataTable selectTipoCotizacion() 
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "SELECT TC_ID, TC_NOMBRE, TC_UN_ID FROM TBL_TIPO_COTIZACION ORDER BY TC_ID";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd)) 
                    {
                        oda.Fill(dt);
                    }
                }
                con.Close();
            }
            return dt;
        }

        public DataTable selectVendedor() 
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "SELECT VEN_ID, VEN_UN_ID, USR_NOMBRE, USR_APPAT FROM TBL_USUARIO JOIN TBL_VENDEDOR USING(USR_ID) ORDER BY USR_NOMBRE";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd)) 
                    {
                        oda.Fill(dt);
                    }
                }
                con.Close();
            }
            return dt;
        }

        public DataTable selectTarifa() 
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "SELECT TT_ID, TT_NOMBRE FROM TBL_TIPO_TARIFA ORDER BY TT_ID";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                    {
                        oda.Fill(dt);
                    }
                }
                con.Close();
            }
            return dt;
        }

        public DataTable selectTrabajo() 
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "SELECT TTR_ID, TTR_NOMBRE, TTR_UN_ID, TTR_FORMATO FROM TBL_TIPO_TRABAJO ORDER BY TTR_ID";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                    {
                        oda.Fill(dt);
                    }
                }
                con.Close();
            }
            return dt;
        }

        public DataTable selectFactura()
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "SELECT TF_ID, TF_NOMBRE FROM TBL_TIPO_FACTURACION ORDER BY TF_ID";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                    {
                        oda.Fill(dt);
                    }
                }
                con.Close();
            }
            return dt;
        }

        public DataTable selectPagoFactura() 
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "SELECT TFPF_ID, TFPF_NOMBRE FROM TBL_TIPO_FPAGO_FACTURA ORDER BY TFPF_ID";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                    {
                        oda.Fill(dt);
                    }
                }
                con.Close();
            }
            return dt;
        }

        public DataTable selectPlazoEntrega() 
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "SELECT TPE_ID, TPE_NOMBRE FROM TBL_TIPO_PLAZO_ENTREGA ORDER BY TPE_ID";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                    {
                        oda.Fill(dt);
                    }
                }
                con.Close();
            }
            return dt;
        }

        public DataTable selectLugarEjec() 
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "SELECT TLEJ_ID, TLEJ_NOMBRE FROM TBL_TIPO_LUGAR_EJEC ORDER BY TLEJ_ID";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                    {
                        oda.Fill(dt);
                    }
                }
                con.Close();
            }
            return dt;
        }

        public DataTable selectLugarEntr() 
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "SELECT TLE_ID, TLE_NOMBRE FROM TBL_TIPO_LUGAR_ENTREGA ORDER BY TLE_ID";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                    {
                        oda.Fill(dt);
                    }
                }
                con.Close();
            }
            return dt;
        }

        public DataTable selectGarantia() 
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "SELECT TG_ID, TG_NOMBRE FROM TBL_TIPO_GARANTIA ORDER BY TG_ID";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                    {
                        oda.Fill(dt);
                    }
                }
                con.Close();
            }
            return dt;
        }

        public DataTable selectGarantiaVal() 
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "SELECT TVG_ID, TVG_NOMBRE FROM TBL_TIPO_VALI_GARANTIA ORDER BY TVG_ID";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                    {
                        oda.Fill(dt);
                    }
                }
                con.Close();
            }
            return dt;
        }

        public DataTable selectJefe() 
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "SELECT JEF_ID, USR_NOMBRE, USR_APPAT, JEF_AREA, USR_USRPC FROM TBL_USUARIO JOIN TBL_JEFE USING(USR_ID) ORDER BY USR_NOMBRE";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                    {
                        oda.Fill(dt);
                    }
                }
                con.Close();
            }
            return dt;
        }

        public DataTable selectDatoJefe() 
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "SELECT JEF_ID, JEF_AREA, USR_USRPC FROM TBL_USUARIO JOIN TBL_JEFE USING(USR_ID)";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                    {
                        oda.Fill(dt);
                    }
                }
                con.Close();
            }
            return dt;
        }

        public DataTable selectRegion() 
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "SELECT REG_ID, REG_NOMBRE, REG_PRECIO FROM TBL_REGION ORDER BY REG_NOMBRE";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                    {
                        oda.Fill(dt);
                    }
                }
                con.Close();
            }
            return dt;
        }

        public DataTable selectEnvio() 
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "SELECT TEN_ID, TEN_NOMBRE FROM TBL_TIPO_ENVIO ORDER BY TEN_ID";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                    {
                        oda.Fill(dt);
                    }
                }
                con.Close();
            }
            return dt;
        }

        public DataTable selectLugar()
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "SELECT LUG_ID, LUG_NOMBRE, LUG_DIVISA FROM TBL_LUGAR ORDER BY LUG_ID";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                    {
                        oda.Fill(dt);
                    }
                }
                con.Close();
            }
            return dt;
        }

        public DataTable selectTextFactura() 
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "SELECT * FROM TBL_TXT_FACTURA ORDER BY TXTF_ID";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd)) 
                    {
                        oda.Fill(dt);
                    }
                }
                con.Close();
            }
            return dt;
        }

        public DataTable selectTextPentrega() 
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "SELECT * FROM TBL_TXT_PENTREGA ORDER BY TXTPE_ID";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                    {
                        oda.Fill(dt);
                    }
                }
                con.Close();
            }
            return dt;
        }

        public DataTable selectTextTipoCliente() 
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "SELECT * FROM TBL_TIPO_CLIENTE ORDER BY TIPOCLI_ID";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd)) 
                    {
                        oda.Fill(dt);
                    }
                }
                con.Close();
            }

            return dt;
        }

        public DataTable selectTextEstadoCliente() 
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "SELECT * FROM TBL_ESTADO_CLIENTE ORDER BY ESTCLI_ID";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd)) 
                    {
                        oda.Fill(dt);
                    }
                }
                con.Close();
            }

            return dt;
        }

        public DataTable selectEstadoDetCot() 
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "SELECT * FROM TBL_ESTADO_DET_COTIZACION ORDER BY DCE_ID";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd)) 
                    {
                        oda.Fill(dt);
                    }
                }
                con.Close();
            }

            return dt;
        }

        #region Select Para Criterios de Busqueda Cotizacion

        public DataTable selectIdCotizacion() 
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "SELECT COT_ID FROM TBL_COTIZACION ORDER BY COT_NUMERO";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd)) 
                    {
                        oda.Fill(dt);
                    }
                }
                con.Close();
            }
            return dt;
        }

        public DataTable selectNroCotizacion() 
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "SELECT COT_NUMERO FROM TBL_COTIZACION ORDER BY COT_NUMERO";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                    {
                        oda.Fill(dt);
                    }
                }
                con.Close();
            }
            return dt;
        }

        public DataTable selectEstadoCotizacion() 
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "SELECT EC_ID, EC_NOMBRE FROM TBL_ESTADO_COTIZACION WHERE EC_UN_ID IN ('DUO','CAL') ORDER BY EC_ID";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                    {
                        oda.Fill(dt);
                    }
                }
                con.Close();
            }
            return dt;
        }

        public DataTable selectClienteCotizacion()
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                con.BeginTransaction();
                String qryproc = "SP_SPAC_SEARCH_CLIENTE";
                using (OracleCommand cmdproc = new OracleCommand(qryproc, con))
                {
                    cmdproc.CommandType = CommandType.StoredProcedure;

                    cmdproc.Parameters.Add(new OracleParameter("P_NOMCLI", OracleDbType.Varchar2)).Value = null;
                    cmdproc.Parameters["P_NOMCLI"].Direction = ParameterDirection.Input;

                    cmdproc.Parameters.Add(new OracleParameter("P_DIRECCION", OracleDbType.Varchar2)).Value = null;
                    cmdproc.Parameters["P_DIRECCION"].Direction = ParameterDirection.Input;

                    cmdproc.Parameters.Add(new OracleParameter("P_TIPO_CLIENTE", OracleDbType.Int32)).Value = null;
                    cmdproc.Parameters["P_TIPO_CLIENTE"].Direction = ParameterDirection.Input;

                    cmdproc.Parameters.Add(new OracleParameter("P_ESTADO", OracleDbType.Int32)).Value = null;
                    cmdproc.Parameters["P_ESTADO"].Direction = ParameterDirection.Input;

                    cmdproc.ExecuteNonQuery();
                }


                String qry = "SELECT DISTINCT ID_CLIENTE, NOMBRE FROM TBL_SPAC_SEARCH_CLIENTE_TMP GROUP BY ID_CLIENTE ORDER BY NOMBRE";
                             //"SELECT ID_CLIENTE, NOMBRE FROM TBL_SPAC_SEARCH_CLIENTE_TMP GROUP BY ID_CLIENTE ORDER BY NOMBRE";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd)) 
                    {
                        oda.Fill(dt);
                    }
                }

            }
            return dt;
        }

        #endregion

        public DataTable selectLineaProd() 
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "SELECT * FROM TBL_LINEA_PRODUCTO ORDER BY LP_NOMBRE";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd)) 
                    {
                        oda.Fill(dt);
                    }
                }
                con.Close();
            }
            return dt;
        }

        public DataTable selectMagnitud(int cod_sys) 
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                con.BeginTransaction();
                String qry_sp = "SP_SPAC_SEARCH_ESPECIALIDAD";
                using (OracleCommand cmd_sp = new OracleCommand(qry_sp, con)) 
                {
                    cmd_sp.CommandType = CommandType.StoredProcedure;

                    cmd_sp.Parameters.Add(new OracleParameter("P_ID_SISTEMA", OracleDbType.Int32)).Value = cod_sys;
                    cmd_sp.Parameters["P_ID_SISTEMA"].Direction = ParameterDirection.Input;

                    cmd_sp.ExecuteNonQuery();
                }

                String qry = "SELECT * FROM TBL_SPAC_SEARCH_ESPECIALID_TMP ORDER BY NOMBRE";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd)) 
                    {
                        oda.Fill(dt);
                    }
                }
                con.Close();
            }

            return dt;
        }

        public DataTable selectFuncionMagnitud(int id_mag, int id_sys) 
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                con.BeginTransaction();
                String qry_u = "SP_SPAC_SEARCH_MAGFUN";
                using (OracleCommand cmd_u = new OracleCommand(qry_u, con)) 
                {
                    cmd_u.CommandType = CommandType.StoredProcedure;

                    cmd_u.Parameters.Add(new OracleParameter("P_ESPECIALIDAD", OracleDbType.Int32)).Value = null;
                    cmd_u.Parameters["P_ESPECIALIDAD"].Direction = ParameterDirection.Input;

                    cmd_u.Parameters.Add(new OracleParameter("P_ID_SISTEMA", OracleDbType.Int32)).Value = id_sys;
                    cmd_u.Parameters["P_ID_SISTEMA"].Direction = ParameterDirection.Input;

                    cmd_u.ExecuteNonQuery();
                }

                String qry_d = "SELECT ID_FUNCION, NOMBRE_FUNCION FROM TBL_SPAC_SEARCH_MAGFUN_TMP WHERE ID_ESPECIALIDAD = :ID_ESP";
                using (OracleCommand cmd_d = new OracleCommand(qry_d, con)) 
                {
                    cmd_d.CommandType = CommandType.Text;

                    cmd_d.Parameters.Add(new OracleParameter("ID_ESP", OracleDbType.Int32)).Value = id_mag;
                    cmd_d.Parameters["ID_ESP"].Direction = ParameterDirection.Input;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd_d)) 
                    {
                        oda.Fill(dt);
                    }
                }
                con.Close();
            }            

            return dt;
        }

        public DataTable selectFabricante() 
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                con.BeginTransaction();
                String qry_sp = "SP_SPAC_SEARCH_PLANTILLAS";
                using (OracleCommand cmd = new OracleCommand(qry_sp, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("P_NOMBRE_PLANTILLA", OracleDbType.Varchar2)).Value = null;
                    cmd.Parameters["P_NOMBRE_PLANTILLA"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_FAMILIA", OracleDbType.Varchar2)).Value = null;
                    cmd.Parameters["P_FAMILIA"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_NUMERO_PARTE", OracleDbType.Varchar2)).Value = null;
                    cmd.Parameters["P_NUMERO_PARTE"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_MODELO", OracleDbType.Varchar2)).Value = null;
                    cmd.Parameters["P_MODELO"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_TIPO", OracleDbType.Int32)).Value = null;
                    cmd.Parameters["P_TIPO"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_ESTADO", OracleDbType.Int32)).Value = null;
                    cmd.Parameters["P_ESTADO"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_ID_SISTEMA", OracleDbType.Int32)).Value = 2;
                    cmd.Parameters["P_ID_SISTEMA"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();

                }

                String qry = "SELECT DISTINCT LTRIM(FABRICANTE) NOM_FABRICANTE FROM TBL_SPAC_SEARCH_PLANTILLAS_TMP WHERE FABRICANTE IS NOT NULL ORDER BY LTRIM(FABRICANTE)";
                using (OracleCommand cmd_s = new OracleCommand(qry, con)) 
                {
                    cmd_s.CommandType = CommandType.Text;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd_s)) 
                    {
                        oda.Fill(dt);
                    }
                }
                con.Close();
            }

            return dt;
        }

        public String selectMailVendedor(int idven)
        {
            String mv = "";

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "FN_MANCAL_GET_INFO_VENDEDOR";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("RETMAIL", OracleDbType.Varchar2, 100)).Direction = ParameterDirection.ReturnValue;

                    cmd.Parameters.Add(new OracleParameter("IDVENDEDOR", OracleDbType.Int32)).Value = idven;
                    cmd.Parameters["IDVENDEDOR"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();

                    mv = cmd.Parameters["RETMAIL"].Value.ToString().Trim();
                }
                con.Close();
            }
            return mv;
        }

        public DataSet selectDatoAceptadoPor(int jefe_id) 
        {
            DataSet ds = new DataSet();

            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "FN_MANCAL_GET_DATO_JEFE";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("CUR_DATO_JEFE", OracleDbType.RefCursor)).Direction = ParameterDirection.ReturnValue;

                    cmd.Parameters.Add(new OracleParameter("P_JEFE_ID", OracleDbType.Int32)).Value = jefe_id;
                    cmd.Parameters["P_JEFE_ID"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd)) 
                    {
                        oda.Fill(ds, "CUR_DATO_JEFE");
                    }
                }
                con.Close();
            }
            return ds;
        }

        public DataTable selectClienteBusca() 
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                con.BeginTransaction();
                String qryproc = "SP_SPAC_SEARCH_CLIENTE";
                using (OracleCommand cmdproc = new OracleCommand(qryproc, con))
                {
                    cmdproc.CommandType = CommandType.StoredProcedure;

                    cmdproc.Parameters.Add(new OracleParameter("P_NOMCLI", OracleDbType.Varchar2)).Value = null;
                    cmdproc.Parameters["P_NOMCLI"].Direction = ParameterDirection.Input;

                    cmdproc.Parameters.Add(new OracleParameter("P_DIRECCION", OracleDbType.Varchar2)).Value = null;
                    cmdproc.Parameters["P_DIRECCION"].Direction = ParameterDirection.Input;

                    cmdproc.Parameters.Add(new OracleParameter("P_TIPO_CLIENTE", OracleDbType.Int32)).Value = null;
                    cmdproc.Parameters["P_TIPO_CLIENTE"].Direction = ParameterDirection.Input;

                    cmdproc.Parameters.Add(new OracleParameter("P_ESTADO", OracleDbType.Int32)).Value = null;
                    cmdproc.Parameters["P_ESTADO"].Direction = ParameterDirection.Input;

                    cmdproc.ExecuteNonQuery();
                }


                String qry = "SELECT ID_CLIENTE, NVL(NOMBRE_CONTACTO, 'NN') || ' | ' || NOMBRE NOM_CLI FROM TBL_SPAC_SEARCH_CLIENTE_TMP ORDER BY NOM_CLI";
                //"SELECT ID_CLIENTE, NOMBRE FROM TBL_SPAC_SEARCH_CLIENTE_TMP GROUP BY ID_CLIENTE ORDER BY NOMBRE";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                    {
                        oda.Fill(dt);
                    }
                }

            }
            return dt;
        }

        public DataSet selectFechaDivisa() 
        {
            DataSet ds = new DataSet();

            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "FN_MANCAL_GET_FECHAS";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("CUR_FECHAS", OracleDbType.RefCursor)).Direction = ParameterDirection.ReturnValue;

                    cmd.ExecuteNonQuery();

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd)) 
                    {
                        oda.Fill(ds, "CUR_FECHAS");
                    }
                }
                con.Close();

            }

            return ds;
        }

        //FUNCION QUE RETORNA UN DATASET CON LAS MAGNITUDES DISPONIBLES EN EL SISTEMA
        //EN ESTE CASO RETORNA SOLO LAS MAGNITUDES QUE ESTAN DISPONIBLES A PARTIR DE LAS PLANTILLAS 
        public DataTable selectMagnitudDispo() 
        {
            DataTable dt = new DataTable();
            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                con.BeginTransaction();
                String qry_proc = "SP_SPAC_SEARCH_PLANTILLAS";
                using (OracleCommand cmd_proc = new OracleCommand(qry_proc, con))
                {
                    cmd_proc.CommandType = CommandType.StoredProcedure;

                    cmd_proc.Parameters.Add(new OracleParameter("P_NOMBRE_PLANTILLA", OracleDbType.Varchar2)).Value = null;//NOMBRE EQUIPO
                    cmd_proc.Parameters["P_NOMBRE_PLANTILLA"].Direction = ParameterDirection.Input;

                    cmd_proc.Parameters.Add(new OracleParameter("P_FAMILIA", OracleDbType.Varchar2)).Value = null;
                    cmd_proc.Parameters["P_FAMILIA"].Direction = ParameterDirection.Input;

                    cmd_proc.Parameters.Add(new OracleParameter("P_NUMERO_PARTE", OracleDbType.Varchar2)).Value = null;//NUMERO DE PARTE
                    cmd_proc.Parameters["P_NUMERO_PARTE"].Direction = ParameterDirection.Input;

                    cmd_proc.Parameters.Add(new OracleParameter("P_MODELO", OracleDbType.Varchar2)).Value = null;//NOMBRE DEL MODELO
                    cmd_proc.Parameters["P_MODELO"].Direction = ParameterDirection.Input;

                    cmd_proc.Parameters.Add(new OracleParameter("P_TIPO", OracleDbType.Varchar2)).Value = null;
                    cmd_proc.Parameters["P_TIPO"].Direction = ParameterDirection.Input;

                    cmd_proc.Parameters.Add(new OracleParameter("P_ESTADO", OracleDbType.Varchar2)).Value = null;//ESTADO DEL EQUIPO
                    cmd_proc.Parameters["P_ESTADO"].Direction = ParameterDirection.Input;

                    cmd_proc.Parameters.Add(new OracleParameter("P_ID_SISTEMA", OracleDbType.Int32)).Value = "2";//ID DE SISTEMA 2 PARA SIGEPAC
                    cmd_proc.Parameters["P_ID_SISTEMA"].Direction = ParameterDirection.Input;

                    cmd_proc.ExecuteNonQuery();
                }
                
                String qry = "SELECT DISTINCT MAGNITUD, MAGNITUD_NOM FROM TBL_SPAC_SEARCH_PLANTILLAS_TMP ORDER BY MAGNITUD_NOM";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd)) 
                    {
                        oda.Fill(dt);
                    }
                    
                }
                con.Close();
            }
            return dt;
        }

        public DataTable selectFamiliaByMagnitud(int idmag) 
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                con.BeginTransaction();
                String qry_proc = "SP_SPAC_SEARCH_PLANTILLAS";
                using (OracleCommand cmd_proc = new OracleCommand(qry_proc, con))
                {
                    cmd_proc.CommandType = CommandType.StoredProcedure;

                    cmd_proc.Parameters.Add(new OracleParameter("P_NOMBRE_PLANTILLA", OracleDbType.Varchar2)).Value = null;//NOMBRE EQUIPO
                    cmd_proc.Parameters["P_NOMBRE_PLANTILLA"].Direction = ParameterDirection.Input;

                    cmd_proc.Parameters.Add(new OracleParameter("P_FAMILIA", OracleDbType.Varchar2)).Value = null;
                    cmd_proc.Parameters["P_FAMILIA"].Direction = ParameterDirection.Input;

                    cmd_proc.Parameters.Add(new OracleParameter("P_NUMERO_PARTE", OracleDbType.Varchar2)).Value = null;//NUMERO DE PARTE
                    cmd_proc.Parameters["P_NUMERO_PARTE"].Direction = ParameterDirection.Input;

                    cmd_proc.Parameters.Add(new OracleParameter("P_MODELO", OracleDbType.Varchar2)).Value = null;//NOMBRE DEL MODELO
                    cmd_proc.Parameters["P_MODELO"].Direction = ParameterDirection.Input;

                    cmd_proc.Parameters.Add(new OracleParameter("P_TIPO", OracleDbType.Varchar2)).Value = null;
                    cmd_proc.Parameters["P_TIPO"].Direction = ParameterDirection.Input;

                    cmd_proc.Parameters.Add(new OracleParameter("P_ESTADO", OracleDbType.Varchar2)).Value = null;//ESTADO DEL EQUIPO
                    cmd_proc.Parameters["P_ESTADO"].Direction = ParameterDirection.Input;

                    cmd_proc.Parameters.Add(new OracleParameter("P_ID_SISTEMA", OracleDbType.Int32)).Value = "2";//ID DE SISTEMA 2 PARA SIGEPAC
                    cmd_proc.Parameters["P_ID_SISTEMA"].Direction = ParameterDirection.Input;

                    cmd_proc.ExecuteNonQuery();
                }

                String qry = "SELECT DISTINCT FAMILIA, FAMILIA_NOM FROM TBL_SPAC_SEARCH_PLANTILLAS_TMP WHERE MAGNITUD = :MAG_ID ORDER BY FAMILIA_NOM";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new OracleParameter("MAG_ID", OracleDbType.Int32)).Value = idmag;
                    cmd.Parameters["MAG_ID"].Direction = ParameterDirection.Input;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                    {
                        oda.Fill(dt);
                    }

                }
                con.Close();
            }

            return dt;
        }
    }
}
