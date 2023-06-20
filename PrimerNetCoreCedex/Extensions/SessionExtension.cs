using Newtonsoft.Json;
using PrimerNetCoreCedex.Models;

namespace PrimerNetCoreCedex.Extensions
{
    public static class SessionExtension
    {
        //QUEREMOS ALMACENAR EMPLEADOS, ES DECIR UNA LISTA DE EMPLEADOS
        //VAMOS A REALIZAR UN METODO QUE RECIBIRA LA LISTA DE EMPLEADOS
        //LA CONVIERTE A JSON Y LA ALMACENA COMO STRING
        //DENTRO DE SESSION
        public static void SetObject
            (this ISession session, string key, List<Empleado> empleados)
        {
            string jsonEmpleados = JsonConvert.SerializeObject(empleados);
            session.SetString(key, jsonEmpleados);
        }

        //NECESITAMOS UN METODO PARA PODER RECUPERAR LOS EMPLEADOS DE 
        //SESSION.  NOS DARAN LA KEY Y LE DEVOLVEMOS EL OBJETO EMPLEADO
        public static List<Empleado> GetObject
            (this ISession session, string key)
        {
            //RECUPERAMOS LOS DATOS DE SESSION
            string jsonEmpleados = session.GetString(key);
            if (jsonEmpleados == null)
            {
                return null;
            }
            else
            {
                List<Empleado> empleados = 
                    JsonConvert.DeserializeObject<List<Empleado>>(jsonEmpleados);
                return empleados;
            }
        }
    }
}
