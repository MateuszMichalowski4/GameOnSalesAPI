using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

public class PdfService
{
    public byte[] GeneratePdf(string name, string surname, string education, string email, string experience, string phoneNumber, string languages, string interests, string githubLink)
    {
        using var memoryStream = new MemoryStream();
        var document = new Document();

        PdfWriter.GetInstance(document, memoryStream);

        document.Open();

        Font headerFont = FontFactory.GetFont("Arial", 20, Font.BOLD, BaseColor.WHITE);
        var header = new Paragraph("Curriculum Vitae", headerFont);

        PdfPTable table = new PdfPTable(1);
        table.WidthPercentage = 100;

        PdfPCell cell = new PdfPCell(header);
        cell.BackgroundColor = new BaseColor(0, 0, 128);
        cell.Border = PdfPCell.NO_BORDER;
        cell.Padding = 10;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.VerticalAlignment = Element.ALIGN_MIDDLE;

        table.AddCell(cell);

        document.Add(table);

        document.Add(new Chunk("\n"));
        document.Add(new Chunk("\n"));

        var regularFont = FontFactory.GetFont("Arial", 15);

        var personalDetailsHeader = new Paragraph("Dane osobowe", FontFactory.GetFont("Arial", 15, Font.BOLD));
        personalDetailsHeader.Alignment = Element.ALIGN_LEFT;
        document.Add(personalDetailsHeader);

        document.Add(new Paragraph($"Imie: {name}", regularFont));
        document.Add(new Paragraph($"Nazwisko: {surname}", regularFont));
        document.Add(new Paragraph($"Email: {email}", regularFont));
        document.Add(new Paragraph($"Numer telefonu: {phoneNumber}", regularFont));

        var link = new Anchor($"GitHub: {githubLink}", FontFactory.GetFont("Arial", 15, BaseColor.BLACK));
        link.Reference = githubLink;
        document.Add(link);

        document.Add(new Chunk("\n"));
        var languagesHeader = new Paragraph("Znajomosc jezykow", FontFactory.GetFont("Arial", 15, Font.BOLD));
        languagesHeader.Alignment = Element.ALIGN_LEFT;
        document.Add(languagesHeader);

        string[] individualLanguages = languages.Split(',');

        foreach (var language in individualLanguages)
        {
            document.Add(new Paragraph(language.Trim(), regularFont));
        }
        document.Add(new Chunk("\n"));


        document.Add(new Chunk("\n"));
        var educationHeader = new Paragraph("Wyksztalcenie:", FontFactory.GetFont("Arial", 15, Font.BOLD));
        educationHeader.Alignment = Element.ALIGN_LEFT;
        document.Add(educationHeader);

        var educationItems = education.Split(',');
        foreach(var item in educationItems)
        {
            var educationParagraph = new Paragraph(item, FontFactory.GetFont("Arial", 15));
            educationParagraph.Alignment = Element.ALIGN_LEFT;
            document.Add(educationParagraph);
        }


        document.Add(new Chunk("\n"));


        document.Add(new Chunk("\n"));
        var experienceHeader = new Paragraph("Doswiadczenie zawodowe:", FontFactory.GetFont("Arial", 15, Font.BOLD));
        experienceHeader.Alignment = Element.ALIGN_LEFT;
        document.Add(experienceHeader);

        var experienceItems = experience.Split(',');
        foreach (var item in experienceItems)
        {
            var experienceParagraph = new Paragraph(item, FontFactory.GetFont("Arial", 15));
            experienceParagraph.Alignment = Element.ALIGN_LEFT;
            document.Add(experienceParagraph);
        }
        document.Add(new Chunk("\n"));

        var interestsHeader = new Paragraph("Zainteresowania", FontFactory.GetFont("Arial", 15, Font.BOLD));
        interestsHeader.Alignment = Element.ALIGN_LEFT;
        document.Add(interestsHeader);

        document.Add(new Paragraph(interests, regularFont));

        document.Close();

        return memoryStream.ToArray();
    }
}
