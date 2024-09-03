using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace BuisnessLayer.HelperClasses
{
    public class GenerateEventPDF
    {
        public GenerateEventPDF() { }

        private string _filePath { get; set; }

        public bool SetFilePath(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !Directory.Exists(Path.GetDirectoryName(filePath))) return false;

            _filePath = filePath;
            return true; 
        }

        public bool GenerateNewEventPDF(Event newEvent)
        {
            if (newEvent == null) { return false; }

            if (string.IsNullOrEmpty(_filePath))
            {
                return false; 
            }

            if (string.IsNullOrEmpty(newEvent.Name))
            {
                return false; 
            }

            Document document = new Document();

            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(_filePath, FileMode.Create));

            document.Open();

            document.Add(new Paragraph("Event Name: " + newEvent.Name));
            document.Add(new Paragraph("Date: " + newEvent.EventDate.ToString("d")));

            // Mali annoyance kod TDD
            if (newEvent.StartTime.HasValue)
            {
                document.Add(new Paragraph("Start Time: " + newEvent.StartTime.Value.ToString(@"hh\:mm")));
            }
            document.Add(new Paragraph("Organizer ID: " + newEvent.Id_Organizer));
            document.Add(new Paragraph("Venue ID: " + newEvent.Id_Venue));
            document.Add(new Paragraph("Category: " + (newEvent.EventCategory != null ? newEvent.EventCategory.Name : "N/A")));

            // Mali annoyance kod TDD
            if (!string.IsNullOrEmpty(newEvent.imgUrl))
            {
                document.Add(new Paragraph("Image URL: " + newEvent.imgUrl));
            }

            Console.WriteLine("PDF successfully created " + _filePath);

            document.Close();
            
            return true;
        }

    }
}
