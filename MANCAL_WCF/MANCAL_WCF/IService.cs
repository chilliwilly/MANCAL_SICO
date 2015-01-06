using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MANCAL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService
    {

        [OperationContract]
        List<Usuario> listaUsuario();

        [OperationContract]
        List<Menu> listaMenu(int nro_perfil);

        [OperationContract]
        void updateUsrPassword(String usr_pwd, String new_pwd);

        // TODO: agregue aquí sus operaciones de servicio
    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class Usuario
    {
        [DataMember]
        public String UsrNom { get; set; }

        [DataMember]
        public String UsrPwd { get; set; }

        [DataMember]
        public int UsrPerfil { get; set; }

        [DataMember]
        public int UsrSta { get; set; }
    }

    [DataContract]
    public class Menu 
    {
        [DataMember]
        public int MenuId { get; set; }

        [DataMember]
        public String MenuNom { get; set; }

        [DataMember]
        public int MenuGrp { get; set; }

        [DataMember]
        public String MenuUrl { get; set; }
    }
}
