using System.Drawing;
using System.Text;
using APIAeropuerto.Application.UseCases.SpecifyConsults;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using Image = Aspose.Pdf.Image;

namespace APIAeropuerto.Application.UseCases.ExportPdf;

public class ExportPdfUseCase
{
    private readonly GetAirportWithRepairServicesUseCase _getAirportWithRepairServicesUseCase;
    private readonly GetAmountRepairAirportUseCase _getAmountRepairAirportUseCase;
    private readonly GetClientAirportJMUseCase _getClientAirportJMUseCase;
    private readonly GetAirportWithLessShipUseCase _getAirportWithLessShipUseCase;
    private readonly GetAvgServicesPriceJMUseCase _getAvgServicesPriceJMUseCase;
    private readonly DeleteInneficientServicesUseCase _deleteInneficientServicesUseCase;
    
    public ExportPdfUseCase(GetAirportWithRepairServicesUseCase getAirportWithRepairServicesUseCase
        , GetAmountRepairAirportUseCase getAmountRepairAirportUseCase
        , GetClientAirportJMUseCase getClientAirportJMUseCase
        , GetAirportWithLessShipUseCase getAirportWithLessShipUseCase
        , GetAvgServicesPriceJMUseCase getAvgServicesPriceJMUseCase
        , DeleteInneficientServicesUseCase deleteInneficientServicesUseCase)
    {
        _getAirportWithRepairServicesUseCase = getAirportWithRepairServicesUseCase;
        _getAmountRepairAirportUseCase = getAmountRepairAirportUseCase;
        _getClientAirportJMUseCase = getClientAirportJMUseCase;
        _getAirportWithLessShipUseCase = getAirportWithLessShipUseCase;
        _getAvgServicesPriceJMUseCase = getAvgServicesPriceJMUseCase;
        _deleteInneficientServicesUseCase = deleteInneficientServicesUseCase;
    }
    public async void Execute(string path)
    {
        var doc = new Document();
        var titlePage = doc.Pages.Add();
    
        var title = new TextFragment("Seminario Final de Ingeniería de Software")
        {
            TextState =
            {
                FontSize = 20,
                FontStyle = FontStyles.Bold,
                Font = FontRepository.FindFont("Times New Roman"),
                ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.DarkBlue)
            },
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Top
        };
        titlePage.Paragraphs.Add(title);
        
        titlePage.Paragraphs.Add(new TextFragment("\n\n\n"));
        
        var teamTable = new Table
        {
            ColumnWidths = "50% 50%",
            DefaultCellPadding = new MarginInfo(5, 2, 5, 2),
            Border = new BorderInfo(BorderSide.All, .5f, Aspose.Pdf.Color.FromRgb(System.Drawing.Color.LightGray)),
            DefaultCellBorder = new BorderInfo(BorderSide.All, .2f, Aspose.Pdf.Color.Gray),
            Margin = new MarginInfo { Top = 20 }
        };
        
        var image = new Image
        {
            File = "Presentation/Images/icon.png",
        };
        using (var imageStream = new FileStream(image.File, FileMode.Open, FileAccess.Read))
        {
            var bitmap = new Bitmap(imageStream);
            float ratio = (float)bitmap.Height / bitmap.Width;
            image.FixWidth = 150;
            image.FixHeight = image.FixWidth * ratio; 
        }

        titlePage.Paragraphs.Add(image);
        titlePage.Paragraphs.Add(new TextFragment("\n"));
        
        var header = teamTable.Rows.Add();
        header.Cells.Add("Nombre del Integrante");
        header.Cells.Add("Número de Grupo");
        header.Cells[0].DefaultCellTextState.FontStyle = FontStyles.Bold;
        header.Cells[1].DefaultCellTextState.FontStyle = FontStyles.Bold;
        
        var teamMembers = new List<string> { "Bruno Jesus Pire Ricardo, 311", "Eisler Francisco Valles Rodriguez, 311", "Adrian Hernandez Santos, 311" };
        foreach (var member in teamMembers)
        {
            var memberData = member.Split(',');
            var row = teamTable.Rows.Add();
            row.Cells.Add(memberData[0]);
            row.Cells.Add(memberData.Length > 1 ? memberData[1] : "");
        }

        titlePage.Paragraphs.Add(teamTable);
        var airportWithRepairServices = await _getAirportWithRepairServicesUseCase.Execute();
        var amountRepairAirport = await _getAmountRepairAirportUseCase.Execute();
        var clientAirportJM = await _getClientAirportJMUseCase.Execute();
        var airportWithLessShip = await _getAirportWithLessShipUseCase.Execute();
        var avgServicesPriceJM = await _getAvgServicesPriceJMUseCase.Execute();
        Table table = new Table
        {
            ColumnWidths = "50% 50%",
            DefaultCellPadding = new MarginInfo(10, 5, 10, 5),
            Border = new BorderInfo(BorderSide.All, .5f, Aspose.Pdf.Color.DarkGray),
            DefaultCellBorder = new BorderInfo(BorderSide.All, .2f, Aspose.Pdf.Color.Gray)
        };
        
