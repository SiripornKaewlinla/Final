using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F
{
    public partial class Form2 : Form
    {
        List<Student> student = new List<Student>();
        public Form2()
        {
            InitializeComponent();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 Add = new Form1();
            Add.ShowDialog();
            if (Add.DialogResult == DialogResult.OK)
            {
                student.Add(Add.GetStudent());
                Refresh();
            }
        }
        public void Refresh()
        {
            dataGridView1.Rows.Clear();
            foreach (Student item in student)
            {
                dataGridView1.Rows.Add(item.name, item.id,item.lastname,item.major);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = "CSV files(*.csv)|*.csv|All files(*.*)|*.*";
            OpenFileDialog.ShowDialog();
            if (OpenFileDialog.FileName != "")
            {
                dataGridView1.Rows.Clear();
                using (StreamReader file = new StreamReader(OpenFileDialog.FileName))
                {
                    string line;
                    int count = 0;
                    while ((line = file.ReadLine()) != null)
                    {
                        string[] data = line.Split(',');
                        student.Add(new Student()
                        {
                            name = data[0],
                            lastname = data[1],
                            id = data[2],
                            major = data[3]
                        });
                        Refresh();
                    }
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = "";
            saveFile.Filter = "CSV|*.csv";
            saveFile.ShowDialog();

            if (saveFile.Filter != "")
            {
                using (StreamWriter file = new StreamWriter(saveFile.FileName))
                {
                    foreach (Student item in student)
                    {
                        file.WriteLine($"{item.name},{item.id},{item.lastname},{item.major}");
                    }
                }
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }
    
    
    }
}
