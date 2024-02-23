using CapasDatos;
using CapasEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapasNegocio
{
    public class CN_Usuario
    {
        CD_Usuario _Usuario1 = new CD_Usuario();

        public DataTable CNObtenerUsuario()
        {
            return _Usuario1.CDObtenerUsuario();
        }

        public void CNAgregarUsuario(string Nombres, string Apellidos, string Dni, string Email, string Usuario, string Contraseña, string TipoUsuario, string Estado)
        {
            CE_Usuario _Usuario = new CE_Usuario();
            _Usuario.Nombres = Nombres;
            _Usuario.Apellidos = Apellidos;
            _Usuario.Dni = Dni;
            _Usuario.Email = Email;
            _Usuario.Usuario = Usuario;
            _Usuario.Contraseña = Contraseña;
            _Usuario.TipoUsuario = TipoUsuario;
            _Usuario.Estado = Estado;
            
            _Usuario1.CD_AgregarUsuario(_Usuario);

        }

        public void CNActualizarUsuario(string idUsuario, string Nombres, string Apellidos, string Dni, string Email, string Usuario, string Contraseña, string TipoUsuario, string Estado)
        {
            CE_Usuario _Usuario = new CE_Usuario();
            _Usuario.idUsuario = idUsuario;
            _Usuario.Nombres = Nombres;
            _Usuario.Apellidos = Apellidos;
            _Usuario.Dni = Dni;
            _Usuario.Email = Email;
            _Usuario.Usuario = Usuario;
            _Usuario.Contraseña = Contraseña;
            _Usuario.TipoUsuario = TipoUsuario;
            _Usuario.Estado = Estado;

            _Usuario1.CDModificarUsuario(_Usuario);
        }

        public void CNEliminarUsuario(string CodigoUsuario)
        {
            CE_Usuario _Usuario = new CE_Usuario();
            _Usuario.CodigoUsuario = CodigoUsuario;

            _Usuario1.CDEliminarUsuario(_Usuario);
        }

        public long NumeroCompra()
        {

            return _Usuario1.GetUltimoNumeroUsuario();

        }

        public DataTable CN_Buscar(string busqueda)
        {
            return _Usuario1.CD_buscar(busqueda);
        }

        public bool LoginUser(string user,string pass)
        {
            return _Usuario1.Login(user, pass);
        }
    }
}
