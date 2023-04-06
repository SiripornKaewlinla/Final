namespace F
{
    public partial class Form1 : Form
    {
        private Student student;
       
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                student = new Student()
                {
                    name = textBox1.Text,
                    lastname= textBox2.Text,
                    id = textBox3.Text,
                    major = textBox4.Text,
                };
            }
            catch
            {
                MessageBox.Show("Error");
            }
            this.DialogResult = DialogResult.OK;
        }
        public Student GetStudent()
        {
            return student;
        }
    }
}