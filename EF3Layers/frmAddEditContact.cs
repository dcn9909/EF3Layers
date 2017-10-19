using BusinessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFCRUD
{
    public partial class frmAddEditContact : Form
    {
        bool isNew;
        public frmAddEditContact(Contact contact)
        {
            InitializeComponent();
            if (contact==null)
            {
                contactBindingSource.DataSource = new Contact();
                isNew = true;
            }
            else
            {
                contactBindingSource.DataSource = contact;
                isNew = false;
            }
        }

        private void frmAddEditContact_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult==DialogResult.OK)
            {
                if (String.IsNullOrEmpty(txtContactName.Text))
                {
                    MessageBox.Show("Please enter your contact name!","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    txtContactName.Focus();
                    e.Cancel = true;
                    return;
                }
                if (isNew)
                {
                    ContactServices.Instance.Insert(contactBindingSource.Current as Contact);
                }
                else
                {
                    ContactServices.Instance.Update(contactBindingSource.Current as Contact);
                }
            }
        }

        
    }
}
