namespace BaseAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class crearBD : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DataSets",
                c => new
                    {
                        DataSet_Id = c.Guid(nullable: false),
                        Version_Id = c.Guid(nullable: false),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.DataSet_Id)
                .ForeignKey("dbo.Versions", t => t.Version_Id, cascadeDelete: true)
                .Index(t => t.Version_Id);
            
            CreateTable(
                "dbo.VariablesDataSets",
                c => new
                    {
                        VariableDataSet_Id = c.Guid(nullable: false),
                        DataSet_Id = c.Guid(nullable: false),
                        nombreVariable = c.String(),
                        ordenado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.VariableDataSet_Id)
                .ForeignKey("dbo.DataSets", t => t.DataSet_Id, cascadeDelete: true)
                .Index(t => t.DataSet_Id);
            
            CreateTable(
                "dbo.VariableDatoes",
                c => new
                    {
                        VariableDato_Id = c.Guid(nullable: false),
                        VariableDataSet_Id = c.Guid(nullable: false),
                        dato = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.VariableDato_Id)
                .ForeignKey("dbo.VariablesDataSets", t => t.VariableDataSet_Id, cascadeDelete: true)
                .Index(t => t.VariableDataSet_Id);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        Producto_Id = c.Guid(nullable: false),
                        nombre = c.String(),
                        fechaInicial = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Producto_Id);
            
            CreateTable(
                "dbo.Versions",
                c => new
                    {
                        Version_Id = c.Guid(nullable: false),
                        Producto_Id = c.Guid(nullable: false),
                        etiqueta = c.String(),
                        fechaCreacion = c.DateTime(nullable: false),
                        estado = c.String(),
                    })
                .PrimaryKey(t => t.Version_Id)
                .ForeignKey("dbo.Productoes", t => t.Producto_Id, cascadeDelete: true)
                .Index(t => t.Producto_Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        nombreUsuario = c.String(),
                        nombre = c.String(),
                        contraseña = c.String(),
                        apellido = c.String(),
                        rol = c.String(),
                        registro = c.DateTime(nullable: false),
                        ultimoIngreso = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Versions", "Producto_Id", "dbo.Productoes");
            DropForeignKey("dbo.DataSets", "Version_Id", "dbo.Versions");
            DropForeignKey("dbo.VariablesDataSets", "DataSet_Id", "dbo.DataSets");
            DropForeignKey("dbo.VariableDatoes", "VariableDataSet_Id", "dbo.VariablesDataSets");
            DropIndex("dbo.Versions", new[] { "Producto_Id" });
            DropIndex("dbo.VariableDatoes", new[] { "VariableDataSet_Id" });
            DropIndex("dbo.VariablesDataSets", new[] { "DataSet_Id" });
            DropIndex("dbo.DataSets", new[] { "Version_Id" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Versions");
            DropTable("dbo.Productoes");
            DropTable("dbo.VariableDatoes");
            DropTable("dbo.VariablesDataSets");
            DropTable("dbo.DataSets");
        }
    }
}
