import { Box, Typography } from "@mui/material";

interface ReportProps {
  onDownloadPDF: () => void;
}

const Report = ({ onDownloadPDF }: ReportProps) => {
  return (
    <Box>
      <Typography>
        <a href="/report" onClick={onDownloadPDF}>
          Download PDF
        </a>
      </Typography>
    </Box>
  );
};

export default Report;
