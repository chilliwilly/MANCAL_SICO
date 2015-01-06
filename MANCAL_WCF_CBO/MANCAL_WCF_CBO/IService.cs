using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.ServiceModel.Activation;

namespace MANCAL_WCF_CBO
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService
    {

        [OperationContract]
        List<TipoCotizacion> lsTipoCotizacionMan(String id_un);

        [OperationContract]
        List<Vendedor> lsVendedor(String id_un);

        [OperationContract]
        List<TipoTarifa> lsTarifa();

        [OperationContract]
        List<TipoTrabajo> lsTrabajo(String un, String forma);

        [OperationContract]
        List<TipoFactura> lsFactura();

        [OperationContract]
        List<TipoPagoFactura> lsPagoFactura();

        [OperationContract]
        List<TipoPlazoEntregaFac> lsPlazoEntregaFac();

        [OperationContract]
        List<TipoLugarEjec> lsLugarEjec();

        [OperationContract]
        List<TipoLugarEntr> lsLugarEntr();

        [OperationContract]
        List<TipoGarantia> lsGarantia();

        [OperationContract]
        List<TipoGarantiaVal> lsGarantiaVal();

        [OperationContract]
        List<Jefe> lsJefe();

        [OperationContract]
        Jefe datosJefe(Decimal id_jefe);

        [OperationContract]
        List<Region> lsRegion();

        [OperationContract]
        List<TipoEnvio> lsEnvio();

        [OperationContract]
        List<Lugar> lsLugar();
        // TODO: agregue aquí sus operaciones de servicio
    }

    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class TipoCotizacion 
    {
        [DataMember]
        public int id_tipocot { get; set; }

        [DataMember]
        public String nom_tipocot { get; set; }
    }

    [DataContract]
    public class Vendedor 
    {
        [DataMember]
        public int id_venta { get; set; }

        [DataMember]
        public String nom_venta { get; set; }
    }

    [DataContract]
    public class TipoTarifa 
    {
        [DataMember]
        public int id_tarifa { get; set; }

        [DataMember]
        public String nom_tarifa { get; set; }
    }

    [DataContract]
    public class TipoTrabajo 
    {
        [DataMember]
        public int idn_trabajo { get; set; }

        [DataMember]
        public String nom_trabajo { get; set; }
    }

    [DataContract]
    public class TipoFactura
    {
        [DataMember]
        public int idn_factura { get; set; }

        [DataMember]
        public String nom_factura { get; set; }
    }

    [DataContract]
    public class TipoPagoFactura
    {
        [DataMember]
        public int idn_pagofactura { get; set; }

        [DataMember]
        public String nom_pagofactura { get; set; }
    }

    [DataContract]
    public class TipoPlazoEntregaFac
    {
        [DataMember]
        public int idn_plazoentregafac { get; set; }

        [DataMember]
        public String nom_plazoentregafac { get; set; }
    }

    [DataContract]
    public class TipoLugarEjec 
    {
        [DataMember]
        public int idn_lugarejec { get; set; }

        [DataMember]
        public String nom_lugarejec { get; set; }
    }

    [DataContract]
    public class TipoLugarEntr 
    {
        [DataMember]
        public int idn_lugarentr { get; set; }

        [DataMember]
        public String nom_lugarentr { get; set; }
    }

    [DataContract]
    public class TipoGarantia 
    {
        [DataMember]
        public int idn_garantia { get; set; }

        [DataMember]
        public String nom_garantia { get; set; }
    }

    [DataContract]
    public class TipoGarantiaVal 
    {
        [DataMember]
        public int idn_garantiaval { get; set; }

        [DataMember]
        public String nom_garantiaval { get; set; }
    }

    [DataContract]
    public class Jefe 
    {
        [DataMember]
        public int idn_jefe { get; set; }

        [DataMember]
        public String nom_jefe { get; set; }

        [DataMember]
        public String car_jefe { get; set; }

        [DataMember]
        public String mai_jefe { get; set; }
    }

    [DataContract]
    public class Region 
    {
        [DataMember]
        public int idn_region { get; set; }

        [DataMember]
        public String nom_region { get; set; }
    }

    [DataContract]
    public class TipoEnvio 
    {
        [DataMember]
        public int idn_tipoenvio { get; set; }

        [DataMember]
        public String nom_tipoenvio { get; set; }
    }

    [DataContract]
    public class Lugar 
    {
        [DataMember]
        public int idn_lugar { get; set; }

        [DataMember]
        public String nom_lugar { get; set; }
    }
}
