using OpenAI.GPT3;
using OpenAI.GPT3.Managers;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Linq;

namespace EasyProof
{
    public partial class MainWindow : Window
    {
        private readonly Model _model;
        private readonly OpenAIService _openAIService;

        public MainWindow()
        {
            InitializeComponent();

            _model = new Model(ProofAsync, ClearAll);

            DataContext = _model;

            var apiKey = Environment.GetEnvironmentVariable("MY_OPEN_AI_API_KEY", EnvironmentVariableTarget.Machine);

            _openAIService = new OpenAIService(new OpenAiOptions() { ApiKey = apiKey });
        }

        public async Task ProofAsync()
        {
            if (string.IsNullOrWhiteSpace(_model.RawText))
            {
                MessageBox.Show("You need to provide text before clicking the Proof button!");
                return;
            }

            _model.Processing = Visibility.Visible;

            var response = await Request(_model.RawText);

            if (!string.IsNullOrWhiteSpace(response))
            {
                _model.ProofedText = response;
            }

            _model.Processing = Visibility.Collapsed;
        }

        public void ClearAll()
        {
            _model.RawText = "";
            _model.ProofedText = "";
        }

        private async Task<string> Request(string prompt)
        {
            try
            {
                var promptRequest = 
                    $"Proof and correct the following text: {prompt}";

                var request = new CompletionCreateRequest
                {
                    Prompt = promptRequest,
                    Model = Models.TextDavinciV3,
                    MaxTokens = 500,
                };

                var result = await _openAIService.Completions.CreateCompletion(request);

                if (result.Successful)
                {
                    return result.Choices.FirstOrDefault().Text.Trim();
                }

                if (result.Error == null)
                {
                    MessageBox.Show("Unknown Error");
                    return null;
                }

                MessageBox.Show($"{result.Error.Code}: {result.Error.Message}");
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
