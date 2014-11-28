using MainProject.View.WindowsPagesRichControl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace MainProject.ViewModel.WindowsPagesRichControl
{
    public class CSample24Vm:ViewModelBase
    {
        #region Fields

        private ICommand modPlayCommand;
        private ICommand modPlaySystemCommand;
        private ICommand modPlayMediaCommand;
        private ICommand modPlayMediaElementCommand;
        private ICommand modPlaySpeechCommandCommand;
        private ICommand modPlaySpeechRecognitionCommandCommand;

        private MediaPlayer player = new MediaPlayer();

        #endregion

        #region Ctor

        public CSample24Vm()
        {
            modPlayCommand = new DelegateCommand(OnPlay);
            modPlaySystemCommand = new DelegateCommand(OnPlaySystem);
            modPlayMediaCommand = new DelegateCommand(OnPlayMedia);
        }

        

        #endregion

        #region Private Services

        private void OnPlaySpeech()
        {
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en");
            System.Threading.Thread.CurrentThread.CurrentCulture = ci;
            Task.Run(() =>
            {
                SpeechSynthesizer synthesizer = new SpeechSynthesizer();
                synthesizer.Speak("Hello, world. i must to do this exercise to 4 o`clock.");
            });
            Task.Run(() =>
            {
                PromptBuilder prompt = new PromptBuilder();
                prompt.AppendText("Hello, user");
                SpeechSynthesizer synthesizer = new SpeechSynthesizer();
                synthesizer.Speak(prompt);
            });
        }

        private void OnPlaySpeechRecognition()
        {
            SpeechRecognizer recognizer = new SpeechRecognizer();
            //GrammarBuilder grammar = new GrammarBuilder();
            //grammar.Append(new Choices("red", "blue", "green", "black", "white"));
            //grammar.Append("my");
            //grammar.Append(new Choices("on", "off"));
            //recognizer.LoadGrammar(new Grammar(grammar));
            recognizer.SpeechRecognized += recognizer_SpeechRecognized;
        }

        private void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            MessageBox.Show("You said:" + e.Result.Text);
        }

        private void OnPlayMediaElement()
        {
            (this.ControlInstance as UserControl24).ctrMediaElement.Position = TimeSpan.Zero;
            (this.ControlInstance as UserControl24).ctrMediaElement.Play();
        }

        private void OnPlayMedia()
        {
            //player.Open(new Uri("file.mp3",UriKind.RelativeOrAbsolute));
            player.Open(new Uri("file.mp3", UriKind.RelativeOrAbsolute));
            player.Play();
        }

        private void OnPlaySystem()
        {
            SystemSounds.Beep.Play();
        }

        private void OnPlay()
        {
            SoundPlayer player = new SoundPlayer();
            //player.SoundLocation = "adios.wav";
            player.Stream = Properties.Resources.adios;

            try{
                player.Load();
                player.Play();
            }
            catch(FileNotFoundException ex){
                Console.WriteLine(ex.Message);
            }
            catch(FormatException ex){
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #region Public Services

        #endregion

        #region Properties

        #endregion

        #region Commands

        public ICommand PlayCommand { get{return modPlayCommand;} }
        public ICommand PlaySystemCommand { get { return modPlaySystemCommand; } }
        public ICommand PlayMediaCommand { get { return modPlayMediaCommand; } }
        public ICommand PlayMediaElementCommand { get { return modPlayMediaElementCommand ?? new DelegateCommand(OnPlayMediaElement); } }
        public ICommand PlaySpeechCommand { get { return modPlaySpeechCommandCommand ?? new DelegateCommand(OnPlaySpeech); } }
        public ICommand PlaySpeechRecognitionCommand { get { return modPlaySpeechRecognitionCommandCommand ?? new DelegateCommand(OnPlaySpeechRecognition); } }

        #endregion

    }
}
