namespace GunaUITestes
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
            timer1.Start();
            progress_indicator.Start();
        }
        int i = -1;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((Convert.ToInt32(label_contador.Text.Trim('%')) == 100))
            {
                FormPrincipal form = new FormPrincipal();
                progress_indicator.Stop();
                timer1.Stop();
                form.Show();
                this.Close();
            }
            else
            {
                label_contador.Text = $"{(Convert.ToInt32(label_contador.Text.Trim('%')) + 1)}%";
                AnimacaoLabel();
            }
        }

        List<char> ListPreparando = new List<char>
        {
            'P','r','e','p','a','r','a','n','d','o', ' ','t','u','d','o',' ','p','a','r','a',' ', 'v','o','c','ê','.',' ','.',' ','.'
        };
        //22
        List<char> ListQuase = new List<char>
        {
            'Q', 'u', 'a', 's', 'e', ' ', 't', 'u', 'd', 'o', ' ', 'p', 'r', 'o', 'n', 't', 'o','.',' ','.',' ','.'
        };
        //31

        private void AnimacaoLabel()
        {
            if (Convert.ToInt32(label_contador.Text.Trim('%')) < 63)
            {

                if (i < 29)
                {
                    i++;
                    label_teste.Text = (label_teste.Text + ListPreparando[i]);
                }
                else
                {
                    label_teste.Text = default(string);
                    i = -1;
                }
            }
            else if (Convert.ToInt32(label_contador.Text.Trim('%')) > 63)
            {
                if (i != 21)
                {
                    i++;
                    label_teste.Text = (label_teste.Text + ListQuase[i]);
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }
    }
}
