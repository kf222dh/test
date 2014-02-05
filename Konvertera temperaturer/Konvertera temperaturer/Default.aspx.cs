using Konvertera_temperaturer.Model;//Hämtar Konvertera_temperaturer klassen i modell
using System;
using System.Web.UI.WebControls;

namespace Konvertera_temperaturer
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ConvertButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                int startTemp;
                int endTemp;
                int scaleTemp;

                //Lagrar och gör om text till räkbar alltså int
                startTemp = Int32.Parse(StartTextBox.Text);
                endTemp = Int32.Parse(EndTextBox.Text);
                scaleTemp = Int32.Parse(ScaleTextBox.Text);

                //Visar upp tabellen.
                ConversionLabel.Visible = true;

                //Kollar vad man har valt i mellan °C eller °F i tabellhuvudet.
                if (!CelToFahRadioButton.Checked)
                {
                    First.Text = "°F";
                    Second.Text = "°C";
                }

                //Körs om allt är okej
                for (int i = startTemp; i <= endTemp; i += scaleTemp)
                {
                    //Gör en tabell
                    TableRow row = new TableRow();
                    ConversionTable.Rows.Add(row);
                    TableCell[] cells = new TableCell[] { new TableCell(), new TableCell() };
                    row.Cells.AddRange(cells);

                    cells[0].Text = String.Format("{0}", i);
                    cells[1].Text = String.Format("{0:f0}", CelToFahRadioButton.Checked ?//Om den är checkad så
                    TemperatureConverter.CelsiusToFahrenheit(i).ToString() : TemperatureConverter.FahrenheitToCelsius(i).ToString());//Konvertering(: betyder eller)
                }
            }
        }
    }
}