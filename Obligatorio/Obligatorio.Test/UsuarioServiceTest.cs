﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logica;
using Excepciones;
using Dominio;

namespace Obligatorio.Test
{

    [TestClass]
    public class UsuarioServiceTest
    {
        public UsuarioService usuarioService = new UsuarioService();

        [TestMethod]
        public void AltaUsuarioTest()
        {
            usuarioService.AltaUsuario("SGarcia", "Sofia", "1234", "Garcia", "Desarollador");
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioServiceException))]
        public void AltaUsuarioNombreUsuarioVacioTest()
        {
            usuarioService.AltaUsuario("", "Sofia", "1234", "Garcia", "Desarollador");
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioServiceException))]
        public void AltaUsuarioNombreVacioTest()
        {
            usuarioService.AltaUsuario("SGarcia", "", "1234", "Garcia", "Desarollador");
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioServiceException))]
        public void AltaUsuarioApellidoVacioTest()
        {
            usuarioService.AltaUsuario("SGarcia", "Sofia", "1234", "", "Desarollador");
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioServiceException))]
        public void AltaUsuarioContraseñaMenorAMinimoTest()
        {
            usuarioService.AltaUsuario("SGarcia", "Sofia", "12", "", "Desarollador");
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
            Usuario usuario = new Usuario("SGarcia", "Sofia", "112346", "Garcia", "Desarollador");
            usuarioService.ModificarUsuario(usuario);
        }
    }
}
