using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_3_TABD
{
    class Consumo
    {
        private int año;
        private int mes;
        private int id_servicio;
        private double valor_consumo;
        private double valor_total;
        private double valor_unidad;

        public Consumo(int año, int mes, int id_servicio, double valor_consumo, double valor_total, double valor_unidad)
        {
            this.año = año;
            this.mes = mes;
            this.id_servicio = id_servicio;
            this.valor_consumo = valor_consumo;
            this.valor_total = valor_total;
            this.valor_unidad = valor_unidad;
        }

        public int Año { get => año; set => año = value; }
        public int Mes { get => mes; set => mes = value; }
        public int Id_servicio { get => id_servicio; set => id_servicio = value; }
        public double Valor_consumo { get => valor_consumo; set => valor_consumo = value; }
        public double Valor_total { get => valor_total; set => valor_total = value; }
        public double Valor_unidad { get => valor_unidad; set => valor_unidad = value; }
    }
}
