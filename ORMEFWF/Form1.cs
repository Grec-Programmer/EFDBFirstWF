using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORMEFWF
{
    public partial class Form1 : Form
    {
        void ShowDB()
        {
            using (AutoDealerEntities db = new AutoDealerEntities())
            {
                var query = (from s in db.Avtoes select s).ToList();
                listBox.Items.Clear();
                foreach (var item in query)
                {

                    listBox.Items.Add($"{item.Id}.{item.Name} Prcie: {Convert.ToDecimal(item.Price).ToString("#,#", CultureInfo.InvariantCulture)}");
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
            ShowDB();
        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            if (tBoxName.Text != "")
            {
                    decimal p = 0;
                if (tBoxPrice.Text != "")
                    p = Convert.ToDecimal(tBoxPrice.Text);
                using (AutoDealerEntities db = new AutoDealerEntities())
                {
                    Avto avto = new Avto { Name = tBoxName.Text, Price = p };
                    db.Avtoes.Add(avto);
                    db.SaveChanges();
                        var query = (from s in db.Avtoes select s).ToList();
                        listBox.Items.Clear();
                        foreach (var item in query)
                        {

                            listBox.Items.Add($"{item.Id}.{item.Name} Prcie: {Convert.ToDecimal(item.Price).ToString("#,#", CultureInfo.InvariantCulture)}");
                        }
                }            
            }
        }
    }
}
