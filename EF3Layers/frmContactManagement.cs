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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            contactBindingSource.DataSource = ContactServices.Instance.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddEditContact frm = new frmAddEditContact(null);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                contactBindingSource.DataSource = ContactServices.Instance.GetAll();
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (contactBindingSource.Current == null)
            {
                return;
            }
            frmAddEditContact frm = new frmAddEditContact(contactBindingSource.Current as Contact);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                contactBindingSource.DataSource = ContactServices.Instance.GetAll();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (contactBindingSource.Current == null)
            {
                return;
            }
            if (MessageBox.Show("Are you sure delete this contact?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ContactServices.Instance.Delete(contactBindingSource.Current as Contact);
                contactBindingSource.RemoveCurrent();
            }
        }
    }
}
