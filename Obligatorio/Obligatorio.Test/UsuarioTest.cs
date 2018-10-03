using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;
using Excepciones;

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

        [TestMethod]
        [ExpectedException(typeof(UsuarioException))]
        public void CrearUsuarioNombreUsuarioVacioTest()
        {
            Usuario usuario = new Usuario("", "Sofia", "1234", "Garcia", "Desarollador");
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioException))]
        public void CrearUsuarioNombreVacioTest()
        {
            Usuario usuario = new Usuario("SGarcia", "", "1234", "Garcia", "Desarollador");
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioException))]
        public void CrearUsuarioApellidoVacioTest()
        {
            Usuario usuario = new Usuario("SGarcia", "Sofia", "1234", "", "Desarollador");
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioException))]
        public void CrearUsuarioContraseñaMenorAMinimoTest()
        {
            Usuario usuario = new Usuario("SGarcia", "Sofia", "12", "", "Desarollador");
        }
    }

}
