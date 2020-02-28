using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Path = System.IO.Path;

namespace MusicPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// Samuel Siew Fei Lee 30018308
    /// 13/02/2020
    public partial class MainWindow : Window
    {

        // Linked list to store filepath of loaded songs
        private static LinkedList<string> Songs = new LinkedList<string>();
        // mediaplayer resource used to control audio output
        private static MediaPlayer mediaPlayer = new MediaPlayer();
        // keep track of current node
        private static LinkedListNode<string> current = null;
        

        public MainWindow()
        {
            InitializeComponent();
        }

        // method for loading audio into program using regex, one file at a time
        private void LoadAudio_Click(object sender, RoutedEventArgs e)
        {            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string el = openFileDialog.FileName;
                Songs.AddLast(el);
                current = Songs.Find(el);
                mediaPlayer.Open(new Uri(openFileDialog.FileName));
                UpdatePlaylistDisplay();
                /*
                string le = mediaPlayer.Source.AbsolutePath;
                MessageBox.Show(el + "\n" + le.Replace("/", "\\"));
                */
            }            
        }

        // displays songs in list box
        private void UpdatePlaylistDisplay()
        {
            SongsListBox.Items.Clear();
            foreach (string s in Songs)
            {
                string fileName = Path.GetFileNameWithoutExtension(s);
                SongsListBox.Items.Add(fileName);
            }
        }

        // play btn functionality
        // checks for media source before playing
        // timer will call timer_Tick every passing second until the file plays successfully
        // which protects against rapid clicking of next and back, which could render an 
        // invalid timespan to be passed to be passed in the timer_Tick method
        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {            
            if (mediaPlayer.Source != null)
            {
                mediaPlayer.Play();
                UpdateCurrentlyPlaying();
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += timer_Tick;
                timer.Start();
            }
            else
            {
                MessageBox.Show("Error! No file selected.");
            }                
        }

        // method to control the timer display
        // checks media source if it has a source timespan before displaying 
        private void timer_Tick(object sender, EventArgs e)
        {
            if (mediaPlayer.Source != null && mediaPlayer.NaturalDuration.HasTimeSpan)
            {
                DisplayTime.Content = String.Format("{0} / {1}", mediaPlayer.Position.ToString(@"mm\:ss"),
                    mediaPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
            }
            else
            {
                DisplayTime.Content = "No file selected...?";
            }
                
        }

        // controls text box which displays name of song currently selected
        private void UpdateCurrentlyPlaying()
        {
            // using System.IO Path
            if (mediaPlayer.Source != null)
            {
                string songName = Path.GetFileNameWithoutExtension(mediaPlayer.Source.AbsoluteUri);
                CurrentSong.Text = songName;
            }
            else
            {
                CurrentSong.Text = "";
            }
            
        }

        // move current node to beginning of list
        private void BtnBeg_Click(object sender, RoutedEventArgs e)
        {            
            if (Songs.Count > 1)
            {
                current = Songs.First;          
                mediaPlayer.Open(new Uri(current.Value));
                UpdateCurrentlyPlaying();
            }            
        }

        // move current node to end of list
        private void BtnEnd_Click(object sender, RoutedEventArgs e)
        {
            if (Songs.Count > 1)
            {
                current = Songs.Last;
                mediaPlayer.Open(new Uri(current.Value));
                UpdateCurrentlyPlaying();
            }
            
        }

        // play song at the next node if exists
        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            if (current != null && current.Next != null)
            {
                current = current.Next; 
                mediaPlayer.Open(new Uri(current.Value));
                mediaPlayer.Play();
                UpdateCurrentlyPlaying();
            }
            else
            {
                MessageBox.Show("Error! Unable to proceed to next song.");
            }
        }

        // play the song at the previous node if exists
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (current != null && current.Previous != null)
            {                
                current = current.Previous;
                mediaPlayer.Open(new Uri(current.Value));
                mediaPlayer.Play();
                UpdateCurrentlyPlaying();
            }
            else
            {
                MessageBox.Show("Error! Unable to go to the song behind.");
            }
        }

        // delete song by pressing delete key and update display
        private void SongsListBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Delete)
            {
                if (SongsListBox.SelectedIndex > -1 && Songs.Count > 0)
                {
                    int toDelete = SongsListBox.SelectedIndex;                    
                    Songs.Remove(Songs.ElementAt(toDelete));                                                     
                    mediaPlayer.Close();
                    if (Songs.Count > 0)
                    {
                        current = Songs.First;
                        mediaPlayer.Open(new Uri(current.Value));
                    }                    
                    UpdatePlaylistDisplay();
                    UpdateCurrentlyPlaying();
                }
            }
            
        }

        // button functionality
        private void BtnPause_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }
        // button functionality
        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }

    }
}
