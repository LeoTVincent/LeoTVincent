using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using System.Speech.Synthesis;

namespace TextToSpeech_console
{
    class Program
    {
        static string YourSubscriptionKey = "";
        static string YourServiceRegion = "westus2";

        static void OutputSpeechSynthesisResult(SpeechSynthesisResult speechSynthesisResult, string text)
        {
            switch (speechSynthesisResult.Reason)
            {
                case ResultReason.SynthesizingAudioCompleted:
                    Console.WriteLine($"Speech synthesized for text: [{text}]");
                    break;
                case ResultReason.Canceled:
                    var cancellation = SpeechSynthesisCancellationDetails.FromResult(speechSynthesisResult);
                    Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                    if (cancellation.Reason == CancellationReason.Error)
                    {
                        Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                        Console.WriteLine($"CANCELED: ErrorDetails=[{cancellation.ErrorDetails}]");
                        Console.WriteLine($"CANCELED: Did you set the speech resource key and region values?");
                    }
                    break;
                default:
                    break;
            }
        }
        private static void Speak(string textToSpeech, bool wait = false)
        {
            // Command to execute PS  
            Execute($@"Add-Type -AssemblyName System.speech;  
            $speak = New-Object System.Speech.Synthesis.SpeechSynthesizer;                           
            $speak.Speak(""{textToSpeech}"");"); // Embedd text  

            void Execute(string command)
            {
                // create a temp file with .ps1 extension  
                var cFile = System.IO.Path.GetTempPath() + Guid.NewGuid() + ".ps1";

                //Write the .ps1  
                using var tw = new System.IO.StreamWriter(cFile, false, Encoding.UTF8);
                tw.Write(command);

                // Setup the PS  
                var start =
                    new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "C:\\windows\\system32\\windowspowershell\\v1.0\\powershell.exe",  // CHUPA MICROSOFT 02-10-2019 23:45                    
                        LoadUserProfile = false,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        Arguments = $"-executionpolicy bypass -File {cFile}",
                        WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
                    };

                //Init the Process  
                var p = System.Diagnostics.Process.Start(start);
                // The wait may not work! :(  
                if (wait) p.WaitForExit();
            }
        }
        async static Task Main(string[] args)
        {
            //Speak("Hello Leo"); //this is with .NET Framework System.Speech implementation

            //this is with .Net core System.Speech implementation
            System.Speech.Synthesis.SpeechSynthesizer speech = new System.Speech.Synthesis.SpeechSynthesizer();
            speech.SpeakAsync("Leo Thiraviyam");
            System.Speech.Recognition.SpeechRecognizer speechRecognizer = new System.Speech.Recognition.SpeechRecognizer();
            speechRecognizer.EmulateRecognize("");

            //thi is with Azure Speech cognitive service implementation
            //var speechConfig = SpeechConfig.FromSubscription(YourSubscriptionKey, YourServiceRegion);

            //// The language of the voice that speaks.
            //speechConfig.SpeechSynthesisVoiceName = "en-US-JennyNeural";

            //using (var speechSynthesizer = new SpeechSynthesizer(speechConfig))
            //{
            //    // Get text from the console and synthesize to the default speaker.
            //    Console.WriteLine("Enter some text that you want to speak >");
            //    string text = Console.ReadLine();

            //    var speechSynthesisResult = await speechSynthesizer.SpeakTextAsync(text);
            //    OutputSpeechSynthesisResult(speechSynthesisResult, text);
            //}

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
