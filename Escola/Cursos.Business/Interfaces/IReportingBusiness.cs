using ClosedXML.Excel;
using System.IO;
using Cursos.ViewModel;

namespace Cursos.Business.Interfaces
{
    public interface IReportingBusiness
    {
        MemoryStream ReportCliente(string usuario, string fileName, FilterClientes filter);
    }
}