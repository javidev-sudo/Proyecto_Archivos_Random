using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proyecto_ArchR_javi
{
    class ArchProd
    {
        private string narch;
        private FileStream stream;
        private BinaryWriter writer1;
        private BinaryReader reader1;
        private int cod;
        private string desc;
        private double cant;
        private double cost;
        private bool est;

        public ArchProd()
        {
            narch = "";
        }

        public void Abrir_Grabar(string narch1)
        {
            narch = narch1;
            stream = new FileStream(narch, FileMode.CreateNew, FileAccess.Write);
            writer1 = new BinaryWriter(stream);
        }
        // diferencias
        public void Grabar(int cod1, string desc1, double cant1, double cost1, bool est1)
        {
            cod = cod1;
            desc = desc1;
            cant = cant1;
            cost = cost1;
            est = est1;
            writer1.Write(cod);
            desc = desc1.PadRight(28,' ').Substring(0,28);      
            writer1.Write(desc);
            writer1.Write(cant);
            writer1.Write(cost);
            writer1.Write(est);

        }

        public void Cerrar_Grabar()
        {
            writer1.Close();
            stream.Close();
        }

        public void Abrir_Leer(string narch1)
        {
            narch = narch1;
            stream = new FileStream(narch, FileMode.Open, FileAccess.Read);
            reader1 = new BinaryReader(stream);
        }

        public void leer(ref int cod1, ref string desc1, ref double cant1, ref double cost1, ref bool est1)
        {
            cod1 = reader1.ReadInt32();
            desc1 = reader1.ReadString();
            cant1 = reader1.ReadDouble();
            cost1 = reader1.ReadDouble();
            est = reader1.ReadBoolean();
        }

        public void Cerrar_Leer()
        {
            reader1.Close();
            stream.Close();
        }

        public bool VerifFin()
        {
            return stream.Position == stream.Length;
        }
    }
}
