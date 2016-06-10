using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private Dados.LojaAPPDataContext dc = new Dados.LojaAPPDataContext();

        public void InsertFabricante(Modelo.Fabricante f)
        {
            if(f==null)
            {
                throw new ArgumentNullException("Fabricante nulo");
            }
            dc.Fabricantes.InsertOnSubmit(new Dados.Fabricante { Id = f.Id, Descricao = f.Descricao });
            dc.SubmitChanges();
        }

        public void InsertVeiculo(Modelo.Veiculo v)
        {
            if(v==null)
            {
                throw new ArgumentNullException("Veiculo Nulo");
            }
            dc.Veiculos.InsertOnSubmit(new Dados.Veiculo { Id = v.Id, Ano = v.Ano, Modelo = v.Modelo, IdFabricante = v.IdFabricante, DataCompra = v.DataCompra, DataVenda = v.DataVenda, PrecoVenda = v.PrecoVenda, ValorCompra = v.ValorCompra, ValorVenda = v.ValorVenda });
            dc.SubmitChanges();
        }

        public List<Modelo.Fabricante> SelectFabricante()
        {
            var obj = from f in dc.Fabricantes select f;
            List<Modelo.Fabricante> fabricantes = new List<Modelo.Fabricante>();
            foreach(Dados.Fabricante x in obj)
            {
                Modelo.Fabricante z = new Modelo.Fabricante
                {
                    Id = x.Id,
                    Descricao = x.Descricao
                };
                fabricantes.Add(z);
            }
            return fabricantes;
        }

        public List<Modelo.Veiculo> SelectVeiculo()
        {
            

            var obj = from f in dc.Veiculos select f;
            List<Modelo.Veiculo> veiculos = new List<Modelo.Veiculo>();
            foreach(Dados.Veiculo x in obj)
            {
                Modelo.Veiculo v = new Modelo.Veiculo
                {
                    Id = x.Id,
                    Ano = Convert.ToInt32(x.Ano),
                    Modelo = x.Modelo,
                    IdFabricante = Convert.ToInt32(x.IdFabricante),
                    DataCompra = Convert.ToDateTime(x.DataCompra),
                    DataVenda = Convert.ToDateTime(x.DataVenda),
                    PrecoVenda = Convert.ToDecimal(x.PrecoVenda),
                    ValorCompra = Convert.ToDecimal(x.ValorCompra),
                    ValorVenda = Convert.ToDecimal(x.ValorVenda)
                };
                veiculos.Add(v);
            }
            return veiculos;
        }

        public void UpdateFabricante(Modelo.Fabricante f)
        {
            if(f==null)
            {
                throw new ArgumentNullException("Fabricante nulo");
            }
            Dados.Fabricante f1 = (from x in dc.Fabricantes where x.Id == f.Id select x).Single();
            f1.Descricao = f.Descricao;
            dc.SubmitChanges();
        }

        public void UpdateVeiculo(Modelo.Veiculo v)
        {
            if(v==null)
            {
                throw new ArgumentNullException("Veiculo nulo");
            }
            Dados.Veiculo v1 = (from x in dc.Veiculos where x.Id == v.Id select x).Single();
            v1.Modelo = v.Modelo;
            v1.PrecoVenda = v.PrecoVenda;
            dc.SubmitChanges(); 
        }

        public void DeleteFabricante(Modelo.Fabricante f)
        {
            if (f == null)
            {
                throw new ArgumentNullException("Fabricante nulo");
            }
            Dados.Fabricante f1 = (from x in dc.Fabricantes where x.Id == f.Id select x).Single();
            dc.Fabricantes.DeleteOnSubmit(f1);
            dc.SubmitChanges();
        }

        public void DeleteVeiculo(Modelo.Veiculo v)
        {
            if(v==null)
            {
                throw new ArgumentNullException("Veiculo nulo");
            }
            Dados.Veiculo v1 = (from x in dc.Veiculos where x.Id == v.Id select x).Single();
            dc.Veiculos.DeleteOnSubmit(v1);
            dc.SubmitChanges();
        }
    }
}
