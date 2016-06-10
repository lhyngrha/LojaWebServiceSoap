using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Veiculo
    {
        ServiceReference1.Service1Client sr = new ServiceReference1.Service1Client();
        public void Insert(Modelo.Veiculo v)
        {
            List<Modelo.Veiculo> veiculos = Select();
            if (!veiculos.Exists(a => a.Id == v.Id))
            {
                sr.InsertVeiculo(v);
            }
        }

        public List<Modelo.Veiculo> Select()
        {
            List<Modelo.Veiculo> veiculos = sr.SelectVeiculo().ToList();
            return veiculos;
        }

        public void Update(Modelo.Veiculo v)
        {
            List<Modelo.Veiculo> veiculos = Select();
            if (veiculos.Exists(a => a.Id == v.Id))
            {
                sr.UpdateVeiculo(v);
            }
        }

        public void Delete(Modelo.Veiculo v)
        {
            List<Modelo.Veiculo> veiculos = Select();
            if (veiculos.Exists(a => a.Id == v.Id))
            {
                sr.DeleteVeiculo(v);
            }
        }
    }
}
