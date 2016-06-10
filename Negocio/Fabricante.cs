using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Fabricante
    {
        ServiceReference1.Service1Client sr = new ServiceReference1.Service1Client();
        public void Insert(Modelo.Fabricante f)
        {
            List<Modelo.Fabricante> fabricantes = Select();
            if (!fabricantes.Exists(a => a.Id == f.Id))
            {
                sr.InsertFabricante(f);
            }
        }

        public List<Modelo.Fabricante> Select()
        {
            List<Modelo.Fabricante> fabricantes = sr.SelectFabricante().ToList();
            return fabricantes;
        }

        public void Update(Modelo.Fabricante f)
        {
            List<Modelo.Fabricante> fabricantes = Select();
            if (fabricantes.Exists(a => a.Id == f.Id))
            {
                sr.UpdateFabricante(f);
            }
        }

        public void Delete(Modelo.Fabricante f)
        {
            List<Modelo.Fabricante> fabricantes = Select();
            if (fabricantes.Exists(a => a.Id == f.Id))
            {
                sr.DeleteFabricante(f);
            }
        }
    }
}
