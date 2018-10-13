using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logica;
using Dominio;
using InterfazServiceUI;
using System;

namespace Obligatorio.Test
{

    [TestClass] 
    public class UsuarioServiceTest
    {
        public IUsuarioService usuarioService = new UsuarioService();

        [TestMethod]
        public void AltaUsuarioTest()
        {
            usuarioService.AltaUsuario("SGarcia", "Sofia", "1234", "Garcia", "Desarollador");
        }

        [TestMethod]
        [ExpectedException(typeof(LargoDatoNoValidoException))]
        public void AltaUsuarioNombreUsuarioVacioTest()
        {
            usuarioService.AltaUsuario("", "Sofia", "1234", "Garcia", "Desarollador");
        }

        [TestMethod]
        [ExpectedException(typeof(LargoDatoNoValidoException))]
        public void AltaUsuarioNombreVacioTest()
        {
            usuarioService.AltaUsuario("SGarcia", "", "1234", "Garcia", "Desarollador");
        }

        [TestMethod]
        [ExpectedException(typeof(LargoDatoNoValidoException))]
        public void AltaUsuarioApellidoVacioTest()
        {
            usuarioService.AltaUsuario("SGarcia", "Sofia", "1234", "", "Desarollador");
        }

        [TestMethod]
        [ExpectedException(typeof(LargoDatoNoValidoException))]
        public void AltaUsuarioContraseñaMenorAMinimoTest()
        {
            usuarioService.AltaUsuario("SGarcia", "Sofia", "12", "", "Desarollador");
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioServiceException))]
        public void AltaUsuarioYaExistenteTest()
        {
            usuarioService.AltaUsuario("Frevello", "Facundo", "1234", "Revello", "Desarollador");
            usuarioService.AltaUsuario("Frevello", "Facundo", "1234", "Revello", "Desarollador");
        }

        [TestMethod]
        public void BajaUsuarioTest()
        {
            Usuario usuario = new Usuario("SGarcia", "Sofia", "1234", "Garcia", "Desarollador");
            usuarioService.AltaUsuario("SGarcia", "Sofia", "1234", "Garcia", "Desarollador");
            usuarioService.BajaUsuario(usuario);
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioServiceException))]
        public void BajaUsuarioInexistenteTest()
        {
            usuarioService.AltaUsuario("FRevello", "Revello", "1234", "Revello", "Desarollador");
            Usuario usuario = new Usuario("SGarcia", "Sofia", "1234", "Garcia", "Desarollador");
            usuarioService.BajaUsuario(usuario);
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioServiceException))]
        public void BajaUsuarioAdminTest()
        {
            Usuario usuario = new Usuario("Admin", "Sofia", "1234", "Garcia", "Desarollador");
            usuarioService.BajaUsuario(usuario);
        }

        [TestMethod]
        public void ModificarUsuarioTest()
        {
            usuarioService.AltaUsuario("FacundoR", "Revello", "1234", "Revello", "Desarollador");
            Usuario usuario = new Usuario("FacundoR", "Revello", "1234567", "Revello", "Desarollador");
            usuarioService.ModificarUsuario(usuario);
        }

        [TestMethod]
        [ExpectedException(typeof(LargoDatoNoValidoException))]
        public void ModificarUsuarioDatosIncorrectosTest()
        {
            usuarioService.AltaUsuario("FRevello", "Revello", "1234", "Revello", "Desarollador");
            Usuario usuario = new Usuario("FRevello", "Revello", "12", "Revello", "Desarollador");
            usuarioService.ModificarUsuario(usuario);
        }

        [TestMethod]
        public void LogInTest()
        {
            usuarioService.AltaUsuario("FRevello", "Revello", "1234", "Revello", "Desarollador");
            usuarioService.LogIn("FRevello", "1234");          
        }

        [TestMethod]
        [ExpectedException(typeof(LargoDatoNoValidoException))]
        public void LogInDatosVaciosTest()
        {
            usuarioService.AltaUsuario("FRevello", "Revello", "1234", "Revello", "Desarollador");
            usuarioService.LogIn("FRevello", "");
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioServiceException))]
        public void LogInNombreIncorrectoTest()
        {
            usuarioService.AltaUsuario("FRevello", "Revello", "1234", "Revello", "Desarollador");
            usuarioService.LogIn("FRevell", "1234");
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioServiceException))]
        public void LogInContraseñaIncorrectoTest()
        {
            usuarioService.AltaUsuario("FRevello", "Revello", "1234", "Revello", "Desarollador");
            usuarioService.LogIn("FRevello", "1234254");
        }

        [TestMethod]
        public void GetListaUsuariosTest()
        {
            usuarioService.GetListaUsuarios();
        }

        [TestMethod]
        public void GetUsuarioTest()
        {
            usuarioService.AltaUsuario("FRevello", "Revello", "1234", "Revello", "Desarollador");
            usuarioService.GetUsuario("FRevello");
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioServiceException))]
        public void GetUsuarioinexistenteTest()
        {
            usuarioService.GetUsuario("FRevello");
        }

        [TestMethod]
        public void SetUltimoIngresoTest()
        {
            usuarioService.AltaUsuario("FRevello", "Revello", "1234", "Revello", "Desarollador");
            usuarioService.SetUltimoIngreso(DateTime.Now, "FRevello");
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioServiceException))]
        public void SetUltimoIngresoUsuarioInexistenteTest()
        {
            usuarioService.SetUltimoIngreso(DateTime.Now, "Frevello");
        }
    }
}
