using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myproject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        Modify modify = new Modify();

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = modify.DataTable("Select * from DuLieu");
            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)dataGridView1.Columns[5];
            pic.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        private void btnAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn ảnh";
            openFileDialog.Filter = "Images File(*.gif; *.jpg; *.jpeg; *.bmp; *.wmf; *.png)| *.gif; *.jpg; *.jpeg; *.bmp; *.wmf; *.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog.FileName;
                txtPath.Text = openFileDialog.FileName;
            }
        }
        DuLieu duLieu;
        private void GetValues()
        {
            string filename = txtFileName.Text;
            string path = txtPath.Text;
            string asqtime = txtASQTime.Text;
            string updatetime = txtUpdateTime.Text;
            string version = txtVersion.Text;
            byte[] anh = ImageToByteArray(pictureBox1);
            duLieu = new DuLieu(filename, path, asqtime, updatetime, version, anh);
        }
        private byte[] ImageToByteArray(PictureBox pictureBox)
        {
            MemoryStream memoryStream = new MemoryStream();
            pictureBox.Image.Save(memoryStream, pictureBox.Image.RawFormat);
            return memoryStream.ToArray();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string query = "Insert into DuLieu values (@FileName,@Path,@ASQTime,@UpDateTime,@Version,@Anh)";
            try
            {
                GetValues();
                modify.Command(duLieu, query);
                MessageBox.Show("Thêm thành công");
                MainForm_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Thêm" + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa dữ liệu này không", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string query = "Update DuLieu set Path = @Path,ASQTime = @ASQTime,UpdateTime = @UpdateTime,Version = @Version,Anh = @Anh where FileName = @FileName";
                try
                {
                    GetValues();
                    modify.Command(duLieu, query);
                    MessageBox.Show("Sửa thành công");
                    MainForm_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi Sửa" + ex.Message);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtFileName.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
                txtPath.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
                txtASQTime.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
                txtUpdateTime.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
                txtVersion.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();

                if (dataGridView1.Rows[index].Cells[5].Value.ToString() != "")
                {
                    MemoryStream memoryStream = new MemoryStream((byte[])dataGridView1.Rows[index].Cells[5].Value);
                    pictureBox1.Image = Image.FromStream(memoryStream);

                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa dữ liệu này không", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string query = "Delete DuLieu where FileName = @FileName";
                try
                {
                    GetValues();
                    modify.Command(duLieu, query);
                    MessageBox.Show("Xóa thành công");
                    MainForm_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi Xóa" + ex.Message);
                }
            }
        }
    }
}
