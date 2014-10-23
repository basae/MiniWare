using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Bussiness;

namespace TestMiniWare
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        private BussinessUsuario usuario;
        public UnitTest1()
        {
            //
            // TODO: Add constructor logic here
            //
            usuario = new BussinessUsuario();
            
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void SaveUser()
        {
            usuario.Save(new User()
            {
                Nombre = "Edrei Javier",
                ApPaterno = "Bastar",
                ApMaterno = "Sarao",
                Username = "Genious",
                Password = "edrei8989",
                Celular = 9212408081,
                Correo = "basae_01@hotmail.com",
                Grado = 9,
                Grupo = "B"
            });
        }
    }
}
