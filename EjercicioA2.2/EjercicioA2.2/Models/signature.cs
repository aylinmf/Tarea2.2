using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioA2_2.Models
{
    public class signature
{
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Byte[] ArrayByteImage { get; set; }
    }
}
