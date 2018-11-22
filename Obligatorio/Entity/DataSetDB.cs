using BaseAccess;
using Dominio;
using Entity;
using InterfazBaseAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class DataSetDB : IDataSetDB
    {
        public void AgregarDataSet(DataSet dataSet)
        {
            try
            {
                using (ContextDB aContext = new ContextDB())
                {
                    aContext.DataSets.Add(dataSet);
                    aContext.SaveChanges();
                }
            }
            catch (DbEntityValidationException m)
            {
                throw new Exception(m.Message);
            }
        } 
        public void modificarDataSet(DataSet dataSet)
        {
            try
            {
                using (ContextDB context = new ContextDB())
                {
                    context.Entry(dataSet).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException m)
            {
                throw new Exception(m.Message);
            }
        }
        public bool ExisteDataSet(string nombreDataSet)
        {
            try
            {
                bool exists = false;
                using (ContextDB context = new ContextDB())
                {
                    foreach (DataSet dataSetFromColecction in context.DataSets)
                    {
                        if (nombreDataSet.Equals(dataSetFromColecction.nombre))
                        {
                            exists = true;
                        }
                    }
                }
                return exists;
            }
            catch (DbEntityValidationException m)
            {
                throw new Exception(m.Message);
            }
        }
        public DataSet GetDataSet(string nombreDataSet)
        {
            try
            {
                using (ContextDB context = new ContextDB())
                {
                    return context.DataSets.FirstOrDefault(dataSet => dataSet.nombre.Equals(nombreDataSet));
                }

            }
            catch (DbEntityValidationException m)
            {
                throw new Exception(m.Message);
            }
        }
        public List<DataSet> GetListaDataSet()
        {
            try
            {
                using (ContextDB context = new ContextDB())
                {
                    var query = context.DataSets;
                    context.SaveChanges();
                    return query.ToList<DataSet>();
                }
            }
            catch (DbEntityValidationException m)
            {
                throw new Exception(m.Message);
            }
        }
        public List<VariablesDataSet> GetRegistros(string nombreDataSet)
        {
            return GetDataSet(nombreDataSet).registros;
        }
    }
}