        Row headerRow = table.Rows.Add();
        headerRow.Cells.Add("Airport");
        headerRow.Cells.Add("Geographic Position");
        foreach (var item in airportWithRepairServices)
        {
            Row row = table.Rows.Add();
            row.Cells.Add(item.Name);
            row.Cells.Add(item.GeographicPosition);
        }
        Table table1 = new Table
        {
            ColumnWidths = "50% 50%",
            DefaultCellPadding = new MarginInfo(10, 5, 10, 5),
            Border = new BorderInfo(BorderSide.All, .5f, Aspose.Pdf.Color.DarkGray),
            DefaultCellBorder = new BorderInfo(BorderSide.All, .2f, Aspose.Pdf.Color.Gray)
        };
        Row headerRow1 = table1.Rows.Add();
        headerRow1.Cells.Add("Airport");
        headerRow1.Cells.Add("AmountRepair");
        foreach (var item in amountRepairAirport)
        {
            Row row = table1.Rows.Add();
            row.Cells.Add(item.NameAirport);
            row.Cells.Add(item.AmountRepair.ToString());
        }
        Table table2 = new Table
        {
            ColumnWidths = "50% 50%",
            DefaultCellPadding = new MarginInfo(10, 5, 10, 5),
            Border = new BorderInfo(BorderSide.All, .5f, Aspose.Pdf.Color.DarkGray),
            DefaultCellBorder = new BorderInfo(BorderSide.All, .2f, Aspose.Pdf.Color.Gray)
        };
        Row headerRow2 = table2.Rows.Add();
        headerRow2.Cells.Add("Client");
        headerRow2.Cells.Add("ClientType");
        foreach (var item in clientAirportJM)
        {
            Row row = table2.Rows.Add();
            row.Cells.Add(item.NameClient);
            row.Cells.Add(item.ClientType);
        }
        Table table3 = new Table
        {
            ColumnWidths = "50% 50%",
            DefaultCellPadding = new MarginInfo(10, 5, 10, 5),
            Border = new BorderInfo(BorderSide.All, .5f, Aspose.Pdf.Color.DarkGray),
            DefaultCellBorder = new BorderInfo(BorderSide.All, .2f, Aspose.Pdf.Color.Gray)
        };
        Row headerRow3 = table3.Rows.Add();
        headerRow3.Cells.Add("Airport");
        headerRow3.Cells.Add("ServicesCount");
        foreach (var item in airportWithLessShip)
        {
            Row row = table3.Rows.Add();
            row.Cells.Add(item.AirportName);
            row.Cells.Add(item.ServicesCount.ToString());
        }
        Table table4 = new Table
        {
            ColumnWidths = "50% 50%",
            DefaultCellPadding = new MarginInfo(10, 5, 10, 5),
            Border = new BorderInfo(BorderSide.All, .5f, Aspose.Pdf.Color.DarkGray),
            DefaultCellBorder = new BorderInfo(BorderSide.All, .2f, Aspose.Pdf.Color.Gray)
        };
        Row headerRow4 = table4.Rows.Add();
        headerRow4.Cells.Add("ServiceDescription");
        headerRow4.Cells.Add("AvgPrice");
        foreach (var item in avgServicesPriceJM)
        {
            Row row = table4.Rows.Add();
            row.Cells.Add(item.ServiceDescription);
            row.Cells.Add(item.AvgPrice.ToString());
        }
        
        Page mainContentPage = doc.Pages.Add();
        if (airportWithRepairServices.Any())
        {
            mainContentPage.Paragraphs.Add(new TextFragment("Airport with repair services:"));
            mainContentPage.Paragraphs.Add(new TextFragment("\n"));
            mainContentPage.Paragraphs.Add(table);
            mainContentPage.Paragraphs.Add(new TextFragment("\n"));
            mainContentPage.Paragraphs.Add(new TextFragment("\n"));
        }
        if (amountRepairAirport.Any())
        {
            mainContentPage.Paragraphs.Add(new TextFragment("Amount repair airport:"));
            mainContentPage.Paragraphs.Add(new TextFragment("\n"));
            mainContentPage.Paragraphs.Add(table1);
            mainContentPage.Paragraphs.Add(new TextFragment("\n"));
            mainContentPage.Paragraphs.Add(new TextFragment("\n"));
        }
        if (clientAirportJM.Any())
        {
            mainContentPage.Paragraphs.Add(new TextFragment("Client airport JM:"));
            mainContentPage.Paragraphs.Add(new TextFragment("\n"));
            mainContentPage.Paragraphs.Add(table2);
            mainContentPage.Paragraphs.Add(new TextFragment("\n"));
            mainContentPage.Paragraphs.Add(new TextFragment("\n"));
        }
        if (airportWithLessShip.Any())
        {
            mainContentPage.Paragraphs.Add(new TextFragment("Airport with less ship:"));
            mainContentPage.Paragraphs.Add(new TextFragment("\n"));
            mainContentPage.Paragraphs.Add(table3);
            mainContentPage.Paragraphs.Add(new TextFragment("\n"));
            mainContentPage.Paragraphs.Add(new TextFragment("\n"));
        }
        if (avgServicesPriceJM.Any())
        {
            
            mainContentPage.Paragraphs.Add(new TextFragment("Avg services price JM:"));
            mainContentPage.Paragraphs.Add(new TextFragment("\n"));
            mainContentPage.Paragraphs.Add(table4);
        }
        var pathTo = Path.Combine(path, "Report.pdf");
        doc.Save(pathTo);
    }
}