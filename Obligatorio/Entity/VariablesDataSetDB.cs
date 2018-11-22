using BaseAccess;
using Dominio;
using InterfazBaseAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class VariablesDataSetDB : IVariablesDataSetDB
    {
        public void AgregarVariablesDataSet(VariablesDataSet variableDataSet)
        {
            try
            {
                using (ContextDB aContext = new ContextDB())
                {
                    aContext.VariablesDataSets.Add(variableDataSet);
                    aContext.SaveChanges();
                }
            }
            catch (DbEntityValidationException m)
            {
                throw new Exception(m.Message);
            }
        }
        public void modificarVariablesDataSet(VariablesDataSet variableDataSet)
        {
            try
            {
                using (ContextDB context = new ContextDB())
                {
                    context.Entry(variableDataSet).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException m)
            {
                throw new Exception(m.Message);
            }
        }
        public bool ExisteVariablesDataSet(string nombreVariablesDataSet)
        {
            try
            {
                bool exists = false;
                using (ContextDB context = new ContextDB())
                {
                    foreach (VariablesDataSet variableDataSetFromColecction in context.VariablesDataSets)
                    {
                        if (nombreVariablesDataSet.Equals(variableDataSetFromColecction.nombreVariable))
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
        public VariablesDataSet GetVariablesDataSet(string nombreVariablesDataSet)
        {
            try
            {
                using (ContextDB context = new ContextDB())
                {
                    return context.VariablesDataSets.FirstOrDefault(variableDataSets => variableDataSet.nombreVariable.Equals(nombreVariablesDataSet));
                }

            }
            catch (DbEntityValidationException m)
            {
                throw new Exception(m.Message);
            }
        }
        public List<VariablesDataSet> GetListaVariablesDataSet()
        {
            try
            {
                using (ContextDB context = new ContextDB())
                {
                    var query = context.VariablesDataSets;
                    context.SaveChanges();
                    return query.ToList<VariablesDataSet>();
                }
            }
            catch (DbEntityValidationException m)
            {
                throw new Exception(m.Message);
            }
        }
    }
}
