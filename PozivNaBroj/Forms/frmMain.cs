using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PozivNaBrojService.Model;
using PozivNaBrojService.Model.Calculators;
using PozivNaBroj.Properties;
using PozivNaBrojService;

namespace PozivNaBroj.Forms
{
    public partial class frmMain : Form
    {
        #region Fields


        #endregion

        #region Event Handlers
        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        #endregion

        #region Constructor
        public frmMain()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void LoadData()
        {
            lkpPozivNaBroj.DataSource = ModelPozivaService.GetAll();

            txtModel.Text = (lkpPozivNaBroj.SelectedItem as ModelPoziva).ToString();
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            /*var calculator = new MOD11INICalculator();
            var result = calculator.Calculate(textBox1.Text, false);
            textBox1.Text = textBox1.Text + result.ToString();*/

            var calculator = new ISO7064MOD1110();
            var result = calculator.Calculate(txtModel.Text, false);
            txtModel.Text = txtModel.Text + result.ToString();
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            var validator = ModelPozivaService.GetValidator(txtModel.Text);
            if (validator == null)
                return;

            validator.PozivNBr = txtPozivNaBroj.Text;

            var result = validator.Validate();
            if (result)
            {
                pbResult.Image = Resources.Accept;
                lblError.Text = "";
            }
            else
            {
                pbResult.Image = Resources.Error;
                lblError.Text = validator.Error;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var validator = ModelPozivaService.GetValidator(txtModel.Text);
            if (validator == null)
                return;

            validator.PozivNBr = txtPozivNaBroj.Text;
            validator.PozivNBr = validator.Kreiraj();
            txtPozivNaBroj.Text = validator.PozivNBr;
        }

        private void lkpPozivNaBroj_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtModel.Text = (lkpPozivNaBroj.SelectedItem as ModelPoziva).ToString();
        }
    }
}
