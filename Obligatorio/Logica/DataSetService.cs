﻿using AccesoDatos;
using Dominio;
using InterfazAccesoDatos;
using InterfazServiceUI;
using System;

namespace Logica
{
    public class DataSetService:IDataSetService
    {

        public DataSet CargarDataSet(String path)
        {
            ILoadDataSet l = new LoadDataSet(path);
            return l.CargarDataSet();
        }
        

    }
}
