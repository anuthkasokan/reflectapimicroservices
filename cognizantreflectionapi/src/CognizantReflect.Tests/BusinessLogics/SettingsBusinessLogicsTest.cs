using System.Collections.Generic;
using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.BusinessLogics;
using CognizantReflect.Api.Helpers.Excel.Interface;
using CognizantReflect.Api.Models.Settings;
using Microsoft.CodeAnalysis;
using Moq;
using NUnit.Framework;
using OfficeOpenXml;

namespace CognizantReflect.Tests.BusinessLogics
{
    [TestFixture]
    public class SettingsBusinessLogicsTest
    {
        private readonly Mock<IExcelReaderExtension> _excelReaderExtension = new Mock<IExcelReaderExtension>();
        private readonly Mock<ISettingsAdapter> _settingsAdapter = new Mock<ISettingsAdapter>();

        [Test]
        public void SettingsBusinessLogics_Instance()
        {
            var assert = new SettingsBusinessLogics(_excelReaderExtension.Object, _settingsAdapter.Object); 
            Assert.IsInstanceOf<SettingsBusinessLogics>(assert);
        }

        [Test]
        public void UploadExcel_ReturnsHttpStatusCode()
        {
            _excelReaderExtension.Setup(x => x.GetConfiguration(It.IsAny<ExcelWorksheet>())).Returns(
                new List<ExcelConfiguration>
                {
                    new ExcelConfiguration()
                });
            var settingsBusinessLogics = new SettingsBusinessLogics(_excelReaderExtension.Object, _settingsAdapter.Object);
            var actual = settingsBusinessLogics.UploadExcel("C:/");

            Assert.DoesNotThrow(()=>settingsBusinessLogics.UploadExcel("c:/"));
        }
    }
}