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
            (this ISession session, string key, object value)
        {
            string json = JsonConvert.SerializeObject(value);
            session.SetString(key, json);
        }

        //NECESITAMOS UN METODO PARA PODER RECUPERAR CUALQUIER OBJETO
        //DE SESSION.  NOS DARAN LA KEY Y LE DEVOLVEMOS CUALQUIER OBJETO
        public static T GetObject<T>
            (this ISession session, string key)
        {
            //RECUPERAMOS LOS DATOS DE SESSION
            string json = session.GetString(key);
            if (json == null)
            {
                return default(T);
            }
            else
            {
                T data = 
                    JsonConvert.DeserializeObject<T>(json);
                return data;
            }
        }
    }
}
