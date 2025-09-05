using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace VisitasExternas.Models
{
    public class Visita
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string NomeCliente { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime DataVisita { get; set; }
    }
}
