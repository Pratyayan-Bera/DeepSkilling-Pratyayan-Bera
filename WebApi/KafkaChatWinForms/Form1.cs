using Confluent.Kafka;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KafkaChatWinForms
{
    public partial class Form1 : Form
    {
        private ProducerConfig producerConfig;
        private ConsumerConfig consumerConfig;

        public Form1()
        {
            InitializeComponent();

            producerConfig = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };

            consumerConfig = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = Guid.NewGuid().ToString(),
                AutoOffsetReset = AutoOffsetReset.Latest
            };

            StartConsumer();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show("Button clicked");

                string message = textBox1.Text;

                if (string.IsNullOrWhiteSpace(message))
                    return;

                using (var producer = new ProducerBuilder<Null, string>(producerConfig).Build())
                {
                    await producer.ProduceAsync(
                        "chat-topic",
                        new Message<Null, string>
                        {
                            Value = message
                        });
                }

                MessageBox.Show("Message Sent Successfully");

                textBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void StartConsumer()
        {
            Task.Run(() =>
            {
                using (var consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build())
                {
                    consumer.Subscribe("chat-topic");

                    while (true)
                    {
                        var result = consumer.Consume();

                        Invoke((MethodInvoker)delegate
                        {
                            richTextBox1.AppendText(
                                result.Message.Value + Environment.NewLine);
                        });
                    }
                }
            });
        }
    }
}