using static System.Net.Mime.MediaTypeNames;
namespace domik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string line = textBox1.Text;
            Commands commands = new(

                line[0..line.IndexOf("(")],
                line[(line.IndexOf("(") + 1)..line.IndexOf(")")]
           );
            MessageBox.Show(commands.key);
            MessageBox.Show(commands.value);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Commands> commands = new List<Commands>();

            string text = textBox1.Text + "\n";
            while (text != "")
            {
                string line = text[0..text.IndexOf("\n")];
                try
                {
                    commands.Add(
                        new(
                             line[0..line.IndexOf("(")],
                    line[(line.IndexOf("(") + 1)..line.IndexOf(")")]
                    )
                    );
                }
                catch (Exception ex) { }
                text = text[(text.IndexOf("\n") + 1)..^0];
                int x;
                if (int.TryParse(commands[commands.Count - 1].value, out x) == false)
                {
                    for (int i = 0; i < commands.Count; i++)
                    {
                        if (commands[commands.Count - 1].value == commands[i].key)
                        {
                            commands[commands.Count - 1].value = commands[i].value;
                        }
                    }
                }
                if (commands[commands.Count - 1].key == "for")
                {
                    string forline = text[0..text.IndexOf("}")];
                    for (int i = 0; i < int.Parse(commands[commands.Count - 1].value) - 1; i++)
                        text = text.Insert(text.IndexOf("}"), forline);
                    text = text.Replace("}", "");
                }
            }
            Form2 form2 = new Form2(commands);
            form2.Show();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
    public class Commands(string key, string value)
    {
        public string key = key;
        public string value = value;
    }
}