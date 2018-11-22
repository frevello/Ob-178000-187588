using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Dominio;

namespace BaseAccess
{
    public class ContextDB : DbContext
    {
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Dominio.Version> Versiones { get; set; }
        public virtual DbSet<DataSet> DataSets { get; set; }
        public virtual DbSet<VariablesDataSet> VariablesDataSets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().HasMany(producto => producto.versiones).WithRequired();
            modelBuilder.Entity<DataSet>().HasMany(dataSet => dataSet.registros).WithRequired();
            modelBuilder.Entity<Dominio.Version>().HasMany(version => version.datasets).WithRequired();
            modelBuilder.Entity<VariablesDataSet>().HasMany(variablesDataSet => variablesDataSet.datosRegistro).WithRequired();
        }

        public void EmptyDataBase()
        {
            foreach (Usuario usuario in Usuarios)
            {
                Usuarios.Remove(usuario);
            }
            foreach (Producto producto in Productos)
            {
                Productos.Remove(producto);
            }
            foreach (Dominio.Version version in Versiones)
            {
                Versiones.Remove(version);
            }
            foreach (DataSet dataSet in DataSets)
            {
                DataSets.Remove(dataSet);
            }
            foreach (VariablesDataSet variableDataSet in VariablesDataSets)
            {
                VariablesDataSets.Remove(variableDataSet);
            }
            SaveChanges();
        }
    }
}
