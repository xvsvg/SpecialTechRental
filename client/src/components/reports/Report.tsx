import { Box, Typography } from "@mui/material";
import { PDFDocument } from "pdf-lib";

const downloadPDF = async () => {
  // Create a new PDF document
  const pdfDoc = await PDFDocument.create();

  // Add a blank page to the document
  const page = pdfDoc.addPage();

  // Draw some text on the page
  page.drawText("Sample PDF Content", { x: 50, y: 50 });

  // Serialize the PDF document to a Uint8Array
  const pdfBytes = await pdfDoc.save();

  // Create a Blob object from the PDF bytes
  const blob = new Blob([pdfBytes], { type: "application/pdf" });

  // Generate a URL for the Blob object
  const url = URL.createObjectURL(blob);

  // Create a temporary link element
  const link = document.createElement("a");
  link.href = url;
  link.download = "document.pdf";

  // Programmatically trigger the download
  link.click();

  // Clean up the URL and link element
  URL.revokeObjectURL(url);
};

const ExampleComponent = () => {
  return (
    <Box>
      <Typography>
        <a href="#" onClick={downloadPDF}>
          Download PDF
        </a>
      </Typography>
    </Box>
  );
};

export default ExampleComponent;
