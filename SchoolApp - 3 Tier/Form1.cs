using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BLL;

namespace SchoolApp___3_Tier
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        BusinessLogicLayer bll = new BusinessLogicLayer(); 

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Course c = new Course();
            c.CourseDescription = txtDesc.Text;
            c.Duration = txtDuration.Text;
            c.Status = cmbStatus.SelectedItem.ToString();
            c.CourseTypeID = int.Parse(cmbCourseType.SelectedValue.ToString());
            bll.InsertCourse(c); 
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            dgvCourse.DataSource = bll.GetCourse();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbCourseType.DataSource = bll.GetCourseType();
            cmbCourseType.DisplayMember = "CourseTypeDesc";
            cmbCourseType.ValueMember = "CourseTypeID";

            cmbStatus.Items.Add("Full");
            cmbStatus.Items.Add("Has Space");
            cmbStatus.Items.Add("Pending");
        }

        private void dgvCourse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCourse.SelectedRows.Count > 0) 
            {
                txtID.Text = dgvCourse.SelectedRows[0].Cells["CourseID"].Value.ToString();
                txtDesc.Text = dgvCourse.SelectedRows[0].Cells["Description"].Value.ToString();
                cmbStatus.Text = dgvCourse.SelectedRows[0].Cells["Status"].Value.ToString();
                txtDuration.Text = dgvCourse.SelectedRows[0].Cells["Duration"].Value.ToString();

            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Course c = new Course();
            c.Status = cmbStatus.SelectedItem.ToString();
            c.CourseID = int.Parse(txtID.Text);
            bll.UpdateCourse(c);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Course c = new Course();
            c.CourseID = int.Parse(txtID.Text);
            bll.DeleteCourse(c);
        }
    }
}
