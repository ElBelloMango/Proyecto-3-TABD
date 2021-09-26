using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_3_TABD
{
    class Consumo
    {
        private int id_consumo;
        private int año;
        private int mes;
        private int id_servicio;
        private double valor_consumo;
        private double valor_total;
        private double valor_unidad;

        public Consumo(int año, int mes, int id_servicio, double valor_consumo, double valor_total)
        {
            this.año = año;
            this.mes = mes;
            this.id_servicio = id_servicio;
            this.valor_consumo = valor_consumo;
            this.valor_total = valor_total;
            this.valor_unidad = valor_total/valor_consumo;
        }

        public Consumo(int id_consumo, int año, int mes, int id_servicio, double valor_consumo, double valor_total)
        {
            this.id_consumo = id_consumo;
            this.año = año;
            this.mes = mes;
            this.id_servicio = id_servicio;
            this.valor_consumo = valor_consumo;
            this.valor_total = valor_total;
            this.valor_unidad = valor_total / valor_consumo;
        }

        public int Id_consumo { get => id_consumo; set => id_consumo = value; }
        public int Año { get => año; set => año = value; }
        public int Mes { get => mes; set => mes = value; }
        public int Id_servicio { get => id_servicio; set => id_servicio = value; }
        public double Valor_consumo { get => valor_consumo; set => valor_consumo = value; }
        public double Valor_total { get => valor_total; set => valor_total = value; }
        public double Valor_unidad { get => valor_unidad; set => valor_unidad = value; }
        
    }
}
