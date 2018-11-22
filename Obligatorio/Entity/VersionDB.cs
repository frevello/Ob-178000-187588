﻿using BaseAccess;
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
    public class VersionDB : IVersionDB
    {
        public void AgregarVersion(Dominio.Version version)
        {
            try
            {
                using (ContextDB aContext = new ContextDB())
                {
                    aContext.Versiones.Add(version);
                    aContext.SaveChanges();
                }
            }
            catch (DbEntityValidationException m)
            {
                throw new Exception(m.Message);
            }
        }
        public void ModificarVersion(Dominio.Version version)
        {
            try
            {
                using (ContextDB context = new ContextDB())
                {
                    context.Entry(version).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException m)
            {
                throw new Exception(m.Message);
            }
        }
        public bool ExisteVersion(string etiqueta)
        {
            try
            {
                bool exists = false;
                using (ContextDB context = new ContextDB())
                {
                    foreach (Dominio.Version versionFromColecction in context.Versiones)
                    {
                        if (etiqueta.Equals(versionFromColecction.etiqueta))
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
        public Dominio.Version GetVersion(string etiqueta)
        {
            try
            {
                using (ContextDB context = new ContextDB())
                {
                    return context.Versiones.FirstOrDefault(version => version.etiqueta.Equals(etiqueta));
                }

            }
            catch (DbEntityValidationException m)
            {
                throw new Exception(m.Message);
            }
        }
        public List<Dominio.Version> GetListaVersion()
        {
            try
            {
                using (ContextDB context = new ContextDB())
                {
                    var query = context.Versiones;
                    context.SaveChanges();
                    return query.ToList<Dominio.Version>();
                }
            }
            catch (DbEntityValidationException m)
            {
                throw new Exception(m.Message);
            }
        }
        public List<DataSet> GetListaDataSet(string etiqueta)
        {
            return GetVersion(etiqueta).datasets;
        }
    }
}
