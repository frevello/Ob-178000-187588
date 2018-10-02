using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logica;

namespace Obligatorio.Test
{

    [TestClass]
    public class UsuarioServiceTest
    {

       [TestMethod]
        public void AltaUsuarioTest()
        {
            UsuarioService usuarioService = new UsuarioService();
            usuarioService.AltaUsuario("SGarcia", "Sofia", "1234", "Garcia", "Desarollador");
        }
    }
}
