using Cinema_Rinku_Empleados.DTO;
using Cinema_Rinku_Empleados.Models;
using Microsoft.AspNetCore.Http;
using System.Data;
using System.Data.SqlClient;

namespace Cinema_Rinku_Empleados.Repositorio
{
    public class EmpleadosRepositorio
    {
        //public IConfiguration Configuration { get; set; }
        //public EmpleadosRepositorio(IConfiguration configuration)
        //{
        //    configuration = configuration;
        //}
        string conection = "Data Source=33924-VALTRE\\SQLEXPRESS;Initial Catalog=CinemaRinku;Integrated Security=True";

        public string Guardar(EmpleadosModel model)
        {
            string respuesta = "";
            using (SqlConnection con = new(conection))
            {
                using (SqlCommand cmd = new("Procedure_Alta_Empleado", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@NumEmpleado", SqlDbType.Int).Value = model.NumeroEmpleado;
                    cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = model.Nombre;
                    cmd.Parameters.Add("@ApellidoP", SqlDbType.VarChar).Value = model.ApellidoP;
                    cmd.Parameters.Add("@ApellidoM", SqlDbType.VarChar).Value = model.ApellidoM;
                    cmd.Parameters.Add("@IdRol", SqlDbType.Int).Value = model.RolId;
                    cmd.Parameters.Add("@Respuesta", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToString(cmd.Parameters["@Respuesta"].Value.ToString());
                    con.Close();
                }
            }
            return respuesta;
        }
        public List<Roles> ObtieneRoles()
        {
            List<Roles> listaRoles = new List<Roles>();

            using (SqlConnection con = new(conection))
            {
                using (SqlCommand cmd = new("Procedure_Obtiene_Roles", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Roles item = new Roles();
                        item.RolId = dr.GetInt32(0);
                        item.Rol = dr.GetString(1);
                        listaRoles.Add(item);
                    }

                    cmd.Dispose();
                    con.Close();
                }
            }
            return listaRoles;
        }
        public List<EmpleadosModel> ObtieneTodosEmpleados()
        {
            List<EmpleadosModel> listaEmpleados = new List<EmpleadosModel>();

            using (SqlConnection con = new(conection))
            {
                using (SqlCommand cmd = new("Procedure_Obtiene_Empleados", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        EmpleadosModel item = new EmpleadosModel();
                        item.NumeroEmpleado = dr.GetInt32(0);
                        item.Rol = dr.GetString(1);
                        item.Nombre =dr.GetString(2);
                        item.ApellidoP = dr.GetString(3);
                        item.ApellidoM = dr.GetString(4);
                        listaEmpleados.Add(item);
                    }

                    cmd.Dispose();
                    con.Close();
                }
            }
            return listaEmpleados;
        }
        public EmpleadosDTO ObtieneEmpleadoId(int NumEmpleado)
        {
            EmpleadosDTO item= null;
            using (SqlConnection con = new(conection))
            {
                using (SqlCommand cmd = new("Procedure_OtieneEmpleado_Id", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@NumEmpleado", SqlDbType.Int).Value = NumEmpleado;

                   con.Open();
                   SqlDataReader dr= cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        item = new EmpleadosDTO();
                        item.NumeroEmpleado = dr.GetInt32(0);
                        item.RolId = dr.GetInt32(1);
                        item.Nombre = dr.GetString(2);
                        item.ApellidoP = dr.GetString(3);
                        item.ApellidoM = dr.GetString(4);

                    }
                    con.Dispose();
                    con.Close();
                }
            }
            return item;
        }
        public string Actualizar(EmpleadosModel model)
        {
            string respuesta = "";
            using (SqlConnection con = new(conection))
            {
                using (SqlCommand cmd = new("", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@NumEmpleado", SqlDbType.Int).Value = model.NumeroEmpleado;
                    cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = model.Nombre;
                    cmd.Parameters.Add("@ApellidoP", SqlDbType.VarChar).Value = model.ApellidoP;
                    cmd.Parameters.Add("@ApellidoM", SqlDbType.VarChar).Value = model.ApellidoM;
                    cmd.Parameters.Add("@IdRol", SqlDbType.Int).Value = model.RolId;
                    cmd.Parameters.Add("@Respuesta", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToString(cmd.Parameters["@Respuesta"].Value.ToString());
                    con.Close();
                }
            }
            return respuesta;
        }
    }
}
