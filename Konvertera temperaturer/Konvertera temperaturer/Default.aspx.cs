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
                //Lagrar och gör om text till räkbar alltså int
                var startValue = int.Parse(StartTextBox.Text);
                var endValue = int.Parse(EndTextBox.Text);
                var scaleValue = int.Parse(ScaleTextBox.Text);

                //Kollar vad man har valt i mellan °C eller °F i tabellhuvudet.
                if (!CelToFahRadioButton.Checked)
                {
                    First.Text = "&degF";
                    Second.Text = "&degC";
                }
                //Körs om allt är okej
                for (int temp = startValue; temp <= endValue; temp += scaleValue)
                {
                    //Gör en tabell
                    TableRow row = new TableRow();
                    ConversionTable.Rows.Add(row);
                    TableCell[] cells = new TableCell[] { new TableCell(), new TableCell() };
                    row.Cells.AddRange(cells);

                    cells[0].Text = temp.ToString();
                    cells[1].Text = CelToFahRadioButton.Checked ?//Om den är checkad så
                    TemperatureConverter.CelsiusToFahrenheit(temp).ToString() : TemperatureConverter.FahrenheitToCelsius(temp).ToString();//Konvertering(: betyder eller)
                }

                //Visar upp tabellen.
                ConversionLabel.Visible = true;
            }
        }
    }
}