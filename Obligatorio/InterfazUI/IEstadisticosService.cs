﻿using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfazUI
{
    public interface IEstadisticosService
    {
        float GetPromedioRegistro(DataSet dataSet, String nombreRegistro);
        float GetMinimoRegistro(DataSet dataSet, String nombreRegistro);
        float GetMaximoRegistro(DataSet dataSet, String nombreRegistro);
        int GetCantidadRegistros(DataSet dataSet);
    }
}
