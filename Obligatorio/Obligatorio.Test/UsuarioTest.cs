using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;

namespace Obligatorio.Test
{
    [TestClass]
    public class UsuarioTest
    {
        [TestMethod]
        public void CrearUsuarioTest()
        {
            Usuario usuario = new Usuario("SGarcia", "Sofia", "1234", "Garcia", "Desarollador");
        }


    }

}
